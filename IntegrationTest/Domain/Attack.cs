using UnityEngine;
using System.Collections;
using Foreman.Impl;
using Foreman.Testing.IntegrationTest.Domain;

namespace Foreman.Testing.IntegrationTest.Domain
{
    public class Attack : JobBase
    {
        public readonly GameObject Target;
        public Attack(string identifier, GameObject target) : base("Attack", identifier)
        {
            Target = target;
        }
    }
}

