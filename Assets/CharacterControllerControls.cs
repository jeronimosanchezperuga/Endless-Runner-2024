using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerControls : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;

    public float moveSpeed;
    public float runningSpeed;
    private float gravity = -50f;
    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;
    float horizontalInput;


    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        isGrounded = Physics.CheckSphere(transform.position, .1f, groundLayer, QueryTriggerInteraction.Ignore);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        characterController.Move(new Vector3(horizontalInput,0,runningSpeed * Time.deltaTime));

        characterController.Move(velocity*Time.deltaTime);
    }
}
