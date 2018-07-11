using UnityEngine;
using System.Collections;

namespace ParticleBulletSystem
{
    public class particleLimit2D : MonoBehaviour
    {
        public Camera cam;
        public float depth = 15;
        private ParticleSystem particle;
        private ParticleSystem.Particle[] particles;
        // Use this for initialization
        void Start()
        {
            particle = GetComponent<ParticleSystem>();
            particles = new ParticleSystem.Particle[particle.main.maxParticles];
        }

        // Update is called once per frame
        void LateUpdate()
        {
            int length = particle.GetParticles(particles);
            for (int i = 0; i < length; i++)
            {
                Vector3 pos = cam.WorldToViewportPoint(particles[i].position);
                pos.z = depth;
                pos = cam.ViewportToWorldPoint(pos);
                particles[i].position = pos;
            }
            particle.SetParticles(particles, length);
        }
    }
}