namespace Core.Content;

public class AssetManager
{
    /// <summary>
    /// Сортированый именной список обектов
    /// </summary>
    private SortedDictionary<string, Asset> _assets;

    /// <summary>
    /// Путь к папке с ассетами
    /// </summary>
    private string _path;

    /// <summary>
    /// Екземпляр менеджера обектов
    /// </summary>
    /// <param name="path"> Путь к ассетам </param>
    public AssetManager(string path)
    {
        _path = path;
        _assets = new SortedDictionary<string, Asset>();
    }

    /// <summary>
    /// Загрузка ассутов
    /// </summary>
    public void LoadAssets()
    {
        if (!Directory.Exists(_path))
            return;

        var files = Directory.GetFiles(_path, "*", SearchOption.AllDirectories);

        foreach (var file in files)
        {
            string name = Path.GetFileNameWithoutExtension(file);

            if (!_assets.ContainsKey(name))
            {
                if (file.Contains(".png") || file.Contains(".jpg"))
                    _assets.Add(name, new SpriteAsset(name, file));
            }
        }
    }

    /// <summary>
    /// Получить обект
    /// </summary>
    /// <param name="name"> Имя ассота </param>
    /// <returns> Обект, null если имени нет в списке </returns>
    public Asset? GetAsset(string name)
    {
        if (!_assets.ContainsKey(name))
            return null;

        return _assets[name];
    }


    /// <summary>
    /// Получить обект и преобразовать тип
    /// </summary>
    /// <typeparam name="T"> Тип ассота </typeparam>
    /// <param name="name"> Имя обекта </param>
    /// <returns> Обект, если имени нет в списке null </returns>
    public T? GetAsset<T>(string name) where T : Asset
    {
        if (!_assets.ContainsKey(name))
            return null;

        return (T)_assets[name];
    }

    /// <summary>
    /// Получить сортированый массив обекто
    /// </summary>
    /// <param name="type"> Тип ассота </param>
    /// <param name="sort"> Имя </param>
    /// <returns> Сортированый списов по имени и типу </returns>
    public List<Asset>? GetSortAssets(AssetType type = AssetType.None, string sort = "")
    {
        List<Asset> assets = new List<Asset>();

        if (type != AssetType.None)
        {
            assets = _assets.Values.Where(a => a.Type == type).ToList();
        }

        if (sort != "" && assets != null)
        {
            assets = assets.Where(a => a.Name.ToLower().Contains(sort.ToLower())).ToList();
        }

        return assets;
    }

    /// <summary>
    /// Получить сортированый список 
    /// </summary>
    /// <typeparam name="T"> Тип екземпляра обекта </typeparam>
    /// <param name="type"> Тип ассота </param>
    /// <param name="sort"> Имя </param>
    /// <returns> Сортированый список по имени и типу приведеннй к типу </returns>
    public List<T>? GetSortAssets<T>(AssetType type = AssetType.None, string sort = "") where T : Asset
    {
        List<T> assets = new List<T>();
        if (type != AssetType.None)
        {
            assets = _assets.Values.Where(a => a.Type == type).Cast<T>().ToList();
        }

        if (sort != "" && assets != null)
        {
            assets = assets.Where(a => a.Name.ToLower().Contains(sort.ToLower())).ToList();
        }

        return assets;
    }

    /// <summary>
    /// Список всех ассотов
    /// </summary>
    /// <returns> Список ассетов </returns>
    public List<Asset> GetAssets()
    {
        return _assets.Values.ToList();
    }
}
