using UnityEngine;
using System.Collections;

namespace ParticleBulletSystem
{
    public class exampleEmitGun : MonoBehaviour
    {
        [Tooltip("ShotGun ParticleSystem")]
        public int number = 0;
        [Tooltip("HomingMissile ParticleSystem")]
        public int number2 = 1;
        [Tooltip("ShotGun Emit count")]
        public int count = 20;
        [Tooltip("Emit Position")]
        public Transform muzzule;
        //public Transform targetSight;
        public particlePaster paster;
        private Transform homingTarget;
        private Collider previousHit;
        // Update is called once per frame
        void Update()
        {
            transform.rotation = Camera.main.transform.rotation;
            if (Input.GetMouseButtonDown(0))
            {
                ParticleManager.manager.Emit(number, count, muzzule.position, muzzule.rotation);
                Transform pt = ParticleManager.manager.particle[number].transform;
                pt.position = Vector3.zero;
                pt.eulerAngles = Vector3.zero;
            }
            if (Input.GetMouseButton(1))
            {
                RaycastHit hit;
                Ray ray = new Ray(muzzule.position, muzzule.forward);
                if (Physics.SphereCast(ray, 3, out hit))
                {
                    if (previousHit != hit.collider)
                    {
                        previousHit = hit.collider;
                        if (hit.collider.GetComponent<Rigidbody>() != null)
                        {
                            paster.Remove(homingTarget);
                            homingTarget = hit.collider.transform;

                            //add to particlePaster for lockOn sight
                            paster.Add(homingTarget);
                        }
                    }
                }

                ParticleManager.manager.Emit(number2, 1, muzzule.position, muzzule.rotation);
                Transform pt = ParticleManager.manager.particle[number2].transform;
                pt.position = Vector3.zero;
                pt.eulerAngles = Vector3.zero;
            }
            if (homingTarget != null)
            {
                ParticleManager.manager.Vector_RotateTowards(number2, 0.1f, homingTarget.position);
                ParticleManager.manager.Vector_AddSpeed(number2, 10 * Time.deltaTime);

                //targetSight.position = homingTarget.position;
                //targetSight.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
            }
        }
        void LateUpdate()
        {
            transform.rotation = Camera.main.transform.rotation;
        }
    }
}