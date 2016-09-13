using UnityEngine;
namespace Foreman.Testing.IntegrationTest.Domain
{
    public class DropOffBehaviour:JobBehaviour<DropOff>
    {
        private NavMeshAgent agent;

        public override void AssignJobData(DropOff jobData)
        {
            base.AssignJobData(jobData);
            
        }

        void Awake()
        {
            agent = this.GetComponent<NavMeshAgent>();
            this.enabled = false;
        }

        void OnEnable()
        {
            if( _jobData == null)
            {
                return;
            }
            
            agent.SetDestination(_jobData.Target.position);
            agent.Resume();
        }

        void Update()
        {
            if( CheckReached() )
            {
                (_jobData.Carriable as MonoBehaviour).transform.SetParent(null);

                CompleteJob();
            }
        }

        void OnDisable()
        {
            agent.Stop();   
        }

        void CompleteJob()
        {
            _jobData.Complete();
        }

        bool CheckReached()
        {
            if( _jobData != null )
            {
                float distance = Vector3.Distance(
                _jobData.Target.position,
                this.transform.position
                );

                if( distance < 0.5f)
                {
                    return true;
                }
            }
            return false;
        }
    }
}