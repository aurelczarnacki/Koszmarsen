using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs;
    public CapsuleCollider spawnArea;
    public float additionalSpeed = 0;
    public float additionalSpeedIncrement = 0.1f;
    public float timeBetweenObstacles = 4;


    private void Start()
    {
        InvokeRepeating("SpawnObstacle", 0f, timeBetweenObstacles);
        InvokeRepeating("ChangeTimeBetweenObstacles", 0f, 5f);
        InvokeRepeating("IncrementAdditionalSpeed", 5f, 5f);
    }

    void SpawnObstacle()
    {
        Vector3 randomSpawnPoint = RandomPointInCollider(spawnArea);
        Quaternion randomRotation = Random.rotation;

        var rand = Random.Range(0, obstaclePrefabs.Count);

        var obstacle = Instantiate(obstaclePrefabs[rand], randomSpawnPoint, randomRotation);
        obstacle.gameObject.GetComponent<Obstacle>().floatSpeed += additionalSpeed;

    }

    void IncrementAdditionalSpeed()
    {
        additionalSpeed += additionalSpeedIncrement;
    }

    void ChangeTimeBetweenObstacles()
    {
        if (timeBetweenObstacles > 0.2)
        {
            CancelInvoke("SpawnObstacle");
            timeBetweenObstacles -= 0.1f;
            InvokeRepeating("SpawnObstacle", 0f, timeBetweenObstacles);
        }

    }

    Vector3 RandomPointInCollider(CapsuleCollider collider)
    {
        float randomX = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
        float randomZ = Random.Range(collider.bounds.min.z, collider.bounds.max.z);

        return new Vector3(randomX, -90, randomZ);
    }
}
