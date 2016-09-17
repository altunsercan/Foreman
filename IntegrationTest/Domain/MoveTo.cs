using UnityEngine;
using System.Collections;
using Foreman.Impl;

namespace Foreman.Testing.IntegrationTest.Domain
{
    public class MoveTo : JobBase
    {
        public readonly Transform Target;

        public MoveTo(string identifier, Transform target) : base("MoveTo", identifier)
        {
            Target = target;
        }
    }
}


