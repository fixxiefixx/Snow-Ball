using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedCameraController : MonoBehaviour
{
    Transform ball;
    Vector3 offset;
    Vector3 directionToCameraFromObject;
    float distanceToFollowObject;
    public float initZoom;
    public float currentZoom;

    private void Awake()
    {
        ball = FindObjectOfType<BallController>().transform;
        offset = transform.position - ball.position;
        directionToCameraFromObject = transform.position - ball.position;
        directionToCameraFromObject.Normalize();
        distanceToFollowObject = Vector3.Distance(transform.position, ball.position);
        initZoom = distanceToFollowObject;
    }

    private void Update()
    {

        //set zoom to players size + current zoom
        currentZoom = initZoom + ball.GetComponent<BallSizeModifier>().sizeModifier;
    }

    void FixedUpdate()
    {
        //var newX = Mathf.Lerp(transform.position.x, followObject.position.x + offset.x, .03f);
        //var newZ = Mathf.Lerp(transform.position.z, followObject.position.z + offset.z, .5f);
        //var newY = Mathf.Lerp(transform.position.y, followObject.position.y + offset.y, .5f);


        transform.position = Vector3.Lerp(transform.position, ball.position + (directionToCameraFromObject * currentZoom), .3f);//new Vector3(newX, newY, newZ);
    }
}
