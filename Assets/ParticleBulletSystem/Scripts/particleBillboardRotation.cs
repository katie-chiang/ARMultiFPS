using UnityEngine;
using System.Collections;
namespace ParticleBulletSystem
{
    [RequireComponent(typeof(ParticleSystem))]
    public class particleBillboardRotation : MonoBehaviour
    {
        [Tooltip("Camera used. If you do not set this, MainCamera will be applied automatically." +
            "\n使用するカメラ. これを設定しない場合, 自動でMainCameraが適用されます.")]
        public Transform cam;
        private ParticleSystem particle;
        private ParticleSystem.Particle[] particles;

        // Use this for initialization
        void Start()
        {
            if (cam == null)
            {
                cam = Camera.main.transform;
            }
            particle = GetComponent<ParticleSystem>();
            particles = new ParticleSystem.Particle[particle.main.maxParticles];
        }

        // Update is called once per frame
        void LateUpdate()
        {
            int length = particle.GetParticles(particles);
            double angle;
            Vector3 cross;
            Vector3 up = cam.up;
            for (int i = 0; i < length; i++)
            {
                angle = Vector3.Angle(up, particles[i].velocity);
                cross = Vector3.Cross(up, particles[i].velocity);
                if (cross.y < 0)
                {
                    angle = -angle;
                }
                particles[i].rotation = (float)angle;
            }
            particle.SetParticles(particles, length);
        }
    }
}