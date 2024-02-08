using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Obstacle
{
    public int pointsMultiplier = 10;
    public float duration = 10f;

    public override void OnPlayerHit()
    {
        AudioManager.Instance.PlayOneShot(FMODEvents.Instance.coin, transform.position);
        Points.Instance.ChangePlayerPointsSpeedCoroutine(pointsMultiplier,duration);
        Destroy(gameObject);
    }
}
