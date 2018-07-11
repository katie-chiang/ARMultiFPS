using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace ParticleBulletSystem
{
    [RequireComponent(typeof(MeshRenderer))]
    public class exampleCharacter : MonoBehaviour
    {
        public Camera cam;
        public int health = 1000;
        [Tooltip("uGUI Text. It will show the health")]
        public Text healthText;
        [Tooltip("Player Collision")]
        public Collider colli;
        [Tooltip("PlayerMaterial")]
        public Material mat1;
        [Tooltip("PlayerMaterial. When the isTrigger")]
        public Material mat2;
        private MeshRenderer rend;
        private Transform tr;
        private int previousHealth;
        // Use this for initialization
        void Start()
        {
            previousHealth = health;
            if (cam == null)
            {
                cam = Camera.main;
            }
            rend = GetComponent<MeshRenderer>();
            tr = GetComponent<Transform>();
            healthText.text = "HEALTH  " + health.ToString();
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 mp = Input.mousePosition;
            mp.z = cam.transform.position.y;

            transform.position = cam.ScreenToWorldPoint(mp);

            if (health != previousHealth)
                healthText.text = "HEALTH  " + health.ToString();
            previousHealth = health;

            if (Input.GetMouseButtonDown(0))
            {
                colli.isTrigger = true;
                rend.material = mat2;
            }
            if (Input.GetMouseButtonUp(0))
            {
                colli.isTrigger = false;
                rend.material = mat1;
            }

            if (Input.GetMouseButtonDown(1))
            {
                tr.localScale *= 2;
            }
            if (Input.GetMouseButtonUp(1))
            {
                tr.localScale /= 2;
            }
        }

        public void Damage(float damage)
        {
            health -= (int)damage;
        }
    }
}