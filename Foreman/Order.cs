
using System;
using Foreman.Testing.IntegrationTest.Domain;

namespace Foreman
{
    public interface Order
    {
        Job[] Jobs { get; }
    }
}
