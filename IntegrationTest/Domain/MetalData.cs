using UnityEngine;

namespace Foreman.Testing.IntegrationTest.Domain
{
    public class MetalData : MonoBehaviour, CarriableItem
    {
        public string Name  = "Gold";
        public int Value    = 30;

        [SerializeField]
        private float _weight = 70f;
        public float Weight { get { return _weight; } }
    }
}
