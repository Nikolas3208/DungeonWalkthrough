namespace Common.Content;

public class Asset
{
    public string Name { get; } = string.Empty;
    public string FullPath { get; } = string.Empty;
    public Guid Id { get; }

    public AssetEnum Type { get; protected set; }

    public Asset(string name, string fullPath)
    {
        Name = name;
        FullPath = fullPath;
        Id = Guid.NewGuid();
        Type = AssetEnum.None;
    }
}