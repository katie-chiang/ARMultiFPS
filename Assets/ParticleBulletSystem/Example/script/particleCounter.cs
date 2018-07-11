using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace ParticleBulletSystem
{
    public class particleCounter : MonoBehaviour
    {
        public int count;
        public string counterString = "BulletCount";
        public Text counterText;
        public ParticleSystem[] additionParticleSystem;


        // Update is called once per frame
        void Update()
        {
            int length = ParticleManager.manager.particle.Length;
            count = 0;
            int i;
            for (i = 0; i < length; i++)
            {
                count += ParticleManager.manager.particle[i].particleCount;
            }

            length = additionParticleSystem.Length;
            for (i = 0; i < length; i++)
            {
                count += additionParticleSystem[i].particleCount;
            }
            counterText.text = counterString + "  " + count.ToString();
        }
    }
}