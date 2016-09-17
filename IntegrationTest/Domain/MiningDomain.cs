using Foreman;
using Foreman.Impl;

namespace Foreman.Testing.IntegrationTest.Domain
{
    using UnityEngine;

    public class MiningDomain
    {
        public static void InitializeDomain()
        {
            Foreman.ClearProviders();

            Foreman.AddProvider(new FuncJobProvider(BindType<PickUp, PickUpBehaviour>));
            Foreman.AddProvider(new FuncJobProvider(BindType<DropOff, DropOffBehaviour>));
            Foreman.AddProvider(new FuncJobProvider(BindType<MoveTo, MoveToBehaviour>));
            Foreman.AddProvider(new FuncJobProvider(BindType<CarryItemTo, CarryItemToBehaviour>));
            Foreman.AddProvider(new FuncJobProvider(BindType<Attack, AttackBehaviour>));
            Foreman.AddProvider(new FuncJobProvider(BindType<DetectCarriable, DetectCarriableBehaviour>));
            Foreman.AddProvider(new FuncJobProvider(BindType<AmbushIfCarrying, AmbushIfCarryingBehaviour>));
        }

        private static TW BindType<T, TW>(Job job, GameObject gobj) where T : Job where TW : MonoBehaviour, JobHandler
        {
            if (!(job is T))
            {
                return null;
            }
            TW behaviour = gobj.AddComponent<TW>();
            return behaviour;
        } 
}
}
