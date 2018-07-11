using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace ParticleBulletSystem
{
    public class exampleEnemyAI_Air : MonoBehaviour
    {

        private int health = 900;
        public Slider healthSlider;
        public Transform target;
        public int shotGunNumber;
        public int reflectionLaserNumber;
        public int clusterNumber1;
        public int missileNumber1;
        public int clusterNumber2;
        public int missileNumber2;
        public Transform muzzule;
        private Animator anim;
        private int previousHealth;
        void Start()
        {
            previousHealth = health;
            anim = GetComponent<Animator>();
            healthSlider.gameObject.SetActive(true);
            healthSlider.maxValue = health;
            if (target == null)
                target = GameObject.FindWithTag("Player").transform;
            StartCoroutine(MyUpdate());
        }
        void Update()
        {
            ParticleManager.manager.Vector_RotateTowards(missileNumber1, 0.02f, target.position);
            ParticleManager.manager.Vector_AddSpeed(missileNumber1, 5 * Time.deltaTime);

            ParticleManager.manager.Vector_RotateTowards(missileNumber2, 0.05f, target.position);
            ParticleManager.manager.Vector_AddSpeed(missileNumber2, 30 * Time.deltaTime);

            if (health != previousHealth)
            {
                healthSlider.value = health;

                if (health <= 0)
                {
                    ParticleManager.manager.ClearAllParticle();
                    gameObject.SetActive(false);
                    GameObject.FindWithTag("GameController").SendMessage("Clear", SendMessageOptions.DontRequireReceiver);
                    ParticleManager.manager.Emit(8, 1, transform.position);
                }
            }
            previousHealth = health;
        }
        IEnumerator MyUpdate()
        {
            anim.speed = 0.3f;
            WaitForSeconds wait = new WaitForSeconds(1);
            while (health > 600)
            {
                wait = new WaitForSeconds(1);
                for (int i = 0; i < 3; i++)
                {
                    Shot1();
                    yield return wait;
                }

                wait = new WaitForSeconds(0.3f);
                for (int i = 0; i < 7; i++)
                {
                    Shot1();
                    yield return wait;
                }

                wait = new WaitForSeconds(0.01f);
                for (int i = 0; i < 100; i++)
                {
                    Shot2();
                    yield return wait;
                }
                yield return new WaitForSeconds(1);
            }
            anim.speed = 0.5f;
            while (health > 300)
            {
                wait = new WaitForSeconds(0.5f);
                for (int i = 0; i < 10; i++)
                {
                    Laser();
                    yield return wait;
                }

                wait = new WaitForSeconds(0.1f);
                for (int i = 0; i < 10; i++)
                {
                    Laser();
                    yield return wait;
                }
                yield return new WaitForSeconds(1);
            }
            anim.speed = 1;
            while (health > 0)
            {
                wait = new WaitForSeconds(0.5f);
                for (int i = 0; i < 5; i++)
                {
                    ClusterMissile();
                    yield return wait;
                }

                wait = new WaitForSeconds(0.1f);
                for (int i = 0; i < 10; i++)
                {
                    ClusterMissileRandom();
                    yield return wait;
                }
                yield return new WaitForSeconds(1);
            }
        }
        void Shot1()
        {
            transform.LookAt(target);
            ParticleManager.manager.Emit(shotGunNumber, 20, muzzule.position, muzzule.rotation);
            Transform pt = ParticleManager.manager.particle[shotGunNumber].transform;
            pt.position = Vector3.zero;
            pt.eulerAngles = Vector3.zero;
        }
        void Shot2()
        {
            transform.rotation = Random.rotation;
            ParticleManager.manager.Emit(shotGunNumber, 20, muzzule.position, muzzule.rotation);
            Transform pt = ParticleManager.manager.particle[shotGunNumber].transform;
            pt.position = Vector3.zero;
            pt.eulerAngles = Vector3.zero;
        }
        void Laser()
        {
            transform.LookAt(target);
            ParticleManager.manager.Emit(reflectionLaserNumber, 3, muzzule.position, muzzule.rotation);
            Transform pt = ParticleManager.manager.particle[reflectionLaserNumber].transform;
            pt.position = Vector3.zero;
            pt.eulerAngles = Vector3.zero;
        }
        void ClusterMissile()
        {
            transform.LookAt(target);
            ParticleManager.manager.Emit(clusterNumber1, 1, muzzule.position, muzzule.rotation);
            Transform pt = ParticleManager.manager.particle[clusterNumber1].transform;
            pt.position = Vector3.zero;
            pt.eulerAngles = Vector3.zero;
        }
        void ClusterMissileRandom()
        {
            transform.rotation = Random.rotation;
            ParticleManager.manager.Emit(clusterNumber2, 1, muzzule.position, muzzule.rotation);
            Transform pt = ParticleManager.manager.particle[clusterNumber2].transform;
            pt.position = Vector3.zero;
            pt.eulerAngles = Vector3.zero;
        }

        void Damage()
        {
            health--;
        }
    }
}