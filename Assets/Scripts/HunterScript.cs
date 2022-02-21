using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterScript : MonoBehaviour
{
    [SerializeField] private float hunterSpeed = 5f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * hunterSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * hunterSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * hunterSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * hunterSpeed * Time.deltaTime;
        }
    }
}
