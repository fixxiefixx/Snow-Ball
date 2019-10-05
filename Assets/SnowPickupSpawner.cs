using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowPickupSpawner : MonoBehaviour
{
    public SnowPickup SnowPickupPrefab;
    public float lastSpawnX;
    public int minConsecutiveDirectionSpawns = 3;
    public int maxConsecutiveDirectionSpawns = 3;
    public float spawnBetweenDistance = 1f;
    public float spawnInfrontOffset = 10f;

    private bool isRunning;
    private Transform ball;
    private Vector3 lastBallPositionWhenSpawned;
    private int currentConsec;
    private float lastSpawnOffsetX;

    private void OnEnable()
    {
        GameManager.OnGameStart += OnGameStart;
        ball = FindObjectOfType<BallController>().transform;
    }

    private void OnDisable()
    {
        GameManager.OnGameStart -= OnGameStart;
    }

    private void OnGameStart()
    {
        isRunning = true;
        //StartCoroutine(SnowPickupSpawnerRoutine());
    }

    private void OnGameEnd()
    {
        isRunning = false;
    }


    void Update()
    {
    }
    /* rapid unthought out code... BAD IDEA
    IEnumerator SnowPickupSpawnerRoutine()
    {
        while (isRunning)
        {
            // spawn relative to player X pos??? means map can be unlimited width
            if (Vector3.Distance(ball.position, lastBallPositionWhenSpawned) > spawnBetweenDistance)
            {
                lastBallPositionWhenSpawned = ball.position;
                var newSpawnPos = new Vector3(GetNextOffset(), transform.position.y, ball.position.z + spawnInfrontOffset);
                Instantiate(SnowPickupPrefab, newSpawnPos, Quaternion.identity);
            }
            yield return null;
        }
    }


    private float GetNextOffset()
    {
        // return same offset
        if (currentConsec < minConsecutiveDirectionSpawns)
        {
            currentConsec++;
            return lastSpawnX;
        }
        else
        {
            currentConsec = 0;
            lastSpawnOffsetX = Random.Range(-2, 1);

            var ret = lastSpawnX + lastSpawnOffsetX;
            lastSpawnX = ret;
            return ret;
        }
    }*/
}
