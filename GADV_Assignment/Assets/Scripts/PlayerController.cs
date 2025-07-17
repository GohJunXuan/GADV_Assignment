using Unity.VisualScripting;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 9.0f;
    public float jumpSpeed = 7.0f;
    public float fallSpeed = 3.5f;
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private float castDistance;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D rb;
    private float direction = 0f;
    bool isGrounded;
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
        animator.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("yVelocity", rb.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
            isGrounded = false;
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
    //Check if player is grounded
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        animator.SetBool("IsJumping", false);
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
