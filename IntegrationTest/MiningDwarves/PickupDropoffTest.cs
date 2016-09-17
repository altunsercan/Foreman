﻿using UnityEngine;
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
            MiningDomain.InitializeDomain();

            Worker worker = Dwarf.GetComponent<Worker>();
            CarriableItem item = Gold.GetComponent<CarriableItem>();
            Transform target = Target.transform;

            worker.QueueJob(new MoveTo("moveToGold", (item as MonoBehaviour).transform));
            worker.QueueJob(new PickUp("pickupGold", item));
            worker.QueueJob(new MoveTo("moveToChest", target));
            worker.QueueJob(new DropOff("dropoffGold", item));

            worker.Work();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

