using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator animationController;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        animationController.SetFloat("xVelocity", Mathf.Abs(moveInput));
        animationController.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    public void SetJumping(bool isJumping)
    {
        animationController.SetBool("IsJumping", isJumping);
    }

    public void SetAttacking(bool isAttacking)
    {
        animationController.SetBool("IsAttacking", isAttacking);
    }

    public void SetDead(bool isDead)
    {
        animationController.SetBool("IsDead", isDead);
    }
}
