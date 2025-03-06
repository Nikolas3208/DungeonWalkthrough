namespace Core.Utils.TmxLoader;

public class TileFrame
{
    public int TileId { get; set; }
    public float Duration { get; set; }

    public TileFrame(int tileId, float duration)
    {
        TileId = tileId;
        Duration = duration;
    }
}
