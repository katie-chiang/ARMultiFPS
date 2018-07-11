using UnityEngine;
using System.Collections;

namespace ParticleBulletSystem
{
    public class exampleMissile : MonoBehaviour
    {
        public Rigidbody rb;
        public Transform tr;
        public float speed = 20;
        public float rotateSpeed = 1;
        public float LifeTime = 3;

        public int smokeParticle;
        public int explosionParticle = 1;

        private Transform target;
        private particlePaster missilePaster;
        private particlePaster sightPaster;

        void OnEnable()
        {
            rb.velocity = tr.forward * speed;
            Invoke("Death", LifeTime);
        }

        //rotate
        void Update()
        {
            ParticleManager.manager.Emit(smokeParticle, 1, tr.position, Quaternion.LookRotation(-rb.velocity));
            if (target != null)
                rb.velocity = Vector3.RotateTowards(rb.velocity, target.position - rb.position, rotateSpeed, 0.0f);

        }
        void OnTriggerEnter(Collider other)
        {
            if (other.tag != "Player")
            {
                //other.SendMessage("Damage",SendMessageOptions.DontRequireReceiver);
                Death();
            }
        }

        //Remove before Destroy
        //Or use AutoRemove
        void Death()
        {
            missilePaster.Remove(tr);
            ParticleManager.manager.Emit(explosionParticle, 1, tr.position);
            Destroy(gameObject);
        }

        //set up after receive sendmessage
        public void SetData(exampleMissileLauncher launcher)
        {
            missilePaster = launcher.missilePaster;
            sightPaster = launcher.sightPaster;

            missilePaster.Add(tr);
            int randomIndex = Random.Range(0, sightPaster.others.Count);
            if (sightPaster.others.Count > 0)
            {
                target = sightPaster.others[randomIndex];
                sightPaster.Add(target);
            }
        }
    }
}