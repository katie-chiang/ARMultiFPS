using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace ParticleBulletSystem
{
    public class exampleVectorController : MonoBehaviour
    {
        public Transform Target;
        public Slider number;
        public Dropdown type;
        public Slider speed;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            int num = (int)number.value;
            switch ((int)type.value)
            {
                case 0:
                    break;
                case 1:
                    ParticleManager.manager.Vector_Rotate(num, speed.value * Time.deltaTime);
                    break;
                case 2:
                    ParticleManager.manager.Vector_RotateTowards(num, speed.value / 360, Target.position);
                    break;
                case 3:
                    ParticleManager.manager.Vector_AddSpeed(num, speed.value * Time.deltaTime);
                    break;
                case 4:
                    ParticleManager.manager.Vector_AddVelocity(num, -Target.position * Time.deltaTime * speed.value);
                    break;
            }
        }
        public void LookPositiion()
        {
            ParticleManager.manager.Vector_LookPosition((int)number.value, Target.position);
        }
        public void llla()
        {
            ParticleManager.manager.Vector_SetVelocity((int)number.value, Target.position);
        }
    }
}