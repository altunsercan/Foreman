using UnityEngine;
using System.Collections;
using Foreman.Impl;

namespace Foreman.Testing.IntegrationTest.Domain
{
    public class PickUp : JobBase
    {
        public readonly CarriableItem Carriable;

        public PickUp(string identifier, CarriableItem carriable ) : base("PickUp", identifier)
        {
            Carriable = carriable;
        }
    }
}


