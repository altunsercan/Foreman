// /*
//  * Copyright (C) 2016 Sercan Altun
//  * All rights reserved.
//  *
//  * This software may be modified and distributed under the terms
//  * of open source MIT license.  See the LICENSE file for details.
//  */
namespace Foreman.Testing.IntegrationTest.Domain
{
    using UnityEngine;

    public class DetectCarriableBehaviour : JobBehaviour<DetectCarriable>
    {

        public override void AssignJobData(DetectCarriable jobData)
        {
            base.AssignJobData(jobData);
        }

        private void OnTriggerEnter(Collider trigger)
        {
            MetalData metal = trigger.GetComponent<MetalData>();
            if (metal != null)
            {
                this.Complete();
            }
        }

    }
}