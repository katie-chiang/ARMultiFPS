using UnityEngine;
using System.Collections;
using UnityEngine.AI;

namespace ParticleBulletSystem
{
    public class exampleEnemyAI : MonoBehaviour
    {
        NavMeshAgent agent;
        [Tooltip("Moves toward this target." +
            "\nこのターゲットに向かって移動します")]
        public Transform target;
        [Tooltip("Shot ParticleSystem")]
        public int number = 0;
        [Tooltip("the number of Emit")]
        public int count = 20;
        [Tooltip("Emit Position")]
        public Transform muzzule;
        public float repeatTimer = 1;
        private float timerCount = 0;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            if (target == null)
                target = GameObject.FindWithTag("Player").transform;
        }

        void Update()
        {
            agent.destination = target.position;
            timerCount -= Time.deltaTime;
            if (timerCount <= 0)
            {
                Shot();
                timerCount = repeatTimer;
            }
        }
        void Shot()
        {
            ParticleManager.manager.Emit(number, count, muzzule.position, muzzule.rotation);
            Transform pt = ParticleManager.manager.particle[number].transform;
            pt.position = Vector3.zero;
            pt.eulerAngles = Vector3.zero;
        }
    }
}