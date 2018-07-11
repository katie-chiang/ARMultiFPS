using UnityEngine;
using System.Collections;

namespace ParticleBulletSystem
{
    public class Demo3 : MonoBehaviour
    {
        public ParticleShooter shooter;

        void Reset()
        {
            shooter = GetComponent<ParticleShooter>();
        }
        public void SetType(int t)
        {
            switch (t)
            {
                case 0:
                    shooter.type = shotType.OneShot;
                    break;
                case 1:
                    shooter.type = shotType.multiWay;
                    break;
                case 2:
                    shooter.type = shotType.cycle;
                    break;
                case 3:
                    shooter.type = shotType.squareShot;
                    break;
                case 4:
                    shooter.type = shotType.triangleShot;
                    break;
                case 5:
                    shooter.type = shotType.ringShot;
                    break;
                case 6:
                    shooter.type = shotType.multiSpeed;
                    break;
                case 7:
                    shooter.type = shotType.triangleSpread;
                    break;
            }
        }
        public void SetNumber(float a)
        {
            shooter.parameter.number = (int)a;
        }
        public void SetLifetime(float a)
        {
            shooter.parameter.lifeTime = a;
        }
        public void SetSpeed(float a)
        {
            shooter.parameter.speed = a;
        }
        public void SetSpeedRate(float a)
        {
            shooter.parameter.speedRate = a;
        }
        public void SetSize(float a)
        {
            shooter.parameter.size = a;
        }
        public void SetSizeRate(float a)
        {
            shooter.parameter.sizeRate = a;
        }
        public void SetFigureSize(float a)
        {
            shooter.parameter.figureSize = a;
        }
        public void SetRows(float r)
        {
            shooter.parameter.rows = (int)r;
        }
        public void SetCols(float c)
        {
            shooter.parameter.cols = (int)c;
        }
        public void SetRepeatTimer(float r)
        {
            shooter.repeatDelay = r;
        }
    }
}