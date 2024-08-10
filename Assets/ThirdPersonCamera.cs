using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 cameraDistance;
    public float pLerp = 0.2f;
    public float rLerp = 0.1f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //La cámara se posiciona suavemente detrás del player a una distancia determninada 
        transform.position = Vector3.Lerp(transform.position , target.position + target.forward * cameraDistance.z, pLerp);
        //la cámara se orienta suavemente para mirar en la dirección en la que mira el player
        transform.rotation = Quaternion.Lerp(transform.rotation,target.rotation,rLerp);
    }
}
