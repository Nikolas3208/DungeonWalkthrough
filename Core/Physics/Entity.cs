using Core.Maths;
using Core.Physics.Collision;
using SFML.Graphics;
using SFML.System;

namespace Core.Physics;

public class Entity : Transformation, Drawable
{
    /// <summary>
    /// ������� ����
    /// </summary>
    public RigidBody Body { get; set; }

    /*
    /// <summary>
    /// ������ ��������. ���� ���� �� null ��� ������� ���������
    /// </summary>
    public new Vector2f Position 
    {
        get => base.Position;
        set
        {
            base.Position = value;
            
            if(Body != null && !MathHelper.NearlyEqual(Body.Position, value))
                Body.Position = value;

            UpdateTransform();
        }
    }

    /// <summary>
    /// �������� ��������. ���� ���� �� null ��� �������� ���������
    /// </summary>
    public new float Rotation 
    {
        get => base.Rotation;
        set
        {
            base.Rotation = value;

            if (Body != null && Body.Rotation != value)
                Body.Rotation = value;
            
            UpdateTransform();
        }
    }
    */

    /// <summary>
    /// ��������
    /// </summary>
    /// <param name="body"> ���� </param>
    public Entity(RigidBody body)
    {
        body.Entity = this;
        body.OnCollisionDetected += OnCollisionUpdate;

        Body = body;
    }


    /// <summary>
    /// ���������� ��������
    /// </summary>
    /// <param name="deltaTime"> ����� ����� </param>
    public virtual void Update(float deltaTime)
    {
        
    }

    public virtual void OnCollisionUpdate(CollisionEvent e)
    {

    }

    /// <summary>
    /// �������� ��������
    /// </summary>
    /// <param name="target"></param>
    /// <param name="states"></param>
    public virtual void Draw(RenderTarget target, RenderStates states)
    {

    }
}
