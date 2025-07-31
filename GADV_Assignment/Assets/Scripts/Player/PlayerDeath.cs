using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerDeath : MonoBehaviour
{
    private Vector2 startPosition;
    private PlayerAnimator Animation;

    void Start()
    {
        startPosition = transform.position;
        Animation = GetComponent<PlayerAnimator>();
    }

    public void Die()
    {
        Animation.SetDead(true);
        Animation.SetAttacking(false);
    }

    public void Respawn()
    {
        transform.position = startPosition;
        Animation.SetDead(false);
    }
}