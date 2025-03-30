public interface ICollectible
{
    int PointsValue { get; }

    void OnCollected(CollectiblesBag bag);
}
