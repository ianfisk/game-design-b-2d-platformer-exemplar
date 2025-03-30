using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private float? playerXOffset = null;

    void Update()
    {
        if (Math.Abs(player.transform.position.x - transform.position.x) > playerXOffset)
        {
            var playerIsOnLeftOfCamera = player.transform.position.x < transform.position.x;
            transform.position = new Vector3(
                    playerIsOnLeftOfCamera ? player.transform.position.x + playerXOffset.Value : player.transform.position.x - playerXOffset.Value,
                    transform.position.y,
                    transform.position.z);
        }
    }

    public void OnPaddingTrigger(bool isLeft)
    {
        if (playerXOffset == null)
        {
            // Set the offset only ONCE when the player initially hits a boundary. This implicitly
            // captures our offset w.r.t. whatever screen size we're on.
            Debug.Log($"Setting playerXOffset");
            Debug.Log($"player.transform.position.x = {player.transform.position.x}; transform.position.x = {transform.position.x}");

            playerXOffset = Math.Abs(player.transform.position.x - transform.position.x);
            Debug.Log($"playerXOffset = {playerXOffset}");
        }
    }
}
