using System.Collections.Generic;
using UnityEngine;

// TODO: Visitor pattern?
public class CollectiblesBag : MonoBehaviour
{
    private List<ICollectible> collectedItems = new List<ICollectible>();

    public IReadOnlyList<ICollectible> CollectedItems => collectedItems.AsReadOnly();

    void OnTriggerEnter2D(Collider2D other)
    {
        var collectible = other.GetComponent<ICollectible>();
        if (collectible != null)
        {
            collectedItems.Add(collectible);
            collectible.OnCollected(this);
        }
    }
}
