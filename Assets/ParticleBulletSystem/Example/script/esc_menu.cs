using UnityEngine;
using System.Collections;
namespace ParticleBulletSystem
{
    public class esc_menu : MonoBehaviour
    {
        [Tooltip("It's menuUI\nIt opens in the ESC key.\n")]
        public GameObject menu;
        private bool active = false;
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                active = !active;
                menu.SetActive(active);
            }
        }
    }
}