    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 cameraDistance;
    public float followingSpeed = 3f;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        cameraDistance = transform.position - target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, 0, target.position.z) + cameraDistance + offset, Time.fixedDeltaTime + followingSpeed); ;
    }
}
