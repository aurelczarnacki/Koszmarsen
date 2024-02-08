using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Obstacle
{
    public float duration = 10f;

    public override void OnPlayerHit()
    {
        AudioManager.Instance.PlayOneShot(FMODEvents.Instance.ghostMode, transform.position);
        PlayerHp.Instance.SetPlayerToUnkillableCoroutine(duration);
        Destroy(gameObject);
    }
}
