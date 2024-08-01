using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideAnimationEvents : MonoBehaviour
{
    public RigidbodyControls controls;

    // Start is called before the first frame update
    void Start()
    {
        controls = GetComponentInParent<RigidbodyControls>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimationEnds()
    {
        controls.SetSliding(false);
    }
}
