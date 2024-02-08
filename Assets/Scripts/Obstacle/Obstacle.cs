using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float floatSpeed;
    public float rotationSpeed;
    private void Start()
    {
        float randomRotationSpeed = Random.Range(-rotationSpeed, rotationSpeed);
        Vector3 randomRotationAxis = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        GetComponent<Rigidbody>().angularVelocity = randomRotationAxis * randomRotationSpeed;
    }

    private void Update()
    {
        if (this.transform.position.y <= 20)
        {
            this.transform.position += new Vector3(0, floatSpeed, 0) * Time.deltaTime;
        }
        else
            Destroy(gameObject);

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            OnPlayerHit();
        }
    }
    public virtual void OnPlayerHit()
    {
        PlayerHp.Instance.TakeDamage();
    }
}
