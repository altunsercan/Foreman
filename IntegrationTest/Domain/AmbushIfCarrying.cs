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

    public class AmbushIfCarrying : CompoundJobBase
    {
        
        public AmbushIfCarrying(string identifier, GameObject target) : base("AmbushIfCarrying", identifier)
        {
            this.SubJobsList.Add(new DetectCarriable("detectItem"));
            this.SubJobsList.Add(new MoveTo("moveToDwarf", target.transform));
            this.SubJobsList.Add(new Attack("attackDwarf", target));
        }
    }
}