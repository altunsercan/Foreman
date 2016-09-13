using System;

namespace Foreman.Impl
{
    public abstract class JobBase : Job
    {
        private string _name;
        private string _identifier;

        private JobStatus _status = JobStatus.WAITING;

        public JobBase(string name, string identifier)
        {
            _identifier = identifier;
            _name = name;
        }
        
        public string Identifier
        {
            get
            {
                return _identifier;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public JobStatus Status
        {
            get
            {
                return _status;
            }

            private set
            {
                _status = value;
                if( StatusChanged != null )
                {
                    StatusChanged(_status);
                }
            }
        }

        public event Action<JobStatus> StatusChanged;

        public bool Cancel()
        {
           if( Status == JobStatus.CANCELLED )
            {
                return false;
            }

            Status = JobStatus.CANCELLED;
            return true;
        }

        public bool Continue()
        {
            if (Status == JobStatus.PAUSED)
            {
                Status = JobStatus.PAUSED;
                return true;
            }

            return false;
        }

        public bool Pause()
        {
            if (Status == JobStatus.INPROGRESS)
            {
                Status = JobStatus.SUSPENDED;
                return true;
            }

            return false;
        }

        public bool Start()
        {
            if (Status == JobStatus.SUSPENDED || Status == JobStatus.WAITING)
            {
                Status = JobStatus.INPROGRESS;
                return true;
            }

            return false;
        }

        public bool Suspend()
        {
            if (Status == JobStatus.INPROGRESS || _status == JobStatus.WAITING)
            {
                Status = JobStatus.SUSPENDED;
                return true;
            }

            return false;
        }

        public bool Complete()
        {
            if (Status == JobStatus.COMPLETED)
            {
                return false;
            }

            Status = JobStatus.COMPLETED;
            return true;
        }
    }
}
