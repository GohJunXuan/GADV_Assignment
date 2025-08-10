using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Vector3 respawnPoint;
    private PlayerAnimator playerAnimator;

    private void Start()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        respawnPoint = transform.position;
    }

    public void Respawn()
    {
        transform.position = respawnPoint;
        playerAnimator.SetDead(false);
    }
}
