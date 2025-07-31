using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    bool isFacingLeft = true;

    public void UpdateDirection(float direction)
    {
        if (direction > 0 && isFacingLeft)
        {
            Flip();
        }
        else if (direction < 0 && !isFacingLeft)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        isFacingLeft = !isFacingLeft;
    }
}
