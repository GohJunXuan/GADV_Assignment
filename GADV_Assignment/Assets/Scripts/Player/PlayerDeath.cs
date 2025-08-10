using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerDeath : MonoBehaviour
{
    private PlayerAnimator playerAnimator;
    private GameAudioManager audioManager;

    void Start()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<GameAudioManager>();
    }

    public void Die()
    {
        playerAnimator.SetDead(true);
        playerAnimator.SetAttacking(false);
        audioManager.PlaySFX(audioManager.DeathSFX);
    }
}