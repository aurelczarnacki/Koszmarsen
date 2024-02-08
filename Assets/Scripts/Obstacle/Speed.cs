using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : Obstacle
{
    public float speedMultiplier = 2f;
    public float duration = 10f;

    public override void OnPlayerHit()
    {
        AudioManager.Instance.PlayOneShot(FMODEvents.Instance.speed, transform.position);
        CharacterMovement.Instance.ChangePlayerSpeedCoroutine(speedMultiplier, duration);
        Destroy(gameObject);
    }
}
