using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public List<GameObject> powerUpsPrefabs;
    public CapsuleCollider spawnArea;
    public float timeBetweenPowerUps;

    private void Start()
    {
        StartCoroutine(StartSpawner());      
    }

    IEnumerator StartSpawner()
    {
        yield return new WaitForSeconds(timeBetweenPowerUps);
        InvokeRepeating("SpawnPowerUp", 0f, timeBetweenPowerUps);
    }

    void SpawnPowerUp()
    {
        Vector3 randomSpawnPoint = RandomPointInCollider(spawnArea);
        Quaternion randomRotation = Random.rotation;

        var rand = Random.Range(0, powerUpsPrefabs.Count);

        Instantiate(powerUpsPrefabs[rand], randomSpawnPoint, randomRotation);
    }

    Vector3 RandomPointInCollider(CapsuleCollider collider)
    {
        float randomX = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
        float randomZ = Random.Range(collider.bounds.min.z, collider.bounds.max.z);

        return new Vector3(randomX, -90, randomZ);
    }
}
