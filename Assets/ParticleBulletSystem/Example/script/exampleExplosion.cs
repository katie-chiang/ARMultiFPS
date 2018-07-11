using UnityEngine;
using System.Collections;
namespace ParticleBulletSystem
{
    public class exampleExplosion : MonoBehaviour
    {
        public int particleNumber;
        public int emitCount;
        public float delay;
        public Transform emitter;

        void Reset()
        {
            emitter = transform;
        }
        
        void Start()
        {
            Invoke("Emit", delay);
        }
        
        void Emit()
        {
            ParticleManager.manager.Emit(particleNumber, emitCount, emitter.position);
        }
    }
}