using UnityEngine;
using System.Collections;

namespace ParticleBulletSystem
{
    public class exampleParticleLookat : MonoBehaviour
    {
        private ParticleSystem particle;
        private ParticleSystem.Particle[] particles;
        private Transform target;
        // Use this for initialization
        void Start()
        {
            target = GameObject.FindWithTag("Player").transform;
            particle = GetComponent<ParticleSystem>();
            particles = new ParticleSystem.Particle[particle.main.maxParticles];
        }

        // Update is called once per frame
        void Update()
        {
            ParticleManager.manager.Vector_LookPosition(particle, target.position, particles);
        }
    }
}