using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace ParticleBulletSystem
{
    public class exampleTPS_Controller : MonoBehaviour
    {

        public float moveSpeed = 3;
        public int health = 1000;
        public Slider healthSlider;
        private Rigidbody rigi;

        private int previousHealth;

        // Use this for initialization
        void Start()
        {
            healthSlider.maxValue = health;
            rigi = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            /*if(!cursorView){
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }*/

            Transform cameraTransform = Camera.main.transform;
            Vector3 forward = cameraTransform.TransformDirection(Vector3.forward);
            forward.y = 0;
            forward = forward.normalized;
            Vector3 right = new Vector3(forward.z, 0, -forward.x);
            float v = Input.GetAxisRaw("Vertical");
            float h = Input.GetAxisRaw("Horizontal");

            Vector3 targetDirection;
            targetDirection = (h * right + v * forward) * moveSpeed;
            if (Input.GetButtonDown("Jump"))
            {
                targetDirection.y = 10;
            }
            else
            {
                targetDirection.y = rigi.velocity.y;
            }
            rigi.velocity = targetDirection;

            transform.rotation = Quaternion.LookRotation(forward);
            if (health != previousHealth)
            {
                healthSlider.value = health;

                if (health <= 0)
                {
                    GameObject.FindWithTag("GameController").SendMessage("Dead", SendMessageOptions.DontRequireReceiver);
                }
            }
            previousHealth = health;
        }

        public void Damage()
        {
            health--;
        }
    }
}