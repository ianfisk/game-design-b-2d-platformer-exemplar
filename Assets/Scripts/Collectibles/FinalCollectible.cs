using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalCollectible : MonoBehaviour, ICollectible
{
    private bool isCollected = false;

    public int PointsValue => 0;

    public void OnCollected(CollectiblesBag bag)
    {
        if (isCollected)
        {
            // The sprite is hidden, but the box collider is still active and may trigger >1 times.
            return;
        }

        isCollected = true;

        Debug.Log($"YOU WIN!!! Total points = {bag.CollectedItems.Sum(x => x.PointsValue)}");
        gameObject.GetComponent<SpriteRenderer>().enabled = false;

        StartCoroutine(LoadEndSceneAsync(bag));
    }

    private IEnumerator LoadEndSceneAsync(CollectiblesBag bag)
    {
        const float minSpeed = 3f;

        var asyncLoad = SceneManager.LoadSceneAsync(SceneConstants.EndScene);
        asyncLoad.allowSceneActivation = false;

        var playerMovement = bag.gameObject.GetComponent<PlayerMovement>();

        // Slow speed from current value down to min over our load scene delay seconds.
        var endSceneDelaySeconds = 3f;
        var deltaTime = Time.deltaTime;
        var frameCountInLoadDelay = endSceneDelaySeconds / Time.deltaTime;
        var speedDelta = (playerMovement.speed - minSpeed) / frameCountInLoadDelay;

        while (endSceneDelaySeconds > 0)
        {
            endSceneDelaySeconds -= deltaTime;

            yield return new WaitForSeconds(deltaTime);
            playerMovement.speed = Math.Max(playerMovement.speed - speedDelta, minSpeed);
        }

        asyncLoad.allowSceneActivation = true;
    }
}
