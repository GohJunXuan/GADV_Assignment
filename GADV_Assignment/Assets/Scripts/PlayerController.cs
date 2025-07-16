using Unity.VisualScripting;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 9.0f;
    public float jumpSpeed = 7.0f;
    public float fallSpeed = 3.5f;
    private float animSpeed = 0f;
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private float castDistance;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D rb;
    private float direction = 0f;
    public Animator animator;
    bool isFacingLeft = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //Player Movement
    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);

        animSpeed = rb.linearVelocity.x;
        animator.SetFloat("AnimSpeed", Mathf.Abs(animSpeed));

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
            animator.SetBool("IsJumping", true);
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
    //Check if player is on the ground
    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //Show box for grounded detection
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
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
