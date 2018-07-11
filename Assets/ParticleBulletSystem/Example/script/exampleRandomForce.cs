using UnityEngine;
using System.Collections;

namespace ParticleBulletSystem
{
    public class exampleRandomForce : MonoBehaviour
    {
        public Rigidbody rb;

        void OnEnable()
        {
            float x = Random.Range(-1, 1);
            float y = Random.Range(-1, 1);
            float z = Random.Range(-1, 1);

            rb.velocity = new Vector3(x, y, z) * 10;
        }
    }
}