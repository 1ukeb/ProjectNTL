using System.Collections.Generic;
using UnityEngine;

namespace NTL.Camera
{
    public class CameraController : MonoBehaviour
    {
        public static List<Transform> targets = new List<Transform>();

        [Space]
        [Header("Move Settings")]
        public Vector3 offset;
        public float moveSmoothTime;

        [Space]
        [Header("Zoom Settings")]
        public float minZoom;
        public float maxZoom;
        public float zoomLimiter;
        public float zoomSmoothTime;

        private Vector3 velocity;
        private UnityEngine.Camera cam;

        private void Start() => cam = GetComponent<UnityEngine.Camera>();

        private void LateUpdate()
        {
            // if no cam targets, return
            if (targets.Count == 0)
                return;

            Move();
            Zoom();
        }

        private void Move()
        {
            Vector3 centerPoint = GetTargetCenter();
            Vector3 newPosition = centerPoint + offset;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, moveSmoothTime * Time.deltaTime);
            
            // dont follow tanks on y axis
            newPos.y = offset.y;
            transform.position = newPos;
        }

        private void Zoom()
        {
            // orthographic cam zoom
            if (cam.orthographic)
            {
                Vector2 bounds = GetTargetBounds();
                float zoomSize = Mathf.Max(bounds.x, bounds.y) / zoomLimiter;
                zoomSize = Mathf.Clamp(zoomSize, maxZoom, minZoom);
                //float newZoom = Mathf.Clamp(GetTargetWidth() / zoomLimiter, maxZoom, minZoom);
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoomSize, zoomSmoothTime * Time.deltaTime);
            }
            // perspective cam zoom
            else
            {
                float newZoom = Mathf.Lerp(maxZoom, minZoom * 4, GetTargetWidth() / zoomLimiter);
                cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
            }
        }

        private float GetTargetWidth()
        {
            Bounds bounds = new Bounds(targets[0].position, Vector3.zero);

            foreach (Transform trans in targets)
                bounds.Encapsulate(trans.position);

            return bounds.size.x;
        }

        private float GetTargetHeight()
        {
            Bounds bounds = new Bounds(targets[0].position, Vector3.zero);

            foreach (Transform trans in targets)
                bounds.Encapsulate(trans.position);

            return bounds.size.z;
        }

        private Vector2 GetTargetBounds()
        {
            Bounds bounds = new Bounds(targets[0].position, Vector3.zero);

            foreach (Transform trans in targets)
                bounds.Encapsulate(trans.position);

            return new Vector2(bounds.size.x, bounds.size.z);
        }

        private Vector3 GetTargetCenter()
        {
            if (targets.Count == 0)
                return transform.position;

            if (targets.Count == 1)
                return targets[0].position;

            Bounds bounds = new Bounds(targets[0].position, Vector3.zero);

            foreach (Transform trans in targets)
                bounds.Encapsulate(trans.position);

            return bounds.center;
        }
    }
}
