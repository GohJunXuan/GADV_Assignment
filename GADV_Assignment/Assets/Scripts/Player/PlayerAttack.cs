using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject swordHitBox;
    public float hitBoxRadius;
    public LayerMask spikes;
    public float bounceSpeed = 6.0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Attack()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(swordHitBox.transform.position, hitBoxRadius, spikes);
        foreach (Collider2D spikes in hit)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceSpeed);
        }
    }

    //See hitbox in scene view
    void OnDrawGizmos()
    {
        if (swordHitBox != null)
            Gizmos.DrawWireSphere(swordHitBox.transform.position, hitBoxRadius);
    }
}
