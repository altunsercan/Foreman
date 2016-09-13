using UnityEngine;
using Foreman.Impl;
using Foreman.Testing.IntegrationTest.Domain;

namespace Foreman.Testing.IntegrationTest.Mining
{
    public class PickupDropoffTest : MonoBehaviour
    {
        public GameObject Dwarf;
        public GameObject Gold;
        public GameObject Target;

        // Use this for initialization
        void Start()
        {
            Foreman.AddProvider(new FuncJobProvider((job, gobj)=> {
                if( !(job is PickUp) )
                {
                    return null;
                }

                PickUpBehaviour behaviour = gobj.AddComponent<PickUpBehaviour>();

                return behaviour; 
            }));

            Foreman.AddProvider(new FuncJobProvider((job, gobj) => {
                if (!(job is DropOff))
                {
                    return null;
                }

                DropOffBehaviour behaviour = gobj.AddComponent<DropOffBehaviour>();

                return behaviour;
            }));

            Worker worker = Dwarf.GetComponent<Worker>();
            CarriableItem item = Gold.GetComponent<CarriableItem>();
            Transform target = Target.transform;

            Debug.Log("Carriable Item " + item);

            worker.QueueJob(new PickUp("pickupGold", item));
            worker.QueueJob(new DropOff("dropoffGold", item, target));

            worker.Work();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

