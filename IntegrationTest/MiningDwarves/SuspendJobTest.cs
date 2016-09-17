using UnityEngine;
using Foreman.Impl;
using Foreman.Testing.IntegrationTest.Domain;
using System;
using System.Collections;
using UnityEngine.UI;

namespace Foreman.Testing.IntegrationTest.Mining
{
    public class SuspendJobTest : MonoBehaviour
    {
        public Text SuspendTxt;

        public GameObject Dwarf;
        public GameObject Gold;
        public GameObject Target;

        // Use this for initialization
        void Start()
        {
            SuspendTxt.text = "";

            MiningDomain.InitializeDomain();

            Worker worker = Dwarf.GetComponent<Worker>();
            CarriableItem item = Gold.GetComponent<CarriableItem>();
            Transform target = Target.transform;
            
            worker.QueueJob(new MoveTo("moveToGold", (item as MonoBehaviour).transform));
            worker.QueueJob(new PickUp("pickupGold", item));
            worker.QueueJob(new MoveTo("moveToChest", target));
            worker.QueueJob(new DropOff("dropoffGold", item));

            worker.Work();

            StartCoroutine(SuspendTimer());

        }

        private IEnumerator SuspendTimer()
        {
            Worker worker = Dwarf.GetComponent<Worker>();

            yield return new WaitForSeconds(2);
            SuspendTxt.text = "Job Suspended";
            worker.CurrentHandler.SuspendJob();
            
            yield return new WaitForSeconds(2);
            SuspendTxt.text = "Job Continued";
            worker.CurrentHandler.StartJob();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

