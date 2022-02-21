using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class AvoidEdges : DesiredVelocityProvider
{
    private float edge = 0.05f;
        
    public override Vector3 GetDesiredVelocity()
    {
        var cam = Camera.main;
        var maxSpeed = Animal.VelocityLimit;
        var v = Animal.Velocity;
        
        if (cam == null)
        {
            return v;
        }

        Vector2 point = cam.ScreenToViewportPoint(transform.position);

        if (point.x > 1 - edge)
        {
            return new Vector3(-maxSpeed, 0, 0);
        }
        if (point.x < edge)
        {
            return new Vector3(maxSpeed, 0, 0);
        }
        if (point.y > 1 - edge)
        {
            return new Vector3(0, -maxSpeed, 0);
        }
        if (point.y < edge)
        {
            return new Vector3(0, maxSpeed, 0);
        }

        return v;
    }
}
