using System.Collections;
using UnityEngine;

public class UpwardBarsGenerator : MonoBehaviour
{
    public int numberOfBars = 5; // Liczba pasków do wygenerowania
    public float spacing = 2f; // Odstêp miêdzy paskami
    public float speed = 5f; // Prêdkoœæ poruszania siê pasków
    public float lifetime = 5f; // Czas ¿ycia pasków

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

            // Ustawiamy prêdkoœæ poruszania siê paska
            newBar.GetComponent<Rigidbody>().velocity = Vector3.up * speed;

            // Zniszcz pasek po okreœlonym czasie
            Destroy(newBar, lifetime);
        }

        yield return null;
    }
}