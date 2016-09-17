using UnityEngine;
using System.Collections;
using Foreman.Impl;
using Foreman.Testing.IntegrationTest.Domain;

namespace Foreman.Testing.IntegrationTest.Domain
{
    public class DropOff : JobBase
    {
        public readonly CarriableItem Carriable;
        public DropOff(string identifier, CarriableItem carriable):base("DropOff", identifier)
        {
            Carriable = carriable;
        }
    }
}

