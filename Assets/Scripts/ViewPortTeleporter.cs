using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPortTeleporter : MonoBehaviour
{
        private void Update()
        {
            var cam = Camera.current;
            if (cam == null)
            {
                return;
            }

            var point = cam.WorldToViewportPoint(transform.position);

            if (point.x > 1)
            {
                TeleportTo(new Vector2(0, point.y));
                return;
            }
            if (point.x < 0)
            {
                TeleportTo(new Vector2(1, point.y));
                return;
            }
            if (point.y > 1)
            {
                TeleportTo(new Vector2(point.x, 0));
                return;
            }
            if (point.y < 0)
            {
                TeleportTo(new Vector2(point.x, 1));
                return;
            }

            void TeleportTo(Vector2 pt)
            {
                var ray = cam.ViewportPointToRay(pt);
                var plane = new Plane(Vector3.up, Vector3.zero);
                if (plane.Raycast(ray, out float distance))
                {
                    transform.position = ray.GetPoint(distance);
                }
            }
        }
}
