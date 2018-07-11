using UnityEngine;
using System.Collections;

namespace ParticleBulletSystem
{
    public class particleCheckSphere : MonoBehaviour
    {
        [Tooltip("It is target to damage")]
        public Transform target;
        public LayerMask layer;
        [Tooltip("It is a collision size ratio of the particle")]
        public float radiusMultiply = 0.5f;
        [Tooltip("send message")]
        public string message = "Damage";
        private ParticleSystem particle;
        private ParticleSystem.Particle[] particles;
        private float power;
        // Use this for initialization
        void Start()
        {
            particle = GetComponent<ParticleSystem>();
            particles = new ParticleSystem.Particle[particle.main.maxParticles];
            power = ParticleManager.manager.GetPower(ParticleManager.manager.GetNumber(particle));
            if (target == null)
                target = GameObject.FindWithTag("Player").transform;
        }

        // Update is called once per frame
        void LateUpdate()
        {
            int length = particle.GetParticles(particles);
            for (int i = 0; i < length; i++)
            {
                Vector3 pos = particles[i].position;
                //Vector3 vec = particles[i].velocity;
                float size = particles[i].GetCurrentSize(particle) * radiusMultiply;
                if (Physics.CheckSphere(pos, size / 2, layer, QueryTriggerInteraction.Ignore))
                {
                    //if(Physics.SphereCast(pos,size/2,vec,out hit,vec.magnitude*time,layer,QueryTriggerInteraction.Ignore)){
                    target.SendMessage(message, power, SendMessageOptions.DontRequireReceiver);
                    particles[i].remainingLifetime = 0;
                }
            }
            particle.SetParticles(particles, length);
        }
    }
}