using UnityEngine;
using System.Collections;

namespace ParticleBulletSystem
{
    public class exampleMissileLauncher : MonoBehaviour
    {
        public GameObject prefab;
        public Transform launcher;
        public particlePaster missilePaster;
        public particlePaster sightPaster;
        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject go = Instantiate(prefab, launcher.position, launcher.rotation) as GameObject;
                go.SendMessage("SetData", this);
            }
        }
        void LateUpdate()
        {
            ParticleManager.manager.particle[0].transform.rotation = Quaternion.identity;
        }
    }
}