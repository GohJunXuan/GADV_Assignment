using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<PlayerDeath>())
        {
            collision.collider.GetComponent<PlayerDeath>().Die();
        }
    }
}
