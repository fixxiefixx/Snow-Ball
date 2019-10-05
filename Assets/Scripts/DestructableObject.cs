using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour
{
    public int SnowSizeRequiredToDestroy;
    private const float scaleModifierPerSnow = .1f;
    private Vector3 beginScale;
    //private float snowScaleIncrement = 1;

    private void Awake()
    {
        beginScale = transform.localScale;
    }

    /* NO WE NOT DOING THIS TOO PICKY!!, LETS SET EACH OBJECT MANUALLY, IF YOU WANT 3 TREES DIFFERENT SNOW PRICES.... MAKE 3 OBJECT SPAWNERS FOR 3 DIFFERENT TREE PREFABS!!
    public void RandomizeSnowRequired(float percentageOut1)
    {
        var randomChange = (int)Random.Range(-percentageOut1 * SnowSizeRequiredToDestroy, percentageOut1 * SnowSizeRequiredToDestroy);
        SnowSizeRequiredToDestroy += randomChange;
        UpdateScale();
    }*/

    void Start()
    {
        UpdateScale();
    }

    private void UpdateScale()
    {
        // this will increase scale of THIS object  based on snow required
        transform.localScale = Vector3.one + ((Vector3.one * SnowSizeRequiredToDestroy) * scaleModifierPerSnow);
    }

    private void OnTriggerEnter(Collider other)
    {
        BallController ball = other?.GetComponent<BallController>();
        if (ball)
        {
            if (ball.GetComponent<BallSizeModifier>().sizeModifier >= SnowSizeRequiredToDestroy)
            {
                transform.parent = ball.transform;

                GetComponent<Collider>().enabled = false;
                //Destroy(gameObject); maybe absorb over time then destroy it??
                Destroy(gameObject, 5f); // [POLISH] SHRINK TO DESTROY IN COROUTINE
            }
        }
    }
}
