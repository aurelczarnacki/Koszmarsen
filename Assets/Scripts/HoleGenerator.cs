using UnityEngine;

public class HoleGenerator : MonoBehaviour
{
    public GameObject objectPrefab;
    public int numberOfObjects = 3;
    public float moveSpeed = 5f;
    public float generationDistance = 10f;

    private GameObject[] objects;
    private int currentIndex = 0;

    private void Start()
    {
        InvokeRepeating("IncreaseMoveSpeed", 3f, 3f);
        objects = new GameObject[numberOfObjects];

        for (int i = 0; i < numberOfObjects; i++)
        {
            GenerateNewObject(i);
        }
    }

    private void Update()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            objects[i].transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }

        if (objects[currentIndex].transform.position.y > generationDistance)
        {
            objects[currentIndex].transform.position -= Vector3.up * numberOfObjects * generationDistance;

            currentIndex = (currentIndex + 1) % numberOfObjects;
        }
    }

    void IncreaseMoveSpeed()
    {
        moveSpeed += 1;
    }

    void GenerateNewObject(int index)
    {
        objects[index] = Instantiate(objectPrefab, transform.position - Vector3.up * index * generationDistance, Quaternion.identity, transform);
    }
}
