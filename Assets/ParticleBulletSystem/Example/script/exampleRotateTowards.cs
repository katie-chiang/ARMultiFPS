using UnityEngine;
using System.Collections;

namespace ParticleBulletSystem
{
    public class exampleRotateTowards : MonoBehaviour
    {
        public int number = 0;
        public float rotationSpeed = 0.01f;
        public Transform target;

        void LateUpdate()
        {
            ParticleManager.manager.Vector_RotateTowards(number, rotationSpeed, target.position);
        }
    }
}