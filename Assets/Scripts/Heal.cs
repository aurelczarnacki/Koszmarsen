using UnityEngine;

public class Heal : Obstacle
{
    public override void OnPlayerHit()
    {
        PlayerHp.Instance.Heal();
        Destroy(gameObject);
    }
}
