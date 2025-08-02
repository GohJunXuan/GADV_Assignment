using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Vector3 respawnPoint;
    private PlayerAnimator animationController;

    private void Start()
    {
        animationController = GetComponent<PlayerAnimator>();
        respawnPoint = transform.position;
    }

    public void Respawn()
    {
        transform.position = respawnPoint;
        animationController.SetDead(false);
    }
}
