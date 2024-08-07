using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyControls : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public float speed;
    public float maxSpeed;
    public float movementDamp;
    [SerializeField] float desiredSideMovementSpeed;
    [SerializeField] float sideMovementSpeed;
    [SerializeField] float brakeAmount;
    [SerializeField] float accelerationAmount;
    [SerializeField] Animator anim;
    public float inputX;
    Vector3 horizontalMovement;
    Vector3 forwardMovement;
    Vector3 movementVector;
    public bool sliding = false;
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    IEnumerator MovementSmoother(float acceleration)
    {
        sideMovementSpeed = 0.1f;
        while (sideMovementSpeed < desiredSideMovementSpeed)
        {
            yield return new WaitForSeconds(0.1f);
            sideMovementSpeed += sideMovementSpeed * acceleration;
            Debug.Log("Smoothing " + sideMovementSpeed);
        }
        sideMovementSpeed = desiredSideMovementSpeed;
        Debug.Log("Done Smoothing");
    }


    void Update()
    {
        if (!sliding)
        {            
            inputX = Input.GetAxis("Horizontal");
            if (Input.GetKeyDown(KeyCode.S))
            {
                anim.SetTrigger("Slide");
                sliding = true;
                StopAllCoroutines();
            }

        }
        else
        {
            sideMovementSpeed -= sideMovementSpeed * brakeAmount;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            transform.Rotate(Vector3.up * 90);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            transform.Rotate(Vector3.up * -90);
        }
    }

    //IEnumerator RotateCharacter()
    //{
    //    Vector3 elapsed = Vector3.Lerp();
    //}


    public void SetSliding(bool val)
    {
        sliding = val;
        StartCoroutine(MovementSmoother(accelerationAmount));
        Debug.Log("Stop sliding");
    }

    void FixedUpdate()
    {
        //Con MovePosition
        forwardMovement = transform.forward * speed * Time.fixedDeltaTime;
        horizontalMovement = transform.right * inputX * sideMovementSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMovement + horizontalMovement);
    

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
