using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement movement;
    private PlayerAttack attack;
    private PlayerAnimator animationController;
    private SpriteFlipper flipper;

    void Start()
    {
        movement = GetComponent<PlayerMovement>();
        attack = GetComponent<PlayerAttack>();
        animationController = GetComponent<PlayerAnimator>();
        flipper = GetComponent<SpriteFlipper>();
    }

    void Update()
    {
        animationController.SetJumping(!movement.isGrounded());
        float direction = Input.GetAxisRaw("Horizontal");
        flipper.UpdateDirection(direction);

        if (Input.GetButtonDown("Jump"))
        {
            movement.Jump();
        }

        if (Input.GetMouseButtonDown(0))
        {
            attack.Attack();
            animationController.SetAttacking(true);
        }
    }

    public void EndAttack()
    {
        animationController.SetAttacking(false);
    }
}
