using UnityEngine;
using System.Collections;

namespace ParticleBulletSystem
{
    public class exampleRotate : MonoBehaviour
    {
        public int number = 0;
        public float rotationSpeed = 200;
        public Vector3 rotationAxis = Vector3.up;

        void LateUpdate()
        {
            ParticleManager.manager.Vector_Rotate(number, rotationSpeed * Time.deltaTime, rotationAxis);
        }
    }
}