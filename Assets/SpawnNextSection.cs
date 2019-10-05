using UnityEngine;
using System.Collections;

public class SpawnNextSection : MonoBehaviour
{
    public Transform[] nextSection;
    private Transform lastSpawnedSection;

    void OnTriggerEnter(Collider other)
    {
        int randomSection = Random.Range(0, nextSection.Length);

        if (other.GetComponent<BallController>())
        {
            if (lastSpawnedSection != null)
                Destroy(lastSpawnedSection.gameObject);
            Debug.Log("Triggered.. Spawning next section, destroying last");

            Vector3 spawnPosition = WorldPositionOfEndOfThisSection();// transform.parent.position + new Vector3(0, 0, transform.parent);
            Quaternion spawnRotation = Quaternion.identity;
            lastSpawnedSection = Instantiate(nextSection[randomSection], spawnPosition, spawnRotation);
            gameObject.SetActive(false);
        }
    }

    private Vector3 WorldPositionOfEndOfThisSection()
    {
        Debug.Log(transform.parent);
        return transform.parent.GetComponent<LevelSection>().endOfLevelObject.position;
    }
}
