using System;
using System.Collections.Generic;
using UnityEngine;
namespace Foreman.Impl
{
    public class MonoWorker : MonoBehaviour, Worker
    {
        private JobHandler _jobHandler;

        private WorkerState _state;

        private List<Job> _queuedJobs;

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

            _jobHandler = Foreman.CreateHandler(job, this.gameObject);

            job.Start();
            return true;
        }
    }
}
