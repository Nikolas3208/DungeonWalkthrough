using SFML.System;
using System.Numerics;

namespace Core.Physics.Collision;

public readonly struct Manifold
{
    /// <summary>
    /// Тело А
    /// </summary>
    public readonly RigidBody BodyA;

    /// <summary>
    /// Тело В
    /// </summary>
    public readonly RigidBody BodyB;

    /// <summary>
    /// Вектор разделения столкновенияы
    /// </summary>
    public readonly Vector2f Normal;

    /// <summary>
    /// Глубина столкновения
    /// </summary>
    public readonly float Depth;

    /// <summary>
    /// Первый контакт
    /// </summary>
    public readonly Vector2f Contact1;

    /// <summary>
    /// Второй контакт
    /// </summary>
    public readonly Vector2f Contact2;

    /// <summary>
    /// Количиство контактов
    /// </summary>
    public readonly int ContactCount;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="bodyA"> Тело А </param>
    /// <param name="bodyB"> Тело В </param>
    /// <param name="normal"> Вектор разделения столкновенияы </param>
    /// <param name="depth"> Глубина столкновения </param>
    /// <param name="contact1"> Первый контакт </param>
    /// <param name="contact2"> Второй контакт </param>
    /// <param name="contactCount"> Количиство контактов </param>
    public Manifold(RigidBody bodyA, RigidBody bodyB, Vector2f normal, float depth, Vector2f contact1, Vector2f contact2, int contactCount)
    {
        BodyA = bodyA;
        BodyB = bodyB;
        Normal = normal;
        Depth = depth;
        Contact1 = contact1;
        Contact2 = contact2;
        ContactCount = contactCount;
    }
}
