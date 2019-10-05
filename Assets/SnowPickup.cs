using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowPickup : MonoBehaviour
{
    public bool ShouldIncreasePlayerSize = true;

    private void OnTriggerEnter(Collider other)
    {
        BallController ball = other.transform.root.GetComponent<BallController>();
        if (ball)
        {
            if (ShouldIncreasePlayerSize)
                ball.GetComponent<BallSizeModifier>().IncreaseSize();
            else
                ball.GetComponent<BallSizeModifier>().DecreaseSize();
        }
        Destroy(gameObject);
    }
}
