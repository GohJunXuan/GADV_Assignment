using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerAttack playerAttack;
    private PlayerAnimator playerAnimator;
    private SpriteFlipper spriteFlipper;    
    private GameAudioManager audioManager;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();
        playerAnimator = GetComponent<PlayerAnimator>();
        spriteFlipper = GetComponent<SpriteFlipper>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<GameAudioManager>();
    }

    void Update()
    {
        playerAnimator.SetJumping(!playerMovement.isGrounded());
        float direction = Input.GetAxisRaw("Horizontal");
        spriteFlipper.UpdateDirection(direction);

        if (Input.GetButtonDown("Jump") && playerMovement.isGrounded())
        {
            playerMovement.Jump();
            playerAnimator.SetJumping(true);
            audioManager.PlaySFX("Jump");
        }

        if (Input.GetMouseButtonDown(0))
        {
            playerAttack.Attack();
            playerAnimator.SetAttacking(true);
            audioManager.PlaySFX("Sword Swing");
        }
    }

    public void EndAttack()
    {
        playerAnimator.SetAttacking(false);
    }
}
