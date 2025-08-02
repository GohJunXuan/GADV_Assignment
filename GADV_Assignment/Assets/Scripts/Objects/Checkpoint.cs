using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private PlayerRespawn respawn;

    private void Start()
    {
        respawn = GameObject.Find("Player").GetComponent<PlayerRespawn>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            respawn.respawnPoint = transform.position;
        }
    }
}
