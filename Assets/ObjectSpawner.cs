using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public int amountToSpawn = 20;
    public Transform objectToSpawn;
    //public bool giveRandomDestructableValues = true;

    void Awake()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    void Start()
    {
        SpawnObjects(amountToSpawn);
    }

    private void SpawnObjects(int amount)
    {
        for (int i = 0; i < amount; ++i)
        {
            var spawnPosition = RandomPointInBounds(GetComponent<Collider>().bounds);
            var obj = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            obj.SetParent(transform.root, true);

            /* to be removed probably
            if (giveRandomDestructableValues)
            {
                var destructable = obj?.GetComponent<DestructableObject>();
                if (destructable)
                {
                    destructable.RandomizeSnowRequired(.5f);
                }
            }*/
        }
    }

    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
}
