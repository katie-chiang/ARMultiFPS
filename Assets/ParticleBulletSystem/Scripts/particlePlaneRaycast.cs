using UnityEngine;
using System.Collections;

namespace ParticleBulletSystem
{
    public class particlePlaneRaycast : MonoBehaviour
    {
        [Tooltip("Number for reference in particlemanager the variable particle\nParticle”をParticleManagerで参照するための番号.")]
        public int number;
        [Tooltip("This bullet of destination, it will show the sight.. If you specify this, Number is ignored." +
            "\nこの弾の行き先に, 照準を表示します. これを直接指定している場合, Numberは無視される.")]
        public ParticleSystem particle;
        private ParticleSystem.Particle[] particles;
        [Tooltip("ParticleSystem to use as the target site.\nターゲットサイトのParticleSystem.")]
        public ParticleSystem hitParticle;
        [Tooltip("To be used in PlaneRaycast. Plane spread up and right of Transform" +
            "\nPlaneRaycastで使用する. このTransformのrightとupに広がる平面で判定.")]
        public Transform planeObject;
        // Use this for initialization
        void Start()
        {
            if (particle == null)
            {
                particle = ParticleManager.manager.particle[number];
            }
            particles = new ParticleSystem.Particle[particle.main.maxParticles];
            if (planeObject == null)
            {
                planeObject = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }

        // Update is called once per frame
        void Update()
        {
            int length = particle.GetParticles(particles);
            hitParticle.Clear();
            ParticleSystem.EmitParams em = ParticleManager.manager.emitParamsDefault;
            Plane plane = new Plane(planeObject.forward, planeObject.position);

            for (int i = 0; i < length; i++)
            {
                Ray ray = new Ray(particles[i].position, particles[i].velocity);
                float rayDistance;
                if (plane.Raycast(ray, out rayDistance))
                {
                    em.position = ray.GetPoint(rayDistance);
                    em.velocity = Vector3.zero;
                    em.startLifetime = 1.0f;
                    em.startSize = particles[i].GetCurrentSize(particle);

                    hitParticle.Emit(em, 1);
                }
            }
        }
    }
}