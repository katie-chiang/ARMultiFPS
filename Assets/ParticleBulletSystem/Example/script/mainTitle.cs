using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace ParticleBulletSystem
{
    public class mainTitle : MonoBehaviour
    {
        public bool inMainTitle = false;
        public bool cursorView_Awake = false;
        public bool cursorView_OnEnable = true;
        public bool cursorView_OnDisable = false;
        public CursorLockMode clm_Awake = CursorLockMode.Locked;
        public CursorLockMode clm_OnEnable = CursorLockMode.None;
        public CursorLockMode clm_OnDisable = CursorLockMode.Locked;

        void Awake()
        {
            Cursor.visible = cursorView_Awake;
            Cursor.lockState = clm_Awake;
            if (!inMainTitle)
            {
                gameObject.SetActive(false);
            }
        }
        void OnEnable()
        {
            Cursor.visible = cursorView_OnEnable;
            Cursor.lockState = clm_OnEnable;
        }
        void OnDisable()
        {
            Cursor.visible = cursorView_OnDisable;
            Cursor.lockState = clm_OnDisable;
        }
        public void Demo1()
        {
            SceneManager.LoadScene("demo1");
        }
        public void Demo2()
        {
            SceneManager.LoadScene("demo2");
        }
        public void Demo3()
        {
            SceneManager.LoadScene("demo3");
        }
        public void Demo4()
        {
            SceneManager.LoadScene("demo4");
        }
    }
}