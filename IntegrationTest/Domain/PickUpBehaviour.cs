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
        
        void OnEnable()
        {
            if( _jobData == null)
            {

                Debug.Log("Run like hell");
                return;
            }

            var mono = (_jobData.Carriable as MonoBehaviour);
            float distance = Vector3.Distance(
                mono.transform.position,
                this.transform.position);

            if (distance < 0.5f)
            {
                mono.transform.SetParent(this.transform);

                Complete();
                return;
            }
            
            CancelJob();
        }

        void OnDisable()
        {
            
        }
        
        
    }
}