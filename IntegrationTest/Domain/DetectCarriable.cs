using UnityEngine;
using System.Collections;
using Foreman.Impl;
using Foreman.Testing.IntegrationTest.Domain;

namespace Foreman.Testing.IntegrationTest.Domain
{
    public class DetectCarriable : JobBase
    {
        public CarriableItem Carriable { get; private set; }

        public DetectCarriable(string identifier) : base("DetectCarriable", identifier)
        {
        }
    }
}

