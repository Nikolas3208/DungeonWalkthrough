using Core.Maths;
using Core.Physics.Collision;
using Core.Physics.Collision.Colliders;
using SFML.System;

namespace Core.Physics;

/// <summary>
/// ����� ����. �����, �������������
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
    /// ����� ���� ����
    /// </summary>
    private Circle _circle;

    /// <summary>
    /// ����� ���� �������������
    /// </summary>
    private Polygon _polygon;

    /// <summary>
    /// �������������� �����, ����������� �� ���
    /// </summary>
    private AABB _aabb;

    /// <summary>
    /// ��������� 
    /// </summary>
    public Entity Entity { get; set; }

    /// <summary>
    /// ���������� ���� ����
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// ������� ����
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
    /// �������� �������� ����
    /// </summary>
    public Vector2f LinearVelocity { get; set; }

    /// <summary>
    /// ���� �������� ���� � ��������
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
    /// ���������� ���� ������� ���� � ��������
    /// </summary>
    public float DigrisRotation { get => _digrisRotation; }

    /// <summary>
    /// �������� �������� ����
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
    /// ��� ���� (��� �����)
    /// </summary>
    public BodyType Type { get; }

    /// <summary>
    /// ���������� ��� ����� � ������� ����
    /// </summary>
    public MassData MassData { get; set; }

    /// <summary>
    /// �������� ����. ��� ��������� ��������� � ���� ������
    /// </summary>
    public Material Material { get; set; }

    /// <summary>
    /// ���� ��������� ����������
    /// </summary>
    public readonly bool IsStatic = false;

    /// <summary>
    /// �� ���� ������ ���� ���������
    /// </summary>
    public bool IsGravity = true;

    /// <summary>
    /// ���� �� ����� ���������
    /// </summary>
    public bool FreezeRotation = false;

    /// <summary>
    /// ������� ����
    /// </summary>
    /// <param name="polygon"> ������������� (����� ����) </param>
    /// <param name="material"> �������� ���� </param>
    /// <param name="isStatic"> ���� �����������? </param>
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
    /// ������� ����
    /// </summary>
    /// <param name="circle"> ���� (����� ����) </param>
    /// <param name="material"> �������� ���� </param>
    /// <param name="isStatic"> ���� �����������? </param>
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
    /// ��� ����
    /// </summary>
    /// <param name="deltaTime"> ����� ����� </param>
    /// <param name="gravity"> ���� ���������� </param>
    /// <param name="iterations"> ���������� �������� ������ �� ���� </param>
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
    /// ����������� � ������ ����������� ������������
    /// </summary>
    /// <param name="normal"> ����������� ���������� </param>
    /// <param name="depth"> ������� </param>
    public void OnCollision(Vector2f normal, float depth)
    {
        if (OnCollisionDetected != null)
            OnCollisionDetected(new CollisionEvent(normal, depth));
    }

    /// <summary>
    /// ����������� ���� ��
    /// </summary>
    /// <param name="offset"> ������ �� ������� ��������� ���� </param>
    public void Move(Vector2f offset)
    {
        if (IsStatic) return;

        Position += offset;
    }

    /// <summary>
    /// ����������� ���� �
    /// </summary>
    /// <param name="v"> ����� ������� ���� </param>
    public void MoveTo(Vector2f v)
    {
        if (IsStatic) return;
        
        Position = v;
    }

    /// <summary>
    /// ��������� ���� ��
    /// </summary>
    /// <param name="v"> ���� �� ������� ����������� ���� � �������� </param>
    public void Rotate(float v)
    {
        if(IsStatic) return;

        Rotation += v;
    }


    /// <summary>
    /// ��������� ���� �
    /// </summary>
    /// <param name="v"> ���� �������� � �������� </param>
    public void RotateTo(float v)
    {
        if(IsStatic) return;

        Rotation = v;
    }

    /// <summary>
    /// �������� ������ � ����
    /// </summary>
    /// <param name="force"> ������ ���� � ����������� �������� </param>
    public void AddForce(Vector2f force)
    {
        if(!IsStatic)
            _force += force;
    }

    /// <summary>
    /// �������� �������� � ����
    /// </summary>
    /// <param name="v"> ������ ���� � ����������� �������� </param>
    public void AddLinearVelosity(Vector2f v)
    {
        if(!IsStatic)
            LinearVelocity += v;
    }

    /// <summary>
    /// ������� �������� ������� ����
    /// </summary>
    /// <param name="v"> �������� � ���� �������� ���� </param>
    public void AddAngularVelosity(float v)
    {
        if (IsStatic) return;

        AngularVelocity += v;
    }


    /// <summary>
    /// �������� �������������� �����, ����������� �� ���
    /// </summary>
    /// <returns> AABB </returns>
    public AABB GetAABB()
    {
        return Type == BodyType.Circle ? _aabb.Transform(_circle) : _aabb.Transform(_polygon);
    }

    /// <summary>
    /// �������� ����� ���� ����
    /// </summary>
    /// <returns> Circle </returns>
    public Circle GetCircle()
    {
        return _circle.Transform(_position);
    }

    /// <summary>
    /// �������� ����� ���� �������������
    /// </summary>
    /// <returns> Polygon </returns>
    public Polygon GetPolygon()
    {
        return _polygon.Transform(_sin, _cos, _position);
    }
}
