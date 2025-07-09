using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8.0f;
    public float jumpSpeed = 7.0f;
    public float fallSpeed = 3.5f;
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private float castDistance;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D rb;
    private float direction = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //Movement
    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
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
    //Detect if player is on the ground
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

    //Draw box for ground detection
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
}
