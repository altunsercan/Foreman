using UnityEngine;
namespace Foreman.Testing.IntegrationTest.Domain
{
    public class PickUpBehaviour:JobBehaviour<PickUp>
    {
        private NavMeshAgent agent;

        public override void AssignJobData(PickUp jobData)
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
            
            agent.SetDestination((_jobData.Carriable as MonoBehaviour).transform.position);
            agent.Resume();
        }

        void Update()
        {
            if( CheckReached() )
            {
                (_jobData.Carriable as MonoBehaviour).transform.SetParent(this.transform);

                CompleteJob();
            }
        }

        void OnDisable()
        {
            
        }

        void CompleteJob()
        {
            _jobData.Complete();
        }

        bool CheckReached()
        {
            if( _jobData != null && _jobData.Carriable is MonoBehaviour )
            {
                float distance = Vector3.Distance(
                (_jobData.Carriable as MonoBehaviour).transform.position,
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