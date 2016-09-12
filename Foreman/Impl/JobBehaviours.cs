using UnityEngine;

namespace Foreman
{
    public class JobBehaviour<T> : MonoBehaviour, JobHandler where T : Job
    {
        protected T _jobData;

        public void AssignJobData(Job jobData)
        {
            if(jobData is T)
            {
                AssignJobData(jobData);
            }
        }

        public virtual void AssignJobData(T jobData)
        {
            _jobData = jobData;
        }
    }
}