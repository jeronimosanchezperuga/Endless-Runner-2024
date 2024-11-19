using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteraction : MonoBehaviour
{
    public Transform rayOrigin;
    public float rayLenght;
    public LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out hit, rayLenght, layer))
        {
            InteractableObject interactable = hit.collider.GetComponent<InteractableObject>();
            if (interactable)
            {

            }
        }
    }
}
