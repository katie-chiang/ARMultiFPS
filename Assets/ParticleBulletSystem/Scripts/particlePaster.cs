using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ParticleBulletSystem
{
    public class particlePaster : MonoBehaviour
    {
        [Tooltip("This ParticleSystem is not used for other purposes" +
            "\tこのParticleSystemは,他の用途に使えません")]
        public ParticleSystem particle;
        [Tooltip("deactivate object is remove from list" +
            "\t非アクティブなオブジェクトを削除します")]
        public bool autoRemove;
        private ParticleSystem.Particle[] particles;
        [HideInInspector]
        public List<Transform> others = new List<Transform>();
        private List<GameObject> go = new List<GameObject>();

        void Start()
        {
            particles = new ParticleSystem.Particle[particle.main.maxParticles];
            if (autoRemove)
                StartCoroutine(AutoRemove());
            if (particle == null)
                GetComponent<ParticleSystem>();
            if (particle == null)
                particle = gameObject.AddComponent<ParticleSystem>();
        }
        void LateUpdate()
        {
            int length = particle.GetParticles(particles);
            int diff = others.Count - length;
            for (int j = 0; j < diff; j++)
            {
                particle.Emit(1);
            }
            length = particle.GetParticles(particles);
            for (int i = 0; i < others.Count; i++)
            {
                particles[i].position = others[i].position;
            }
            particle.SetParticles(particles, length);
        }
        //When you add a particle, you can call this method.
        public void Add(Transform tr)
        {
            if (!others.Contains(tr))
            {
                others.Add(tr);
                go.Add(tr.gameObject);
            }
        }
        //When you delete a particle, you can call this method.
        public void Remove(Transform tr)
        {
            if (others.Contains(tr))
            {
                others.Remove(tr);
                go.Remove(tr.gameObject);
            }
        }
        IEnumerator AutoRemove()
        {
            while (true)
            {
                //deactivate object is remove
                for (int k = 0; k < others.Count; k++)
                {
                    if (!go[k].activeSelf)
                    {
                        Remove(others[k]);
                    }
                }
                yield return null;
            }
        }
    }
}