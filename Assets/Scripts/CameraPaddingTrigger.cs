using UnityEngine;

public class CameraPaddingTrigger : MonoBehaviour
{
    public bool isLeft;
    public CameraController cameraController;

    void OnTriggerEnter2D(Collider2D other)
    {
        var isPlayer = other.GetComponent<PlayerMovement>() != null;
        if (isPlayer)
        {
            cameraController.OnPaddingTrigger(isLeft);
        }
    }
}
