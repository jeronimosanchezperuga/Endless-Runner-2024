﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyControls : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public float speed;
    public float maxSpeed;
    public float movementDamp;
    public Vector3 currentVelocity;
    [SerializeField] float sideMovementSpeed;
    float inputX;
    Vector3 horizontalMovement;
    Vector3 forwardMovement;
    Vector3 movementVector;

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");        
    }

    void FixedUpdate()
    {
        if (inputX != 0) { movementVector.x = inputX * speed; }
        if (inputX == 0) { movementVector.x -= (rb.velocity.x * movementDamp); }

        currentVelocity = rb.velocity;
        rb.AddForce(transform.forward + movementVector * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        /* Cambiando la velocity 
         * (dicen que no conviene, anda pero puede traer problema con las colisiones)
        horizontalMovement = transform.right * inputX * sideMovementSpeed * Time.deltaTime;
        forwardMovement = transform.forward * speed * Time.deltaTime;
        rb.velocity = (horizontalMovement + forwardMovement);
        */
    }
}
