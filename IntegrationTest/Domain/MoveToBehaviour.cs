using UnityEngine;
namespace Foreman.Testing.IntegrationTest.Domain
{
    public class MoveToBehaviour:JobBehaviour<MoveTo>
    {
        private NavMeshAgent agent;
        
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
                Complete();
                return;
            }
            
            agent.SetDestination(_jobData.Target.position);
            this.agent.Resume();
            
        }

        void OnDisable()
        {
            if(agent.isActiveAndEnabled)
            {
                agent.Stop();
            }
        }
        
        bool CheckReached()
        {
            if( _jobData != null )
            {
                if(agent.remainingDistance < 0.5f)
                {
                    return true;
                }
            }
            return false;
        }
    }
}