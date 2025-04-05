using Core.Maths;
using Core.Physics.Collision;
using SFML.Graphics;
using SFML.System;

namespace Core.Physics;

public class Entity : Transformation, Drawable
{
    /// <summary>
    /// Твердое тело
    /// </summary>
    public RigidBody Body { get; set; }

    /*
    /// <summary>
    /// Позиия сущности. Если тело не null его позицию обновляем
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
    /// Вращение сущности. Если тело не null его вращение обновляем
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
    /// Сущность
    /// </summary>
    /// <param name="body"> Тело </param>
    public Entity(RigidBody body)
    {
        body.Entity = this;
        body.OnCollisionDetected += OnCollisionUpdate;

        Body = body;
    }


    /// <summary>
    /// Обновление сущности
    /// </summary>
    /// <param name="deltaTime"> время кадра </param>
    public virtual void Update(float deltaTime)
    {
        
    }

    public virtual void OnCollisionUpdate(CollisionEvent e)
    {

    }

    /// <summary>
    /// Рисовать сущность
    /// </summary>
    /// <param name="target"></param>
    /// <param name="states"></param>
    public virtual void Draw(RenderTarget target, RenderStates states)
    {

    }
}
