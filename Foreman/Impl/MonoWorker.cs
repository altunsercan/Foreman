using System;
using System.Collections.Generic;
using UnityEngine;
namespace Foreman.Impl
{
    public class MonoWorker : MonoBehaviour, Worker
    {
        private JobHandler _jobHandler;
        private Job _currentJob;

        private WorkerState _state;

        private List<Job> _queuedJobs = new List<Job>();

        public Job[] Queued
        {
            get
            {
                return _queuedJobs.ToArray();
            }
        }

        public WorkerState State
        {
            get
            {
                return _state;
            }
        }

        public bool QueueJob(Job job)
        {
            if( _queuedJobs.Contains( job ) )
            {
                return false;
            }

            _queuedJobs.Add(job);
            return true;
        }

        public bool RemoveJob(Job job)
        {
            if( _queuedJobs.Contains(job) )
            {
                _queuedJobs.Remove(job);
                return true;
            }

            return false;
        }

        public bool Work(Job job = null)
        {
            if( job == null && _queuedJobs.Count>0 )
            {
                job = _queuedJobs[0];
            }
            else
            {
                return false;
            }

            _currentJob = job;
            _jobHandler = Foreman.CreateHandler(job, this.gameObject);

            job.Start();
            if (_jobHandler is MonoBehaviour)
            {
                (_jobHandler as MonoBehaviour).enabled = true;
            }

            job.StatusChanged += OnJobStatusChanged;
            _state = WorkerState.BUSY;

            return true;
        }

        private void OnJobStatusChanged(JobStatus status)
        {
            if(status == JobStatus.COMPLETED)
            {
                _currentJob.StatusChanged -= OnJobStatusChanged;

                _queuedJobs.Remove(_currentJob);

                if( _jobHandler is MonoBehaviour)
                {
                    Destroy(_jobHandler as MonoBehaviour);
                }
                _currentJob = null;
                _jobHandler = null;

                if( !this.Work() )
                {
                    _state = WorkerState.IDLE;
                }
            }
        }
    }
}
