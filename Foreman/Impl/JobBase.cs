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
        }

        public bool Cancel()
        {
           if( _status == JobStatus.CANCELLED )
            {
                return false;
            }

            _status = JobStatus.CANCELLED;
            return true;
        }

        public bool Continue()
        {
            if (_status == JobStatus.PAUSED)
            {
                _status = JobStatus.PAUSED;
                return true;
            }

            return false;
        }

        public bool Pause()
        {
            if (_status == JobStatus.INPROGRESS)
            {
                _status = JobStatus.SUSPENDED;
                return true;
            }

            return false;
        }

        public bool Start()
        {
            if (_status == JobStatus.SUSPENDED || _status == JobStatus.WAITING)
            {
                _status = JobStatus.INPROGRESS;
                return true;
            }

            return false;
        }

        public bool Suspend()
        {
            if (_status == JobStatus.INPROGRESS || _status == JobStatus.WAITING)
            {
                _status = JobStatus.SUSPENDED;
                return true;
            }

            return false;
        }
    }
}
