using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ParticleBulletSystem
{
    public class ReceiveParticle : MonoBehaviour
    {
        [Tooltip("\nWhen ReceiveParticle to attach the game object is to hit, it will send a Message to this SendMessageTarget." +
            "\nReceiveParticleをアタッチしたゲームオブジェクトが被弾すると, このSendMessageTargetにMessageをおくります.")]
        public GameObject sendMessageTarget;
        [Tooltip("String to be used in the sendmessage" +
            "\nsendmessageで使用する String")]
        public string message = "Damage";
        public bool receiveForce = false;
        private Rigidbody rigi;
        //private ParticleCollisionEvent[] collisionEvents = new ParticleCollisionEvent[16];
        List<ParticleCollisionEvent> collisionEvents;
        void Awake()
        {
            if (sendMessageTarget == null)
            {
                sendMessageTarget = gameObject;
            }
            rigi = sendMessageTarget.GetComponent<Rigidbody>();
            collisionEvents = new List<ParticleCollisionEvent>();
        }
        void OnParticleCollision(GameObject other)
        {
            ParticleSystem particleSystem;
            particleSystem = other.GetComponent<ParticleSystem>();

            int safeLength = particleSystem.GetSafeCollisionEventSize();
            if (collisionEvents.Count < safeLength)
                collisionEvents = new List<ParticleCollisionEvent>(safeLength);

            float power = 1;
            if (ParticleManager.manager.particleObject.Contains(other))
            {
                int num = ParticleManager.manager.particleObject.IndexOf(other);
                power = ParticleManager.manager.GetPower(num);
            }

            int numCollisionEvents = particleSystem.GetCollisionEvents(gameObject, collisionEvents);
            int i = 0;
            Vector3 force = Vector3.zero;
            if (receiveForce)
            {
                while (i < numCollisionEvents)
                {
                    force += collisionEvents[i].velocity;
                    i++;
                }
                rigi.AddForce(force * power);
            }

            sendMessageTarget.SendMessage(message, power * numCollisionEvents, SendMessageOptions.DontRequireReceiver);
        }
    }
}