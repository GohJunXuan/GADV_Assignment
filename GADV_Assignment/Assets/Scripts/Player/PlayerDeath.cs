using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerDeath : MonoBehaviour
{
    private PlayerAnimator animationController;

    void Start()
    {
        animationController = GetComponent<PlayerAnimator>();
    }

    public void Die()
    {
        animationController.SetDead(true);
        animationController.SetAttacking(false);
    }
}