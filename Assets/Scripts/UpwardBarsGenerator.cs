using System.Collections;
using UnityEngine;

public class UpwardBarsGenerator : MonoBehaviour
{
    public int numberOfBars = 5; // Liczba pask�w do wygenerowania
    public float spacing = 2f; // Odst�p mi�dzy paskami
    public float speed = 5f; // Pr�dko�� poruszania si� pask�w
    public float lifetime = 5f; // Czas �ycia pask�w

    public GameObject barPrefab; // Prefab paska

    private void Start()
    {
        StartCoroutine(GenerateBars());
    }

    IEnumerator GenerateBars()
    {
        for (int i = 0; i < numberOfBars; i++)
        {
            // Tworzymy nowy obiekt paska
            GameObject newBar = Instantiate(barPrefab, transform.position + Vector3.right * i * spacing, Quaternion.identity);

            // Ustawiamy pr�dko�� poruszania si� paska
            newBar.GetComponent<Rigidbody>().velocity = Vector3.up * speed;

            // Zniszcz pasek po okre�lonym czasie
            Destroy(newBar, lifetime);
        }

        yield return null;
    }
}