using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 move;
    [SerializeField] private float speed = 3;

    private void Update()
    {
        move.x = Input.GetAxis("Horizontal");
        move.z = Input.GetAxis("Vertical");

        transform.position += move * (Time.deltaTime * speed);
    }
}
