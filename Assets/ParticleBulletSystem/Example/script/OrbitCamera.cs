using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ParticleBulletSystem
{
    public class OrbitCamera : MonoBehaviour
    {
        public Transform target;
        public Vector3 targetOffset;
        public float distance = 4;

        public LayerMask lineOfSightMask = 0;
        public float closerRadius = 0.2f;
        public float closerSnapLag = 0.2f;

        public float xSpeed = 200;
        public float ySpeed = 80;

        public float yMinLimit = -20;
        public float yMaxLimit = 80;

        float currentDistance = 10;
        float x = 0;
        float y = 0;
        float distanceVelocity = 0;

        Transform tr;

        // Use this for initialization
        void Start()
        {
            tr = transform;
            Vector3 angles = tr.eulerAngles;
            x = angles.y;
            y = angles.x;
            currentDistance = distance;

            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb)
                rb.freezeRotation = true;
        }

        // Update is called once per frame
        void LateUpdate()
        {
            if (target)
            {
                x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

                y = ClampAngle(y,yMinLimit,yMaxLimit);

                Quaternion rotation = Quaternion.Euler(y, x, 0);
                Vector3 targetPos = target.position + targetOffset;
                Vector3 direction = rotation * -Vector3.forward;

                float targetDistance = AdjustLineOfSight(targetPos,direction);
                currentDistance = Mathf.SmoothDamp(currentDistance, targetDistance,ref distanceVelocity, closerSnapLag * .3f);

                tr.rotation = rotation;
                tr.position = targetPos + direction * currentDistance;
            }
        }

        float AdjustLineOfSight(Vector3 target, Vector3 direction)
        {
            RaycastHit hit;
            if (Physics.Raycast(target, direction, out hit, distance, lineOfSightMask.value))
                return hit.distance - closerRadius;
            else
                return distance;
        }

        float ClampAngle(float angle,float min, float max)
        {
            if (angle < -360)
                angle += 360;
            if (angle > 360)
                angle -= 360;
            return Mathf.Clamp(angle, min, max);
        }
    }
}