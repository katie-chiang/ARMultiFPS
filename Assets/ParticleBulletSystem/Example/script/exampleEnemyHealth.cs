using UnityEngine;
using System.Collections;

namespace ParticleBulletSystem
{
    public class exampleEnemyHealth : MonoBehaviour
    {
        public int health = 100;
        public string message = "CountUp";
        [Tooltip("When the health becomes 0, run the sendmessage" +
            "\nhelathが0になると, SendMassageを実行")]
        public GameObject messageTaret;
        // Use this for initialization
        void Start()
        {
            if (messageTaret == null)
            {
                messageTaret = GameObject.FindWithTag("GameController");
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (health <= 0)
            {
                messageTaret.SendMessage(message, SendMessageOptions.DontRequireReceiver);
                gameObject.SetActive(false);
            }
        }
        void Damage(float power)
        {
            health -= (int)power;
        }
    }
}