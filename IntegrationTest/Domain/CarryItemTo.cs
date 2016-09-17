// /*
//  * Copyright (C) 2016 
//  * All rights reserved.
//  *
//  * This software may be modified and distributed under the terms
//  * of open source MIT license.  See the LICENSE file for details.
//  */
namespace Foreman.Testing.IntegrationTest.Domain
{
    using global::Foreman.Impl;

    using UnityEngine;

    public class CarryItemTo : CompoundJobBase
    {
        public readonly CarriableItem Carriable;

        public readonly Transform Target;

        public CarryItemTo(string identifier, CarriableItem carriable, Transform target)
            : base("CarryItemTo", identifier)
        {
            this.Carriable = carriable;
            this.Target = target;

            MonoBehaviour item = (MonoBehaviour)carriable;
            
            this.SubJobsList.Add(new MoveTo("moveToGold", item.transform ));
            this.SubJobsList.Add(new PickUp("pickupGold", carriable));
            this.SubJobsList.Add(new MoveTo("moveToChest", target));
            this.SubJobsList.Add(new DropOff("dropoffGold", carriable));
        }
    }
}