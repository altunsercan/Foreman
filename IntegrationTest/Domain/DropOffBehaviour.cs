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

            (_jobData.Carriable as MonoBehaviour).transform.SetParent(null);
            Complete();
        }
    }
}