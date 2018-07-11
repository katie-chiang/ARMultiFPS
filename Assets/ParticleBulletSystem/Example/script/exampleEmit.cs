using UnityEngine;
using System.Collections;

namespace ParticleBulletSystem
{
    public class exampleEmit : MonoBehaviour
    {
        [Tooltip("Number for reference in particlemanager the variable particle" +
            "\nParticle”をParticleManagerで参照するための番号.")]
        public int number;
        [Tooltip("The number of particles that Emit" +
            "Emitするパーティクルの数")]
        public int count;
        [Tooltip("It will specify the time interval of repetition." +
            "\n繰り返しの時間間隔を指定します.")]
        public float repeatTimer;
        private float timerCount;

        void Update()
        {
            timerCount -= Time.deltaTime;
            if (timerCount <= 0)
            {
                Shot();
                timerCount = repeatTimer;
            }
        }
        void Shot()
        {
            ParticleManager.manager.Emit(number, count);
        }
        public void SetRepeatTime(float c)
        {
            repeatTimer = c;
        }
        public void SetCount(float c)
        {
            count = (int)c;
        }
    }
}