namespace Core.Animation;

public class Animator
{
    /// <summary>
    /// Именной список анимаций
    /// </summary>
    private SortedDictionary<string, Animation> _animations;

    public Animator()
    {
        _animations = new SortedDictionary<string, Animation>();
    }

    /// <summary>
    /// Добавить анимаию
    /// </summary>
    /// <param name="name"> Имя анимаии </param>
    /// <param name="animation"> Анимаия </param>
    /// <returns> Если анимации с таким именем нет возвращает true </returns>
    public bool AddAnimation(string name, Animation animation)
    {
        if (_animations.ContainsKey(name))
            return false;

        _animations.Add(name, animation);
        return true;
    }

    /// <summary>
    /// Удалить анимацию
    /// </summary>
    /// <param name="name"> Имя анимаии </param>
    /// <returns> Если анимаие не найдена возвращает false </returns>
    public bool RemoveAnimation(string name)
    {
        if (!_animations.ContainsKey(name))
            return false;

        return _animations.Remove(name);
    }

    /// <summary>
    /// Получить анимацию
    /// </summary>
    /// <param name="name"> Имя анимации </param>
    /// <returns> Если анимаия не найдена возвращает null </returns>
    public Animation? GetAnimation(string name)
    {
        if (!_animations.ContainsKey(name))
            return null;

        return _animations[name];
    }
}
