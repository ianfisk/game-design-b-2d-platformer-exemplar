using System.Linq;
using UnityEngine;

public class FinalCollectible : MonoBehaviour, ICollectible
{
    public int PointsValue => 0;

    public void OnCollected(CollectiblesBag bag)
    {
        gameObject.SetActive(false);
        Debug.Log($"YOU WIN!!! Total points = {bag.CollectedItems.Sum(x => x.PointsValue)}");
    }
}
