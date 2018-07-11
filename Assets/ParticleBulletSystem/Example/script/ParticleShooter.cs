using UnityEngine;
using System.Collections;

namespace ParticleBulletSystem
{
    public class ParticleShooter : MonoBehaviour
    {
        public shotType type;
        public ShotParameter parameter;
        public float repeatDelay = 1;
        public float startDeley = 0.5f;
        [Tooltip("auto aiming to player")]
        public bool aim;
        // Use this for initialization
        void Start()
        {
#if UNITY_EDITOR
            if (parameter.number < 0 || parameter.number > ParticleManager.manager.particle.Length)
            {
                Debug.Log(gameObject.name + this + "ParticleManager's particle is out of length");
                return;
            }
#endif
            StartCoroutine(DoShot());
        }

        IEnumerator DoShot()
        {
            yield return new WaitForSeconds(startDeley);

            Transform tr = transform;
            GameObject target = GameObject.FindGameObjectWithTag("Player");
            while (true)
            {
                if(aim && target != null)
                {
                    Vector3 vec = (target.transform.position - tr.position).normalized;
                    ParticleManager.manager.ShotSelector(type, parameter, tr.position, vec, Vector3.up);
                }
                else
                {
                    ParticleManager.manager.ShotSelector(type, parameter, tr);
                }
                
                
                yield return new WaitForSeconds(repeatDelay);
            }
        }
    }
}