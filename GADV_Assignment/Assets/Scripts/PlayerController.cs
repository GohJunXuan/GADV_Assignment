using Unity.VisualScripting;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 9.0f;
    public float jumpSpeed = 7.0f;
    public float fallSpeed = 3.5f;
    public float bounceSpeed = 6.0f;
    private Rigidbody2D rb;
    private float direction = 0f;
    bool isGrounded;
    public GameObject swordHitBox;
    public float hitBoxRadius;
    public LayerMask spikes;
    public Animator animator;
    bool isFacingLeft = true;
    Vector2 startPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    //Player Movement
    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
        animator.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("yVelocity", rb.linearVelocity.y);

        //Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
            isGrounded = false;
            animator.SetBool("IsJumping", true);
        }

        //Sword Swing
        if(Input.GetMouseButtonDown(0))
        {
            animator.SetBool("IsAttacking", true);
        }

        //Flip player
        if (direction > 0 && isFacingLeft)
        {
            flipPlayer();
        }
        else if (direction < 0 && !isFacingLeft)
        {
            flipPlayer();
        }
    }

    //Make player fall faster
    private void FixedUpdate()
    {
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics.gravity.y * fallSpeed * Time.deltaTime;
        }
    }
    //Check if player is grounded
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        animator.SetBool("IsJumping", false);
    }

    //Sword Swing
    public void attack()
    {
        Collider2D[] collision = Physics2D.OverlapCircleAll(swordHitBox.transform.position, hitBoxRadius, spikes);

        foreach (Collider2D spikes in collision)
        {
            Debug.Log("Collision detected");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceSpeed);
        }
    }

    //End attack animation
    public void endAttack()
    {
        animator.SetBool("IsAttacking", false);
    }

    //Draw sword hitbox
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(swordHitBox.transform.position, hitBoxRadius);
    }

    //Play death animation
    public void death()
    {
        animator.SetBool("IsDead", true);
    }

    //Respawn Player
    public void respawn()
    {
        animator.SetBool("IsDead", false);
        transform.position = startPosition;
    }

    //Flip player sprite based on direction
    void flipPlayer()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        isFacingLeft = !isFacingLeft;
    }
}
