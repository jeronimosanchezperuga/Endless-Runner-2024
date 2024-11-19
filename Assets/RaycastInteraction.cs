using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteraction : MonoBehaviour
{
    public Transform rayOrigin;
    public float rayLenght;
    public LayerMask layer;
    public GameObject uiGO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        InteractableObject interactable = null;
        if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out hit, rayLenght, layer))
        {
            interactable = hit.collider.GetComponent<InteractableObject>();
            if (interactable)
            {
                
            }
        }
        uiGO.SetActive(interactable);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(rayOrigin.position, rayOrigin.position + rayOrigin.forward * rayLenght);
    }

}
