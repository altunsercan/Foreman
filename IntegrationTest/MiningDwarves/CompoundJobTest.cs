// /*
//  * Copyright (C) 2016 Sercan Altun
//  * All rights reserved.
//  *
//  * This software may be modified and distributed under the terms
//  * of open source MIT license.  See the LICENSE file for details.
//  */
namespace Foreman.Testing.IntegrationTest.Mining
{
    using System.Collections;

    using global::Foreman.Impl;
    using global::Foreman.Testing.IntegrationTest.Domain;

    using UnityEngine;
    using UnityEngine.UI;

    public class CompoundJobTest : MonoBehaviour
    {
        public GameObject Dwarf;
        public GameObject Bandit;

        public GameObject Gold;

        public Text SuspendTxt;

        public GameObject Target;

        // Use this for initialization
        private void Start()
        {
            this.SuspendTxt.text = string.Empty;

            MiningDomain.InitializeDomain();

            this.SetupDwarf();
            this.SetupBandit();
            
        }

        private void SetupBandit()
        {
            MonoWorker worker = this.Bandit.GetComponent<MonoWorker>();
            
            worker.QueueJob(new AmbushIfCarrying("AmbushIfCarrying", this.Dwarf));
            worker.Work();
        }

        private void SetupDwarf()
        {
            MonoWorker worker = this.Dwarf.GetComponent<MonoWorker>();
            CarriableItem item = this.Gold.GetComponent<CarriableItem>();
            Transform target = this.Target.transform;

            worker.QueueJob(new CarryItemTo("CarryGoldTo", item, target));
            worker.Work();
        }
    }
}