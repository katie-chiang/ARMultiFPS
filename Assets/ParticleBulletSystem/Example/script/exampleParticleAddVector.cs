using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace ParticleBulletSystem
{
    public class exampleParticleAddVector : MonoBehaviour
    {
        public Slider slider;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(2))
            {
                int length = ParticleManager.manager.particle.Length;
                int i;
                Vector3 vec = transform.forward * slider.value * Time.deltaTime;
                for (i = 0; i < length; i++)
                {
                    ParticleManager.manager.Vector_AddVelocity(i, vec);
                }
                slider.value--;
            }
            else
            {
                slider.value++;
            }
        }
    }
}