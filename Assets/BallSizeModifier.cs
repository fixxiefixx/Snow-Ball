using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSizeModifier : MonoBehaviour
{
    public int sizeModifier = 0;
    private float scaleModifier = 0.1f;
    private Vector3 initialScale;


    private void Awake()
    {
        initialScale = transform.localScale;
    }

    public void IncreaseSize()
    {
        Debug.Log("Ball size increased");
        sizeModifier++;
        UpdateSize();
    }

    public void DecreaseSize()
    {
        Debug.Log("Ball size decreased");
        sizeModifier--;
        UpdateSize();
    }

    private void UpdateSize()
    {
        transform.localScale = initialScale + ((Vector3.one * sizeModifier) * scaleModifier);
    }
}