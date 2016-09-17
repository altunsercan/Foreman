// /*
//  * Copyright (C) 2016 Sercan Altun
//  * All rights reserved.
//  *
//  * This software may be modified and distributed under the terms
//  * of open source MIT license.  See the LICENSE file for details.
//  */
namespace Foreman.Impl
{
    using System.Collections.Generic;

    using UnityEngine;

    public class MonoWorker : MonoBehaviour, Worker
    {
        private readonly List<Job> queuedJobs = new List<Job>();

        private SubMonoWorker subWorker;

        public JobHandler CurrentHandler { get; private set; }

        public Job[] Queued
        {
            get
            {
                return this.queuedJobs.ToArray();
            }
        }

        public WorkerState State { get; private set; }

        public bool QueueJob(Job job)
        {
            if (this.queuedJobs.Contains(job))
            {
                return false;
            }

            this.queuedJobs.Add(job);
            return true;
        }

        public bool RemoveJob(Job job)
        {
            if (!this.queuedJobs.Contains(job))
            {
                return false;
            }

            this.queuedJobs.Remove(job);
            return true;
        }

        public void ResetJobs()
        {
            this.queuedJobs.Clear();
        }

        public bool Work(Job job = null)
        {
            if (job == null && this.queuedJobs.Count > 0)
            {
                job = this.queuedJobs[0];
            }
            else
            {
                return false;
            }

            CompoundJob compoundJob = job as CompoundJob;
            if (compoundJob != null)
            {
                this.WorkCompoundJob(compoundJob);
            }
            else
            {
                this.WorkJob(job);
            }

            return true;
        }

        private void HandleCurrentJobComplete()
        {
            this.CurrentHandler.StatusChanged -= this.OnJobStatusChanged;

            this.queuedJobs.RemoveAt(0);

            MonoBehaviour behaviour = this.CurrentHandler as MonoBehaviour;
            if (behaviour != null)
            {
                MonoBehaviour.Destroy(behaviour);
            }

            this.CurrentHandler = null;

            if (!this.Work())
            {
                this.State = WorkerState.IDLE;
            }
        }

        private void HandleCurrentJobInProgress()
        {
            MonoBehaviour behaviour = this.CurrentHandler as MonoBehaviour;
            if (behaviour != null)
            {
                behaviour.enabled = true;
            }

            Job job = this.queuedJobs[0];
            CompoundJob compoundJob = job as CompoundJob;
            if (compoundJob != null)
            {
                this.subWorker.ResetJobs();
                foreach (Job subJob in compoundJob.SubJobs)
                {
                    this.subWorker.QueueJob(subJob);
                }

                this.subWorker.Work();
            }

            this.State = WorkerState.BUSY;
        }

        private void HandleCurrentJobSuspended()
        {
            MonoBehaviour handler = this.CurrentHandler as MonoBehaviour;
            if (handler != null)
            {
                handler.enabled = false;
            }

            if (this.subWorker != null)
            {
                this.subWorker.CurrentHandler.SuspendJob();
            }
        }

        private void OnJobStatusChanged(JobStatus status)
        {
            if (status == JobStatus.COMPLETED)
            {
                this.HandleCurrentJobComplete();
            }
            else if (status == JobStatus.SUSPENDED)
            {
                this.HandleCurrentJobSuspended();
            }
            else if (status == JobStatus.INPROGRESS)
            {
                this.HandleCurrentJobInProgress();
            }
        }

        private void WorkCompoundJob(CompoundJob job)
        {
            this.subWorker = this.gameObject.AddComponent<SubMonoWorker>();
            this.WorkJob(job);
        }

        private void WorkJob(Job job)
        {
            this.CurrentHandler = Foreman.CreateHandler(job, this.gameObject);
            this.CurrentHandler.StatusChanged += this.OnJobStatusChanged;
            this.CurrentHandler.StartJob();
        }

        private class SubMonoWorker : MonoWorker
        {
        }
    }
}