using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ParticleBulletSystem
{
    public class ShowFps : MonoBehaviour
    {
        GUIText gui;

        float updateInterval = 1;
        float lastInterval;
        int frames;

        // Use this for initialization
        void Start()
        {
            lastInterval = Time.realtimeSinceStartup;
            frames = 0;
        }

        void OnDisable()
        {
            if (gui)
                DestroyImmediate(gui.gameObject);
        }

        // Update is called once per frame
        void Update()
        {
#if !UNITY_FLASH
            ++frames;
            float timeNow = Time.realtimeSinceStartup;
            if (timeNow > lastInterval + updateInterval)
            {
                if (!gui)
                {
                    GameObject go = new GameObject("FPS Display");
                    go.AddComponent<GUIText>();

                    go.hideFlags = HideFlags.HideAndDontSave;
                    go.transform.position = Vector3.zero;
                    gui = go.GetComponent< GUIText > ();
                    gui.pixelOffset = new Vector2(5, 55);
                }
                float fps = frames / (timeNow - lastInterval);
                float ms = 1000.0f / Mathf.Max(fps, 0.00001f);
                gui.text = ms.ToString("f1") + "ms " + fps.ToString("f2") + "FPS";
                frames = 0;
                lastInterval = timeNow;
            }
#endif
        }
    }
}