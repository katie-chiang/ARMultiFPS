using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ParticleBulletSystem
{
    public class particlePaster_LifeTime : MonoBehaviour
    {
        [Tooltip("This ParticleSystem is not used for other purposes" +
            "\tこのParticleSystemは,他の用途に使えません")]
        public ParticleSystem particle;
        private ParticleSystem.Particle[] particles;
        [HideInInspector]
        public List<Transform> others = new List<Transform>();
        private List<float> lifeTime = new List<float>();

        void Start()
        {
            particles = new ParticleSystem.Particle[particle.main.maxParticles];
            if (particle == null)
                GetComponent<ParticleSystem>();
            if (particle == null)
                particle = gameObject.AddComponent<ParticleSystem>();
        }
        void LateUpdate()
        {
            for (int j = 0; j < lifeTime.Count; j++)
            {
                lifeTime[j] -= Time.deltaTime;
            }
            int length = particle.GetParticles(particles);
            for (int i = 0; i < others.Count; i++)
            {
                if (lifeTime[i] <= 0.2f)
                {
                    others.Remove(others[i]);
                    lifeTime.Remove(lifeTime[i]);
                }
                else
                {
                    particles[i].position = others[i].position;
                    particles[i].remainingLifetime = lifeTime[i];
                }
            }
            particle.SetParticles(particles, length);
        }
        //When you add a particle, you can call this method.
        public void Add(Transform tr)
        {
            if (others.Contains(tr))
            {
                int num = others.IndexOf(tr);
                particles[num].remainingLifetime = particle.main.startLifetimeMultiplier;
            }
            else
            {
                others.Add(tr);
                lifeTime.Add(particle.main.startLifetimeMultiplier);
                //particle.Emit(1);
                ParticleManager.manager.Emit_OneShot(particle, tr, 0, particle.main.startSizeMultiplier);
            }
        }
        //When you delete a particle, you can call this method.
        public void Remove(Transform tr)
        {
            if (others.Contains(tr))
                others.Remove(tr);
        }
    }
}