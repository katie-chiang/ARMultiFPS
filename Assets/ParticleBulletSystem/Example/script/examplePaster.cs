using UnityEngine;
using System.Collections;

namespace ParticleBulletSystem
{
    public class examplePaster : MonoBehaviour
    {
        public particlePaster paster;
        // Use this for initialization

        void OnBecameVisible()
        {
            paster.Add(transform);
        }
        void OnBecameInvisible()
        {
            paster.Remove(transform);
        }
    }
}