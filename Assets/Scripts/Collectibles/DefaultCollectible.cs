using UnityEngine;

public class DefaultCollectible : MonoBehaviour, ICollectible
{
    public int pointsValue;

    public int PointsValue => pointsValue;

    public void OnCollected(CollectiblesBag bag)
    {
        gameObject.SetActive(false);
    }
}
