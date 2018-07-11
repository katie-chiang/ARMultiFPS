using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
namespace ParticleBulletSystem
{
    public class exampleLevelController : MonoBehaviour
    {
        private int count;
        public GameObject object1;
        public GameObject object2;
        public GameObject ClearUI;
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
                RestartScene();
        }
        void CountUp()
        {
            count++;
            switch (count)
            {
                case 3:
                    object1.SetActive(true);
                    break;
                case 6:
                    object2.SetActive(true);
                    break;
            }
        }
        void Clear()
        {
            ClearUI.SetActive(true);
        }
        void Dead()
        {
            RestartScene();
        }
        void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}