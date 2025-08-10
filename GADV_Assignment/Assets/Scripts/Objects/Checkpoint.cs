using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private PlayerRespawn playerRespawn;

    private void Start()
    {
        playerRespawn = GameObject.Find("Player").GetComponent<PlayerRespawn>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerRespawn.respawnPoint = transform.position;
        }
    }
}
