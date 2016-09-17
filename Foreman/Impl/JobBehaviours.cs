// /*
//  * Copyright (C) 2016 Sercan Altun
//  * All rights reserved.
//  *
//  * This software may be modified and distributed under the terms
//  * of open source MIT license.  See the LICENSE file for details.
//  */
namespace Foreman
{
    using System;

    using UnityEngine;

    public class JobBehaviour<T> : MonoBehaviour, JobHandler
        where T : Job
    {
        protected T _jobData;

        private JobStatus _status = JobStatus.WAITING;

        public event Action<JobStatus> StatusChanged;

        public JobStatus Status
        {
            get
            {
                return this._status;
            }

            private set
            {
                this._status = value;
                if (this.StatusChanged != null)
                {
                    this.StatusChanged(this._status);
                }
            }
        }

        public void AssignJobData(Job jobData)
        {
            if (jobData is T)
            {
                this.AssignJobData((T)jobData);
            }
        }

        public virtual void AssignJobData(T jobData)
        {
            this._jobData = jobData;
        }

        public virtual bool CancelJob()
        {
            if (this.Status == JobStatus.CANCELLED)
            {
                return false;
            }

            this.Status = JobStatus.CANCELLED;
            return true;
        }

        public virtual bool StartJob()
        {
            if (this.Status == JobStatus.SUSPENDED || this.Status == JobStatus.WAITING)
            {
                this.Status = JobStatus.INPROGRESS;
                return true;
            }

            return false;
        }

        public virtual bool SuspendJob()
        {
            if (this.Status == JobStatus.INPROGRESS || this._status == JobStatus.WAITING)
            {
                this.Status = JobStatus.SUSPENDED;
                return true;
            }

            return false;
        }

        protected virtual bool Complete()
        {
            if (this.Status == JobStatus.COMPLETED)
            {
                return false;
            }

            this.Status = JobStatus.COMPLETED;
            return true;
        }
    }
}