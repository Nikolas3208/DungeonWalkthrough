namespace Common.Content;
public class AssetManager
{
    private string _path;
    private SortedDictionary<string, Asset> _assets;

    public AssetManager(string path)
    {
        _path = path;
        _assets = new SortedDictionary<string, Asset>();
    }

    public void Load()
    {
        var files = Directory.GetFiles(_path, "*", SearchOption.AllDirectories);

        foreach (var file in files)
        {
            string name = Path.GetFileName(file);
            name = name.Remove(name.IndexOf('.'));

            if (!_assets.ContainsKey(name))
            {
                if (file.Contains(".png") || file.Contains(".jpg"))
                    _assets.Add(name, new TextureAsset(name, file));
            }
        }
    }

    public Asset? GetAsset(string name)
    {
        if (_assets.ContainsKey(name))
            return _assets[name];

        return null;
    }

    public T? GetAsset<T>(string name) where T : Asset
    {
        if (_assets.ContainsKey(name))
            return (T)_assets[name];

        return null;
    }

    public List<Asset>? GetAssetsSort(AssetEnum type = AssetEnum.None, string sort = "")
    {
        var assets = _assets
            .Where(a => a.Value.Type == type && a.Value.Name.ToLower().Contains(sort.ToLower()))
            .ToDictionary()
            .Values.ToList();

        return assets;
    }

    public List<T>? GetAssetsSort<T>(AssetEnum type = AssetEnum.None, string sort = "") where T : Asset
    {
        var assets = _assets
            .Where(a => a.Value.Type == type && a.Value.Name.ToLower().Contains(sort.ToLower()))
            .ToDictionary()
            .Values.Cast<T>().ToList();

        return assets;
    }

    public int GetAssetCount() => _assets.Count;
}