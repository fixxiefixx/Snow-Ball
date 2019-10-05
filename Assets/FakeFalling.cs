using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeFalling : MonoBehaviour
{
    //public float maxFallVelocity;
    public float fallVelocity;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        // [POLISH]
        // stop using velocity because we may hit something and need to stop and reaccellerate (to look NICE AND REALISTIC)
        //var fakeFallSpeed = rb.velocity.z;
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, fallVelocity);
    }
}
