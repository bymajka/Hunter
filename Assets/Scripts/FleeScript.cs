using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class FleeScript : DesiredVelocityProvider
{
        [SerializeField] private GameObject objectToFlee;
        
        public override Vector3 GetDesiredVelocity()
        {
            return -(objectToFlee.transform.position - transform.position).normalized * Animal.VelocityLimit;
        }
}
