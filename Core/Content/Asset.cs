namespace Core.Content;

public class Asset
{
    /// <summary>
    /// Имя обекта
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Путь к файлу
    /// </summary>
    public string FullPath { get; }

    /// <summary>
    /// Тип обекта
    /// </summary>
    public AssetType Type { get; protected set; }

    /// <summary>
    /// Екземпляр обекта
    /// </summary>
    /// <param name="name"> Имя </param>
    /// <param name="fullPath"> Путь к файлу </param>
    /// <param name="type"> Тип </param>
    public Asset(string name, string fullPath)
    {
        Name = name;
        FullPath = fullPath;
        Type = AssetType.None;
    }
}
