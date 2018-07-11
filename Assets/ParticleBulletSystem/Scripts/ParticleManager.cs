using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace ParticleBulletSystem
{
    public enum shotType
    {
        OneShot,
        cycle,
        squareShot,
        triangleShot,
        triangleSpread,
        ringShot,
        multiSpeed,
        multiWay
    }
    [System.Serializable]
    public class ShotParameter
    {
        public int number;
        public float speed = 30;
        public float speedRate = 0.1f;
        public float size = 0.5f;
        public float sizeRate = 0;
        public float figureSize = 30;
        public float lifeTime = 1;
        public int rows = 5;
        public int cols = 1;
    }
    public class ParticleManager : MonoBehaviour
    {
        public static ParticleManager manager;

        [Tooltip("Previously ParticleSystem by storing, you can use.\nこれに, あらかじめParticleSystemを格納して, 使用します.")]
        public ParticleSystem[] particle;
        public ParticleSystem.Particle[][] particles;
        [Tooltip("Attack Strength.\n攻撃力.")]
        public float[] power;
        [HideInInspector]
        public List<GameObject> particleObject;
        public ParticleSystem.EmitParams emitParamsDefault;
        [HideInInspector]
        public Transform shotTransform;

        void Awake()
        {
            manager = gameObject.GetComponent<ParticleManager>();

            int length = particle.Length;

            particles = new ParticleSystem.Particle[length][];
            int i = 0;
            for (i = 0; i < length; i++)
            {
                if (particle[i] == null)
                {
                    Debug.Log("Particle" + i + " is null");
                    particle[i] = new GameObject("Particle" + i).AddComponent<ParticleSystem>();
                }
                particles[i] = new ParticleSystem.Particle[particle[i].main.maxParticles];
            }
            shotTransform = new GameObject("shotTransform").transform;

            particleObject = new List<GameObject>(new GameObject[length]);
            for (i = 0; i < length; i++)
            {
                particleObject[i] = manager.particle[i].gameObject;
            }

            if (power.Length < particle.Length)
            {
                power = new float[particle.Length];
                Debug.Log("Require add size in ParticleManager's power variable.\npower's size is the need greater than or equal to the particle's size.");
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------
        public void Emit(int number, int count)
        {
            ParticleSystem par = particle[number];
            par.Emit(count);
        }
        public void Emit(ParticleSystem par, int count)
        {
            par.Emit(count);
        }
        public void Emit(int number, int count, Vector3 position)
        {
            ParticleSystem par = particle[number];
            par.transform.position = position;
            par.Emit(count);
        }
        public void Emit(ParticleSystem par, int count, Vector3 position)
        {
            par.transform.position = position;
            par.Emit(count);
        }
        public void Emit(int number, int count, Quaternion rotation)
        {
            ParticleSystem par = particle[number];
            Transform tr = par.transform;
            tr.rotation = rotation;
            par.Emit(count);
        }
        public void Emit(ParticleSystem par, int count, Quaternion rotation)
        {
            Transform tr = par.transform;
            tr.rotation = rotation;
            par.Emit(count);
        }
        public void Emit(int number, int count, Vector3 position, Quaternion rotation)
        {
            ParticleSystem par = particle[number];
            Transform tr = par.transform;
            tr.position = position;
            tr.rotation = rotation;
            par.Emit(count);
        }
        public void Emit(ParticleSystem par, int count, Vector3 position, Quaternion rotation)
        {
            Transform tr = par.transform;
            tr.position = position;
            tr.rotation = rotation;
            par.Emit(count);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        public void Emit_OneShot(int number, Transform tr, float speed, float size)
        {
            ParticleSystem par = particle[number];
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.position = tr.position;
            em.velocity = tr.forward * speed;
            em.startSize = size;
            par.Emit(em, 1);
        }
        public void Emit_OneShot(int number, Vector3 position, Vector3 forward, float speed, float size)
        {
            ParticleSystem par = particle[number];
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.position = position;
            em.velocity = forward * speed;
            em.startSize = size;
            par.Emit(em, 1);
        }
        public void Emit_OneShot(ParticleSystem par, Transform tr, float speed, float size)
        {
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.position = tr.position;
            em.velocity = tr.forward * speed;
            em.startSize = size;
            par.Emit(em, 1);
        }
        public void Emit_OneShot(ParticleSystem par, Vector3 position, Vector3 forward, float speed, float size)
        {
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.position = position;
            em.velocity = forward * speed;
            em.startSize = size;
            par.Emit(em, 1);
        }
        public void Emit_MultiSpeed(int number, Transform tr, float speed, float speedRate, float size, float sizeRate, float lifetime, int rows)
        {
            ParticleSystem par = particle[number];
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startSize = size;
            em.startLifetime = lifetime;
            float sp = speed;
            for (int i = 0; i < rows; i++)
            {
                sp += speed * speedRate;

                em.position = tr.position;
                em.velocity = tr.forward * sp;
                em.startSize += size * sizeRate;
                par.Emit(em, 1);
            }
        }
        public void Emit_MultiSpeed(int number, Vector3 position, Vector3 forward, float speed, float speedRate, float size, float sizeRate, float lifetime, int rows)
        {
            ParticleSystem par = particle[number];
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startSize = size;
            em.startLifetime = lifetime;
            float sp = speed;
            for (int i = 0; i < rows; i++)
            {
                sp += speed * speedRate;

                em.position = position;
                em.velocity = forward * sp;
                em.startSize += size * sizeRate;
                par.Emit(em, 1);
            }
        }
        public void Emit_MultiSpeed(ParticleSystem par, Transform tr, float speed, float speedRate, float size, float sizeRate, float lifetime, int rows)
        {
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startSize = size;
            em.startLifetime = lifetime;
            float sp = speed;
            for (int i = 0; i < rows; i++)
            {
                sp += speed * speedRate;

                em.position = tr.position;
                em.velocity = tr.forward * sp;
                em.startSize += size * sizeRate;
                par.Emit(em, 1);
            }
        }
        public void Emit_MultiSpeed(ParticleSystem par, Vector3 position, Vector3 forward, float speed, float speedRate, float size, float sizeRate, float lifetime, int rows)
        {
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startSize = size;
            em.startLifetime = lifetime;
            float sp = speed;
            for (int i = 0; i < rows; i++)
            {
                sp += speed * speedRate;

                em.position = position;
                em.velocity = forward * sp;
                em.startSize += size * sizeRate;
                par.Emit(em, 1);
            }
        }
        public void Emit_CycleShot(int number, Transform tr, float speed, float speedRate, float size, float sizeRate, float lifetime, int rows, int cols)
        {
            ParticleSystem par = particle[number];
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startLifetime = lifetime;
            for (int i = 0; i < rows; i++)
            {
                float angle = i * Mathf.PI * 2 / rows;
                Vector3 pos = tr.TransformDirection(Mathf.Cos(angle), 0, Mathf.Sin(angle));
                float sp = speed;
                em.startSize = size;
                for (int a = 0; a < cols; a++)
                {
                    sp += speed * speedRate;

                    em.position = tr.position;
                    em.velocity = pos * sp;
                    em.startSize += size * sizeRate;
                    par.Emit(em, 1);
                }
            }
        }
        public void Emit_CycleShot(int number, Vector3 position, Vector3 forward, Vector3 upVec, float speed, float speedRate, float size, float sizeRate, float lifetime, int rows, int cols)
        {
            ParticleSystem par = particle[number];
            ParticleSystem.EmitParams em = emitParamsDefault;

            shotTransform.rotation = Quaternion.LookRotation(forward, upVec);

            em.startLifetime = lifetime;
            for (int i = 0; i < rows; i++)
            {
                float angle = i * Mathf.PI * 2 / rows;
                Vector3 pos = shotTransform.TransformDirection(Mathf.Cos(angle), 0, Mathf.Sin(angle));
                float sp = speed;
                em.startSize = size;
                for (int a = 0; a < cols; a++)
                {
                    sp += speed * speedRate;

                    em.position = position;
                    em.velocity = pos * sp;
                    em.startSize += size * sizeRate;
                    par.Emit(em, 1);
                }
            }
        }
        public void Emit_CycleShot(ParticleSystem par, Transform tr, float speed, float speedRate, float size, float sizeRate, float lifetime, int rows, int cols)
        {
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startLifetime = lifetime;
            for (int i = 0; i < rows; i++)
            {
                float angle = i * Mathf.PI * 2 / rows;
                Vector3 pos = tr.TransformDirection(Mathf.Cos(angle), 0, Mathf.Sin(angle));
                float sp = speed;
                em.startSize = size;
                for (int a = 0; a < cols; a++)
                {
                    sp += speed * speedRate;

                    em.position = tr.position;
                    em.velocity = pos * sp;
                    em.startSize += size * sizeRate;
                    par.Emit(em, 1);
                }
            }
        }
        public void Emit_CycleShot(ParticleSystem par, Vector3 position, Vector3 forward, Vector3 upVec, float speed, float speedRate, float size, float sizeRate, float lifetime, int rows, int cols)
        {
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startLifetime = lifetime;
            shotTransform.rotation = Quaternion.LookRotation(forward, upVec);
            for (int i = 0; i < rows; i++)
            {
                float angle = i * Mathf.PI * 2 / rows;
                Vector3 pos = shotTransform.TransformDirection(Mathf.Cos(angle), 0, Mathf.Sin(angle));
                float sp = speed;
                em.startSize = size;
                for (int a = 0; a < cols; a++)
                {
                    sp += speed * speedRate;

                    em.position = position;
                    em.velocity = pos * sp;
                    em.startSize += size * sizeRate;
                    par.Emit(em, 1);
                }
            }
        }
        public void Emit_SquareShot(int number, Transform tr, float speed, float size, float lifetime, int rows)
        {
            ParticleSystem par = particle[number];
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startLifetime = lifetime;
            em.startSize = size;
            int r = rows / 2;
            for (int i = -r; i <= r; i++)
            {
                for (int j = -r; j <= r; j++)
                {
                    if (i == -r || i == r || j == -r || j == r)
                    {
                        em.position = tr.position;
                        em.velocity = tr.TransformDirection(i, 0, j) * speed / r;
                        par.Emit(em, 1);
                    }
                }
            }
        }
        public void Emit_SquareShot(int number, Vector3 position, Vector3 forward, Vector3 upVec, float speed, float size, float lifetime, int rows)
        {
            ParticleSystem par = particle[number];
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startLifetime = lifetime;
            em.startSize = size;
            shotTransform.rotation = Quaternion.LookRotation(forward, upVec);
            int r = rows / 2;
            for (int i = -r; i <= r; i++)
            {
                for (int j = -r; j <= r; j++)
                {
                    if (i == -r || i == r || j == -r || j == r)
                    {
                        em.position = position;
                        em.velocity = shotTransform.TransformDirection(i, 0, j) * speed / r;
                        par.Emit(em, 1);
                    }
                }
            }
        }
        public void Emit_SquareShot(ParticleSystem par, Transform tr, float speed, float size, float lifetime, int rows)
        {
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startLifetime = lifetime;
            em.startSize = size;
            int r = rows / 2;
            for (int i = -r; i <= r; i++)
            {
                for (int j = -r; j <= r; j++)
                {
                    if (i == -r || i == r || j == -r || j == r)
                    {
                        em.position = tr.position;
                        em.velocity = tr.TransformDirection(i, 0, j) * speed / r;
                        par.Emit(em, 1);
                    }
                }
            }
        }
        public void Emit_SquareShot(ParticleSystem par, Vector3 position, Vector3 forward, Vector3 upVec, float speed, float size, float lifetime, int rows)
        {
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startLifetime = lifetime;
            em.startSize = size;
            shotTransform.rotation = Quaternion.LookRotation(forward, upVec);
            int r = rows / 2;
            for (int i = -r; i <= r; i++)
            {
                for (int j = -r; j <= r; j++)
                {
                    if (i == -r || i == r || j == -r || j == r)
                    {
                        em.position = position;
                        em.velocity = shotTransform.TransformDirection(i, 0, j) * speed / r;
                        par.Emit(em, 1);
                    }
                }
            }
        }
        public void Emit_TriangleShot(int number, Transform tr, float speed, float speedRate, float size, float figureSize, float lifetime, int rows)
        {
            ParticleSystem par = particle[number];
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startLifetime = lifetime;
            em.startSize = size;
            Vector3 vec = tr.forward * speedRate;
            for (int i = -rows; i <= rows; i++)
            {
                Vector3 pos = tr.TransformDirection(i, 0, -Mathf.Abs(i) * 2);
                em.position = tr.position + vec * rows + (pos / rows) * figureSize;
                em.velocity = tr.forward * speed;
                par.Emit(em, 1);
            }
        }
        public void Emit_TriangleShot(int number, Vector3 position, Vector3 forward, Vector3 upVec, float speed, float speedRate, float size, float figureSize, float lifetime, int rows)
        {
            ParticleSystem par = particle[number];
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startLifetime = lifetime;
            em.startSize = size;
            shotTransform.rotation = Quaternion.LookRotation(forward, upVec);
            Vector3 vec = forward * speedRate;
            for (int i = -rows; i <= rows; i++)
            {
                Vector3 pos = shotTransform.TransformDirection(i, 0, -Mathf.Abs(i) * 2);
                em.position = position + vec * rows + (pos / rows) * figureSize;
                em.velocity = forward * speed;
                par.Emit(em, 1);
            }
        }
        public void Emit_TriangleShot(ParticleSystem par, Transform tr, float speed, float speedRate, float size, float figureSize, float lifetime, int rows)
        {
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startLifetime = lifetime;
            em.startSize = size;
            Vector3 vec = tr.forward * speedRate;
            for (int i = -rows; i <= rows; i++)
            {
                Vector3 pos = tr.TransformDirection(i, 0, -Mathf.Abs(i) * 2);
                em.position = tr.position + vec * rows + (pos / rows) * figureSize;
                em.velocity = tr.forward * speed;
                par.Emit(em, 1);
            }
        }
        public void Emit_TriangleShot(ParticleSystem par, Vector3 position, Vector3 forward, Vector3 upVec, float speed, float speedRate, float size, float figureSize, float lifetime, int rows)
        {
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startLifetime = lifetime;
            em.startSize = size;
            shotTransform.rotation = Quaternion.LookRotation(forward, upVec);
            Vector3 vec = forward * speedRate;
            for (int i = -rows; i <= rows; i++)
            {
                Vector3 pos = shotTransform.TransformDirection(i, 0, -Mathf.Abs(i) * 2);
                em.position = position + vec * rows + (pos / rows) * figureSize;
                em.velocity = forward * speed;
                par.Emit(em, 1);
            }
        }
        public void Emit_TriangleSpread(int number, Transform tr, float speed, float speedRate, float size, float figureSize, float lifetime, int rows, int cols)
        {
            ParticleSystem par = particle[number];
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startLifetime = lifetime;
            em.startSize = size;
            for (int i = -rows; i <= rows; i++)
            {
                Vector3 pos = tr.TransformDirection(i, 0, -Mathf.Abs(i) * 2);
                float sp = speed;
                float fsp = figureSize;
                for (int a = 0; a < cols; a++)
                {
                    sp += speed * speedRate;
                    fsp += figureSize * speedRate;

                    em.position = tr.position;
                    em.velocity = ((tr.forward * sp) * rows + (pos / rows) * cols) * fsp;

                    par.Emit(em, 1);
                }
            }
        }
        public void Emit_TriangleSpread(int number, Vector3 position, Vector3 forward, Vector3 upVec, float speed, float speedRate, float size, float figureSize, float lifetime, int rows, int cols)
        {
            ParticleSystem par = particle[number];
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startLifetime = lifetime;
            em.startSize = size;
            shotTransform.rotation = Quaternion.LookRotation(forward, upVec);
            for (int i = -rows; i <= rows; i++)
            {
                Vector3 pos = shotTransform.TransformDirection(i, 0, -Mathf.Abs(i) * 2);
                float sp = speed;
                float fsp = figureSize;
                for (int a = 0; a < cols; a++)
                {
                    sp += speed * speedRate;
                    fsp += figureSize * speedRate;

                    em.position = position;
                    em.velocity = ((forward * sp) * rows + (pos / rows) * cols) * fsp;

                    par.Emit(em, 1);
                }
            }
        }
        public void Emit_TriangleSpread(ParticleSystem par, Transform tr, float speed, float speedRate, float size, float figureSize, float lifetime, int rows, int cols)
        {
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startLifetime = lifetime;
            em.startSize = size;
            for (int i = -rows; i <= rows; i++)
            {
                Vector3 pos = tr.TransformDirection(i, 0, -Mathf.Abs(i) * 2);
                float sp = speed;
                float fsp = figureSize;
                for (int a = 0; a < cols; a++)
                {
                    sp += speed * speedRate;
                    fsp += figureSize * speedRate;

                    em.position = tr.position;
                    em.velocity = ((tr.forward * sp) + (tr.forward * rows + (pos / rows) * cols) * fsp);
                    par.Emit(em, 1);
                }
            }
        }
        public void Emit_TriangleSpread(ParticleSystem par, Vector3 position, Vector3 forward, Vector3 upVec, float speed, float speedRate, float size, float figureSize, float lifetime, int rows, int cols)
        {
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startLifetime = lifetime;
            em.startSize = size;
            shotTransform.rotation = Quaternion.LookRotation(forward, upVec);
            for (int i = -rows; i <= rows; i++)
            {
                Vector3 pos = shotTransform.TransformDirection(i, 0, -Mathf.Abs(i) * 2);
                float sp = speed;
                float fsp = figureSize;
                for (int a = 0; a < cols; a++)
                {
                    sp += speed * speedRate;
                    fsp += figureSize * speedRate;

                    em.position = position;
                    em.velocity = ((forward * sp) + (forward * rows + (pos / rows) * cols) * fsp);
                    par.Emit(em, 1);
                }
            }
        }
        public void Emit_RingShot(int number, Transform tr, float speed, float speedRate, float size, float SizeRate, float figureSize, float lifetime, int rows, int cols)
        {
            ParticleSystem par = particle[number];
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startLifetime = lifetime;
            em.startSize = size;
            for (int i = 0; i < rows; i++)
            {
                float angle = i * Mathf.PI * 2 / rows;
                Vector3 pos = tr.TransformDirection(Mathf.Cos(angle), 0, Mathf.Sin(angle));
                pos *= figureSize;
                float sp = speed;
                for (int a = 1; a <= cols; a++)
                {
                    sp += speed * speedRate;

                    pos += pos * a * SizeRate;
                    em.position = tr.position + pos;
                    em.velocity = tr.forward * sp;
                    par.Emit(em, 1);
                }
            }
        }
        public void Emit_RingShot(int number, Vector3 position, Vector3 forward, Vector3 upVec, float speed, float speedRate, float size, float SizeRate, float figureSize, float lifetime, int rows, int cols)
        {
            ParticleSystem par = particle[number];
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startLifetime = lifetime;
            em.startSize = size;
            shotTransform.rotation = Quaternion.LookRotation(forward, upVec);
            for (int i = 0; i < rows; i++)
            {
                float angle = i * Mathf.PI * 2 / rows;
                Vector3 pos = shotTransform.TransformDirection(Mathf.Cos(angle), 0, Mathf.Sin(angle));
                pos *= figureSize;
                float sp = speed;
                for (int a = 1; a <= cols; a++)
                {
                    sp += speed * speedRate;

                    pos += pos * a * SizeRate;
                    em.position = position + pos;
                    em.velocity = forward * sp;
                    par.Emit(em, 1);
                }
            }
        }
        public void Emit_RingShot(ParticleSystem par, Transform tr, float speed, float speedRate, float size, float SizeRate, float figureSize, float lifetime, int rows, int cols)
        {
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startLifetime = lifetime;
            em.startSize = size;
            for (int i = 0; i < rows; i++)
            {
                float angle = i * Mathf.PI * 2 / rows;
                Vector3 pos = tr.TransformDirection(Mathf.Cos(angle), 0, Mathf.Sin(angle));
                pos *= figureSize;
                float sp = speed;
                for (int a = 1; a <= cols; a++)
                {
                    sp += speed * speedRate;

                    pos += pos * a * SizeRate;
                    em.position = tr.position + pos;
                    em.velocity = tr.forward * sp;
                    par.Emit(em, 1);
                }
            }
        }
        public void Emit_RingShot(ParticleSystem par, Vector3 position, Vector3 forward, Vector3 upVec, float speed, float speedRate, float size, float SizeRate, float figureSize, float lifetime, int rows, int cols)
        {
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startLifetime = lifetime;
            em.startSize = size;
            shotTransform.rotation = Quaternion.LookRotation(forward, upVec);
            for (int i = 0; i < rows; i++)
            {
                float angle = i * Mathf.PI * 2 / rows;
                Vector3 pos = shotTransform.TransformDirection(Mathf.Cos(angle), 0, Mathf.Sin(angle));
                pos *= figureSize;
                float sp = speed;
                for (int a = 1; a <= cols; a++)
                {
                    sp += speed * speedRate;

                    pos += pos * a * SizeRate;
                    em.position = position + pos;
                    em.velocity = forward * sp;
                    par.Emit(em, 1);
                }
            }
        }
        public void Emit_MultiWay(int number, Transform tr, float speed, float speedRate, float size, float SizeRate, float figureSize, float lifetime, int rows, int cols)
        {
            ParticleSystem par = particle[number];
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startLifetime = lifetime;
            em.startSize = size;
            float angle;
            float startAngle = 90f - figureSize / 2;
            em.startSize = size;

            for (int i = 0; i < rows; i++)
            {
                angle = startAngle + i * (figureSize / (rows - 1));
                Vector3 pos = Quaternion.AngleAxis(angle, tr.up) * -tr.right;
                float sp = speed;
                for (int a = 0; a < cols; a++)
                {
                    sp += speed * speedRate;

                    em.position = tr.position;
                    em.velocity = pos * sp;
                    par.Emit(em, 1);
                }
            }
        }
        public void Emit_MultiWay(int number, Vector3 position, Vector3 forward, Vector3 upVec, float speed, float speedRate, float size, float SizeRate, float figureSize, float lifetime, int rows, int cols)
        {
            ParticleSystem par = particle[number];
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startLifetime = lifetime;
            em.startSize = size;
            shotTransform.rotation = Quaternion.LookRotation(forward, upVec);
            float angle;
            float startAngle = 90f - figureSize / 2;
            em.startSize = size;

            for (int i = 0; i < rows; i++)
            {
                angle = startAngle + i * (figureSize / (rows - 1));
                Vector3 pos = Quaternion.AngleAxis(angle, upVec) * -shotTransform.right;
                float sp = speed;
                for (int a = 0; a < cols; a++)
                {
                    sp += speed * speedRate;

                    em.position = position;
                    em.velocity = pos * sp;
                    par.Emit(em, 1);
                }
            }
        }
        public void Emit_MultiWay(ParticleSystem par, Transform tr, float speed, float speedRate, float size, float SizeRate, float figureSize, float lifetime, int rows, int cols)
        {
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startLifetime = lifetime;
            em.startSize = size;
            float angle;
            float startAngle = 90f - figureSize / 2;
            em.startSize = size;

            for (int i = 0; i < rows; i++)
            {
                angle = startAngle + i * (figureSize / (rows - 1));
                Vector3 pos = Quaternion.AngleAxis(angle, tr.up) * -tr.right;
                float sp = speed;
                for (int a = 0; a < cols; a++)
                {
                    sp += speed * speedRate;

                    em.position = tr.position;
                    em.velocity = pos * sp;
                    par.Emit(em, 1);
                }
            }
        }
        public void Emit_MultiWay(ParticleSystem par, Vector3 position, Vector3 forward, Vector3 upVec, float speed, float speedRate, float size, float SizeRate, float figureSize, float lifetime, int rows, int cols)
        {
            ParticleSystem.EmitParams em = emitParamsDefault;
            em.startLifetime = lifetime;
            em.startSize = size;
            float angle;
            float startAngle = 90f - figureSize / 2;
            em.startSize = size;
            shotTransform.rotation = Quaternion.LookRotation(forward, upVec);
            for (int i = 0; i < rows; i++)
            {
                angle = startAngle + i * (figureSize / (rows - 1));
                Vector3 pos = Quaternion.AngleAxis(angle, upVec) * -shotTransform.right;
                float sp = speed;
                for (int a = 0; a < cols; a++)
                {
                    sp += speed * speedRate;

                    em.position = position;
                    em.velocity = pos * sp;
                    par.Emit(em, 1);
                }
            }
        }
        //2016/8/18--------------------------------------------------------------------
        public void ShotSelector(shotType type, ShotParameter param, Transform tr)
        {
            switch (type)
            {
                case shotType.OneShot:
                    manager.Emit_OneShot(param.number, tr, param.speed, param.size);
                    break;
                case shotType.multiWay:
                    manager.Emit_MultiWay(param.number, tr, param.speed, param.speedRate, param.size, param.sizeRate, param.figureSize, param.lifeTime, param.rows, param.cols);
                    break;
                case shotType.cycle:
                    manager.Emit_CycleShot(param.number, tr, param.speed, param.speedRate, param.size, param.sizeRate, param.lifeTime, param.rows, param.cols);
                    break;
                case shotType.squareShot:
                    manager.Emit_SquareShot(param.number, tr, param.speed, param.size, param.lifeTime, param.rows);
                    break;
                case shotType.triangleShot:
                    manager.Emit_TriangleShot(param.number, tr, param.speed, param.speedRate, param.size, param.figureSize, param.lifeTime, param.rows);
                    break;
                case shotType.ringShot:
                    manager.Emit_RingShot(param.number, tr, param.speed, param.speedRate, param.size, param.sizeRate, param.figureSize, param.lifeTime, param.rows, param.cols);
                    break;
                case shotType.multiSpeed:
                    manager.Emit_MultiSpeed(param.number, tr, param.speed, param.speedRate, param.size, param.sizeRate, param.lifeTime, param.rows);
                    break;
                case shotType.triangleSpread:
                    manager.Emit_TriangleSpread(param.number, tr, param.speed, param.speedRate, param.size, param.figureSize, param.lifeTime, param.rows, param.cols);
                    break;
            }
        }
        public void ShotSelector(shotType type, ShotParameter param, Vector3 position, Vector3 forward, Vector3 upVec)
        {
            shotTransform.position = position;
            shotTransform.rotation = Quaternion.LookRotation(forward, upVec);
            switch (type)
            {
                case shotType.OneShot:
                    manager.Emit_OneShot(param.number, shotTransform, param.speed, param.size);
                    break;
                case shotType.multiWay:
                    manager.Emit_MultiWay(param.number, shotTransform, param.speed, param.speedRate, param.size, param.sizeRate, param.figureSize, param.lifeTime, param.rows, param.cols);
                    break;
                case shotType.cycle:
                    manager.Emit_CycleShot(param.number, shotTransform, param.speed, param.speedRate, param.size, param.sizeRate, param.lifeTime, param.rows, param.cols);
                    break;
                case shotType.squareShot:
                    manager.Emit_SquareShot(param.number, shotTransform, param.speed, param.size, param.lifeTime, param.rows);
                    break;
                case shotType.triangleShot:
                    manager.Emit_TriangleShot(param.number, shotTransform, param.speed, param.speedRate, param.size, param.figureSize, param.lifeTime, param.rows);
                    break;
                case shotType.ringShot:
                    manager.Emit_RingShot(param.number, shotTransform, param.speed, param.speedRate, param.size, param.sizeRate, param.figureSize, param.lifeTime, param.rows, param.cols);
                    break;
                case shotType.multiSpeed:
                    manager.Emit_MultiSpeed(param.number, shotTransform, param.speed, param.speedRate, param.size, param.sizeRate, param.lifeTime, param.rows);
                    break;
                case shotType.triangleSpread:
                    manager.Emit_TriangleSpread(param.number, shotTransform, param.speed, param.speedRate, param.size, param.figureSize, param.lifeTime, param.rows, param.cols);
                    break;
            }
        }
        public void KillParticle(int number)
        {
            ParticleSystem par = particle[number];
            int length = par.GetParticles(particles[number]);
            for (int i = 0; i < length; i++)
            {
                particles[number][i].remainingLifetime = 0;
            }
            particle[number].SetParticles(particles[number], length);
        }
        public void KillParticle(ParticleSystem par, ParticleSystem.Particle[] pars)
        {
            int length = par.GetParticles(pars);
            for (int i = 0; i < length; i++)
            {
                pars[i].remainingLifetime = 0;
            }
            par.SetParticles(pars, length);
        }
        public void Vector_ExplosionForce(int number, Vector3 pos, float speed)
        {
            ParticleSystem par = particle[number];
            ParticleSystem.Particle[] pars = particles[number];
            int length = par.GetParticles(pars);
            for (int i = 0; i < length; i++)
            {
                Vector3 vec = (pars[i].position - pos).normalized * speed;
                pars[i].velocity += vec;
            }
            particle[number].SetParticles(particles[number], length);
        }
        public void Vector_ExplosionForce(ParticleSystem par, ParticleSystem.Particle[] pars, Vector3 pos, float speed)
        {
            int length = par.GetParticles(pars);
            for (int i = 0; i < length; i++)
            {
                Vector3 vec = (pars[i].position - pos).normalized * speed;
                pars[i].velocity += vec;
            }
            par.SetParticles(pars, length);
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------
        public void Vector_Rotate(int number, float speed)
        {
            ParticleSystem par = particle[number];
            int length = par.GetParticles(particles[number]);
            for (int i = 0; i < length; i++)
            {
                particles[number][i].velocity = Quaternion.AngleAxis(speed, Vector3.up) * particles[number][i].velocity;
            }
            par.SetParticles(particles[number], length);
        }
        public void Vector_Rotate(ParticleSystem par, float speed, ParticleSystem.Particle[] pars)
        {
            int length = par.GetParticles(pars);
            for (int i = 0; i < length; i++)
            {
                pars[i].velocity = Quaternion.AngleAxis(speed, Vector3.up) * pars[i].velocity;
            }
            par.SetParticles(pars, length);
        }
        public void Vector_Rotate(int number, float speed, Vector3 axis)
        {
            ParticleSystem par = particle[number];
            int length = par.GetParticles(particles[number]);
            for (int i = 0; i < length; i++)
            {
                particles[number][i].velocity = Quaternion.AngleAxis(speed, axis) * particles[number][i].velocity;
            }
            par.SetParticles(particles[number], length);
        }
        public void Vector_Rotate(ParticleSystem par, float speed, Vector3 axis, ParticleSystem.Particle[] pars)
        {
            int length = par.GetParticles(pars);
            for (int i = 0; i < length; i++)
            {
                pars[i].velocity = Quaternion.AngleAxis(speed, axis) * pars[i].velocity;
            }
            par.SetParticles(pars, length);
        }
        public void Vector_AddVelocity(int number, Vector3 vector)
        {
            ParticleSystem par = particle[number];
            int length = par.GetParticles(particles[number]);

            for (int i = 0; i < length; i++)
            {
                particles[number][i].velocity += vector;
            }
            par.SetParticles(particles[number], length);
        }
        public void Vector_AddVelocity(ParticleSystem par, Vector3 vector, ParticleSystem.Particle[] pars)
        {
            int length = par.GetParticles(pars);

            for (int i = 0; i < length; i++)
            {
                pars[i].velocity += vector;
            }
            par.SetParticles(pars, length);
        }
        public void Vector_AddSpeed(int number, float speed)
        {
            ParticleSystem par = particle[number];
            int length = par.GetParticles(particles[number]);
            for (int i = 0; i < length; i++)
            {
                particles[number][i].velocity += particles[number][i].velocity.normalized * speed;
            }
            par.SetParticles(particles[number], length);
        }
        public void Vector_AddSpeed(ParticleSystem par, float speed, ParticleSystem.Particle[] pars)
        {
            int length = par.GetParticles(pars);
            for (int i = 0; i < length; i++)
            {
                pars[i].velocity += pars[i].velocity.normalized * speed;
            }
            par.SetParticles(pars, length);
        }
        public void Vector_SetVelocity(int number, Vector3 vector)
        {
            ParticleSystem par = particle[number];
            int length = par.GetParticles(particles[number]);
            for (int i = 0; i < length; i++)
            {
                particles[number][i].velocity = vector;
            }
            par.SetParticles(particles[number], length);
        }
        public void Vector_SetVelocity(ParticleSystem par, Vector3 vector, ParticleSystem.Particle[] pars)
        {
            int length = par.GetParticles(pars);
            for (int i = 0; i < length; i++)
            {
                pars[i].velocity = vector;
            }
            par.SetParticles(pars, length);
        }
        public void Vector_LookPosition(int number, Vector3 position)
        {
            ParticleSystem par = particle[number];
            int length = par.GetParticles(particles[number]);
            for (int i = 0; i < length; i++)
            {
                Vector3 vec = position - particles[number][i].position;
                particles[number][i].velocity = Quaternion.LookRotation(vec) * Vector3.forward;
            }
            particle[number].SetParticles(particles[number], length);
        }
        public void Vector_LookPosition(ParticleSystem par, Vector3 position, ParticleSystem.Particle[] pars)
        {
            int length = par.GetParticles(pars);
            for (int i = 0; i < length; i++)
            {
                Vector3 vec = position - pars[i].position;
                pars[i].velocity = Quaternion.LookRotation(vec) * Vector3.forward;
            }
            par.SetParticles(pars, length);
        }
        public void Vector_RotateTowards(int number, float speed, Vector3 position)
        {
            ParticleSystem par = particle[number];
            int length = par.GetParticles(particles[number]);
            for (int i = 0; i < length; i++)
            {
                ParticleSystem.Particle p = particles[number][i];
                particles[number][i].velocity = Vector3.RotateTowards(p.velocity, position - p.position, speed, 0.0f);
            }
            par.SetParticles(particles[number], length);
        }
        public void Vector_RotateTowards(ParticleSystem par, float speed, Vector3 position, ParticleSystem.Particle[] pars)
        {
            int length = par.GetParticles(pars);
            for (int i = 0; i < length; i++)
            {
                ParticleSystem.Particle p = pars[i];
                pars[i].velocity = Vector3.RotateTowards(p.velocity, position - p.position, speed, 0.0f);
            }
            par.SetParticles(pars, length);
        }
        //other----------------------------------------------------------------------------------------------------------------------------------------------
        public void ClearAllParticle()
        {
            int length = particle.Length;
            for (int i = 0; i < length; i++)
            {
                particle[i].Clear(true);
            }
        }
        public void AddParticle(ParticleSystem par, float pow)
        {
            List<ParticleSystem> ps = particle.ToList();
            ps.Add(par);
            particle = ps.ToArray();
            List<float> powerList = power.ToList();
            powerList.Add(pow);
            power = powerList.ToArray();
        }
        //get variable-------------------------------------------------------------------
        public int GetNumber(ParticleSystem par)
        {
            int num;
            List<ParticleSystem> ps = particle.ToList();
            num = ps.IndexOf(par);
            return num;
        }
        public float GetPower(int number)
        {
            return power[number];
        }
        public float GetPower(ParticleSystem par)
        {
            int num;
            List<ParticleSystem> ps = particle.ToList();
            num = ps.IndexOf(par);
            return power[num];
        }
    }
}