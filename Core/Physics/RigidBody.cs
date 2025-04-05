using Core.Maths;
using Core.Physics.Collision;
using Core.Physics.Collision.Colliders;
using SFML.System;

namespace Core.Physics;

/// <summary>
/// Форма тела. Кргуг, многоугольник
/// </summary>
public enum BodyType
{
    Circle,
    Polygon
}
public class RigidBody
{
    public delegate void Collision(CollisionEvent e);
    public event Collision OnCollisionDetected;

    private Vector2f _position;
    private Vector2f _force;

    private float _rotation;
    private float _digrisRotation;
    private float _angularVelocity;
    private float _sin;
    private float _cos;

    /// <summary>
    /// Форма тела круг
    /// </summary>
    private Circle _circle;

    /// <summary>
    /// Форма тела многоугольник
    /// </summary>
    private Polygon _polygon;

    /// <summary>
    /// Ограничивающая рамка, выровненная по оси
    /// </summary>
    private AABB _aabb;

    /// <summary>
    /// Сушьность 
    /// </summary>
    public Entity Entity { get; set; }

    /// <summary>
    /// Уникальный ключ тела
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Позиция тела
    /// </summary>
    public Vector2f Position
    {
        get => _position;
        set
        {
            _position = value;
            if (Entity != null && !MathHelper.NearlyEqual(Entity.Position, value))
                Entity.Position = value;
        }
    }

    /// <summary>
    /// Линейная скорость тела
    /// </summary>
    public Vector2f LinearVelocity { get; set; }

    /// <summary>
    /// Угол врашения тела в грудусах
    /// </summary>
    public float Rotation 
    {
        get => _rotation;
        set 
        {
            _rotation = value;
            _digrisRotation = value * (MathF.PI / 180);
            _sin = MathF.Sin(_digrisRotation);
            _cos = MathF.Cos(_digrisRotation);
            if (Entity != null && Entity.Rotation != value)
                Entity.Rotation = value;
        } 
    }

    /// <summary>
    /// Возврашает угол рашения тела в радианах
    /// </summary>
    public float DigrisRotation { get => _digrisRotation; }

    /// <summary>
    /// Скорость врашения тела
    /// </summary>
    public float AngularVelocity 
    {
        get => _angularVelocity; 
        set 
        { 
            if (!FreezeRotation) 
                _angularVelocity = value; 
        } 
    }

    /// <summary>
    /// Тип тела (Его форма)
    /// </summary>
    public BodyType Type { get; }

    /// <summary>
    /// Информация про массу и инерцию тела
    /// </summary>
    public MassData MassData { get; set; }

    /// <summary>
    /// Материал тела. Его плотность упругость и сила трения
    /// </summary>
    public Material Material { get; set; }

    /// <summary>
    /// Тела являеться неподижным
    /// </summary>
    public readonly bool IsStatic = false;

    /// <summary>
    /// На тело влияет сила граитации
    /// </summary>
    public bool IsGravity = true;

    /// <summary>
    /// Тело не может вращаться
    /// </summary>
    public bool FreezeRotation = false;

    /// <summary>
    /// Твердое тело
    /// </summary>
    /// <param name="polygon"> Многоугольник (форма тела) </param>
    /// <param name="material"> Материал тела </param>
    /// <param name="isStatic"> Тело неподвижное? </param>
    public RigidBody(Polygon polygon, Material material, bool isStatic = false)
    {
        _polygon = polygon;
        Material = material;
        IsStatic = isStatic;

        _sin = MathF.Sin(0);
        _cos = MathF.Cos(0);

        float area = polygon.GetAreaRegularPolygon() / 100;

        float mass = area * material.Density;

        float inertia = 1f / 12 * mass * (polygon.Size.X * polygon.Size.X + polygon.Size.Y * polygon.Size.Y);

        MassData = new MassData(mass, inertia);

        Type = BodyType.Polygon;
    }

    /// <summary>
    /// Твердое тело
    /// </summary>
    /// <param name="circle"> Круг (форма тела) </param>
    /// <param name="material"> Материал тела </param>
    /// <param name="isStatic"> Тело неподвижное? </param>
    public RigidBody(Circle circle, Material material, bool isStatic)
    {
        _circle = circle;
        Material = material;
        IsStatic = isStatic;

        float area = circle.Radius * circle.Radius * MathF.PI / 100;
        float mass = area * material.Density;

        float inertia = 1f / 2 * area * circle.Radius * circle.Radius;

        MassData = new MassData(mass, inertia);

        Type = BodyType.Circle;
    }

    /// <summary>
    /// Шаг тела
    /// </summary>
    /// <param name="deltaTime"> Время кадра </param>
    /// <param name="gravity"> Сила гравитации </param>
    /// <param name="iterations"> Количество итераций физики на кадр </param>
    public void Step(float deltaTime, Vector2f gravity, int iterations)
    {
        if (IsStatic)
            return;

        if (!IsGravity)
            gravity = new Vector2f();

        float time = deltaTime / iterations;
        
        LinearVelocity += (_force + (gravity * MassData.Mass)) * time;
        Position += LinearVelocity * time;

        Rotation += AngularVelocity * MassData.Mass * time;

        _force = new Vector2f();
    }

    /// <summary>
    /// Вызываеться в момент обнаружения столкновения
    /// </summary>
    /// <param name="normal"> Направление разделения </param>
    /// <param name="depth"> Глубина </param>
    public void OnCollision(Vector2f normal, float depth)
    {
        if (OnCollisionDetected != null)
            OnCollisionDetected(new CollisionEvent(normal, depth));
    }

    /// <summary>
    /// Переместить тело на
    /// </summary>
    /// <param name="offset"> Вектор на который переносим тело </param>
    public void Move(Vector2f offset)
    {
        if (IsStatic) return;

        Position += offset;
    }

    /// <summary>
    /// Переместить тело в
    /// </summary>
    /// <param name="v"> Новая позиция тела </param>
    public void MoveTo(Vector2f v)
    {
        if (IsStatic) return;
        
        Position = v;
    }

    /// <summary>
    /// Повернуть тело на
    /// </summary>
    /// <param name="v"> Угол на который поворачиаем тело в градусах </param>
    public void Rotate(float v)
    {
        if(IsStatic) return;

        Rotation += v;
    }


    /// <summary>
    /// Повернуть тело в
    /// </summary>
    /// <param name="v"> Угол поворота в градусах </param>
    public void RotateTo(float v)
    {
        if(IsStatic) return;

        Rotation = v;
    }

    /// <summary>
    /// Добавить усилие к телу
    /// </summary>
    /// <param name="force"> Вектор силы и направления скорости </param>
    public void AddForce(Vector2f force)
    {
        if(!IsStatic)
            _force += force;
    }

    /// <summary>
    /// Добавить скорость к телу
    /// </summary>
    /// <param name="v"> Вектор силы и направления скорости </param>
    public void AddLinearVelosity(Vector2f v)
    {
        if(!IsStatic)
            LinearVelocity += v;
    }

    /// <summary>
    /// Добаить скорость ращения телу
    /// </summary>
    /// <param name="v"> Скорость и угол врашения тела </param>
    public void AddAngularVelosity(float v)
    {
        if (IsStatic) return;

        AngularVelocity += v;
    }


    /// <summary>
    /// Получить Ограничивающую рамку, выровненную по оси
    /// </summary>
    /// <returns> AABB </returns>
    public AABB GetAABB()
    {
        return Type == BodyType.Circle ? _aabb.Transform(_circle) : _aabb.Transform(_polygon);
    }

    /// <summary>
    /// Получить форму тела круг
    /// </summary>
    /// <returns> Circle </returns>
    public Circle GetCircle()
    {
        return _circle.Transform(_position);
    }

    /// <summary>
    /// Получить форму тела многоугольник
    /// </summary>
    /// <returns> Polygon </returns>
    public Polygon GetPolygon()
    {
        return _polygon.Transform(_sin, _cos, _position);
    }
}
