using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class SeekScript : DesiredVelocityProvider
{
    [SerializeField]
    private Transform objectToFollow;

    [SerializeField, Range(0,10)]
    private float arriveRadius;
        
    public override Vector3 GetDesiredVelocity()
    {
        if (objectToFollow != null)
        {
            var distance = (objectToFollow.position - transform.position);
            float k = 1;
            if (distance.magnitude < arriveRadius)
            {
                k = distance.magnitude / arriveRadius;
            }
            return distance.normalized * Animal.VelocityLimit * k;
        }

        return transform.position.normalized * Animal.VelocityLimit;
    }
}
