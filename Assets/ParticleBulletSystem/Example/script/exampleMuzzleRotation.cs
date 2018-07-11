using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace ParticleBulletSystem
{
    public class exampleMuzzleRotation : MonoBehaviour
    {
        [Tooltip("Rotate muzzle by value" +
            "\nvalueにより, muzzleを回転")]
        public Slider rotate;
        [Tooltip("muzzle is oriented to the target" +
            "\nmuzzuleがターゲットに向きます(自機狙い)")]
        public Toggle lookat;
        [Tooltip("Particles to emit Transform" +
            "\nパーティクルを発射するTransform")]
        public Transform muzzule;
        public Transform target;

        // Update is called once per frame
        void Update()
        {
            muzzule.Rotate(new Vector3(0, rotate.value * Time.deltaTime, 0));

            if (lookat.isOn)
                muzzule.LookAt(target);
        }
    }
}