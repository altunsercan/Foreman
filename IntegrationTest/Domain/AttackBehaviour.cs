// /*
//  * Copyright (C) 2016 Sercan Altun
//  * All rights reserved.
//  *
//  * This software may be modified and distributed under the terms
//  * of open source MIT license.  See the LICENSE file for details.
//  */
namespace Foreman.Testing.IntegrationTest.Domain
{
    using System.Collections;

    using global::Foreman.Impl;

    using UnityEngine;

    public class AttackBehaviour : JobBehaviour<Attack>
    {
        private MetalData metal;

        public override void AssignJobData(Attack jobData)
        {
            base.AssignJobData(jobData);
        }

        public override bool StartJob()
        {
            this.StopTargetWorker();
            this.TargetDropsItems();

            this.StartCoroutine(this.FightAWhileThenDie());

            return base.StartJob();
        }

        private IEnumerator AnimateDrop(Vector3 target)
        {
            Vector3 startPos = this.transform.position;
            float time = 0;
            do
            {
                time += Time.deltaTime;
                this.metal.transform.position = Vector3.Lerp(startPos, target, time / 1.5f);
                yield return new WaitForEndOfFrame();
            }
            while (time < 1.5f);
        }

        private IEnumerator FightAWhileThenDie()
        {
            yield return new WaitForSeconds(3);

            MonoWorker monoTarget = this._jobData.Target.GetComponent<MonoWorker>();
            monoTarget.CurrentHandler.StartJob();

            GameObject.Destroy(this.gameObject);
        }

        private void StopTargetWorker()
        {
            MonoWorker monoTarget = this._jobData.Target.GetComponent<MonoWorker>();
            monoTarget.CurrentHandler.SuspendJob();
        }

        private void TargetDropsItems()
        {
            this.metal = this._jobData.Target.GetComponentInChildren<MetalData>();
            this.metal.transform.SetParent(this.transform.parent);

            this.StartCoroutine(
                this.AnimateDrop(
                    this.metal.transform.position + ((this.transform.position - this.metal.transform.position) * 3)));
        }
    }
}