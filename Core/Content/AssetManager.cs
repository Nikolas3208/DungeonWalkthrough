namespace Core.Content;

public class AssetManager
{
    /// <summary>
    /// Сортированый именной список обектов
    /// </summary>
    private SortedDictionary<string, Asset> _assets;

    /// <summary>
    /// Путь к папке с обектами
    /// </summary>
    private string _path;

    /// <summary>
    /// Екземпляр менеджера обектов
    /// </summary>
    /// <param name="path"> Путь к обектам </param>
    public AssetManager(string path)
    {
        _path = path;
        _assets = new SortedDictionary<string, Asset>();
    }

    /// <summary>
    /// Загрузка обектов
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
    /// <param name="name"> Имя обекта </param>
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
    /// <typeparam name="T"> Тип обекта </typeparam>
    /// <param name="name"> Имя обекта </param>
    /// <returns> Обект, если имени нет в списке null </returns>
    public T? GetAsset<T>(string name) where T : Asset
    {
        if (!_assets.ContainsKey(name))
            return null;

        return (T)_assets[name];
    }
}
