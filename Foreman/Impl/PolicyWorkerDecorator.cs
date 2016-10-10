using System;
using System.Collections.Generic;

namespace Foreman.Impl
{
    /*
    public class PolicyWorkerDecorator : Worker
    {
        public enum JobPolicy
        {
            WAIT_IF_SUSPENDED,
            SKIP_IF_SUSPENDED,

        }

        private Worker _decoratedWorker;
        private JobPolicy _policy;

        public PolicyWorkerDecorator( Worker decoratedWorker, JobPolicy policy = JobPolicy.WAIT_IF_SUSPENDED )
        {
            _decoratedWorker = decoratedWorker;
            SetPolicy(policy);
        }

        public void SetPolicy(JobPolicy policy)
        {
            _policy = policy;
        }

        public Job[] Queued
        {
            get
            {
                return _decoratedWorker.Queued;
            }
        }

        public WorkerState State
        {
            get
            {
                return _decoratedWorker.State;
            }
        }

        public bool QueueJob(Job job)
        {
            return _decoratedWorker.QueueJob(job);
        }
        
        public bool QueueOrder(Order order, bool append)
        {
            return _decoratedWorker.QueueOrder(order, append);
        }

        public bool RemoveJob(Job job)
        {
            return _decoratedWorker.RemoveJob(job);
        }

        public bool Work(Job job = null)
        {
            
            if( job == null && _decoratedWorker.Queued.>0)
            {
                job = _decoratedWorker.Queued[0];
            }

            if( _policy == JobPolicy.WAIT_IF_SUSPENDED)
            {
                return HandleWaitIfSuspended(job);
            }else if( _policy == JobPolicy.SKIP_IF_SUSPENDED )
            {
                return HandleSkipIfSuspended(job);
            }

            return false;
            
        }

        private bool HandleSkipIfSuspended(Job job)
        {
            if (job.Status == JobStatus.SUSPENDED)
            {
                //job.Status = JobStatus.WAITING;
            }
            else
            {
                return _decoratedWorker.Work(job);
            }
            return false;
        }

        private bool HandleWaitIfSuspended(Job job)
        {
            if( job.Status == JobStatus.SUSPENDED )
            {
                //job.Status = JobStatus.WAITING;
            }
            else
            {
                return _decoratedWorker.Work(job);
            }
            return false;
        }
        
    }
    */
}
