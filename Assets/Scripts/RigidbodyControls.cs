using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyControls : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public float speed;
    public float maxSpeed;
    public float movementDamp;
    public float minMaxX;
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
        //Con MovePosition
        forwardMovement = transform.forward * speed * Time.fixedDeltaTime;
        horizontalMovement = transform.right * inputX * sideMovementSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMovement + horizontalMovement);
        Vector3 clampedPosition = rb.position;
        if (rb.position.x < minMaxX*-1)
        {
            clampedPosition.x = minMaxX * -1;
        }
        if (rb.position.x > minMaxX)
        {
            clampedPosition.x = minMaxX;
        }
        rb.position = clampedPosition;

        /*Con ForceMode.VelocityChange, pero está muy raro
        if (inputX != 0) { movementVector.x = inputX * speed * Time.fixedDeltaTime; }
        if (inputX == 0) { movementVector.x -= (rb.velocity.x * movementDamp * Time.fixedDeltaTime); }

        rb.AddForce(transform.forward + movementVector * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        */

        /* Cambiando la velocity 
         * (dicen que no conviene, anda pero puede traer problema con las colisiones)
        horizontalMovement = transform.right * inputX * sideMovementSpeed * Time.deltaTime;
        forwardMovement = transform.forward * speed * Time.deltaTime;
        rb.velocity = (horizontalMovement + forwardMovement);
        */
    }
}
