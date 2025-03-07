using Core.Physics.Colliders;
using Core.Physics.Collision;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Core.Physics;

public class World
{
    private List<RigidBody> _rigidBodies;
    private float _gravityScale;
    public World(float gravityScale = 10)
    {
        _gravityScale = gravityScale;
        _rigidBodies = new List<RigidBody>();
    }

    public RigidBody CreateRigidBody(Collider collider, BodyType type = BodyType.Static)
    {
        var rigidBody = new RigidBody(collider, type);
        _rigidBodies.Add(rigidBody);

        return rigidBody;
    }
    public bool RemoveRigidBody(RigidBody rigidBody)
    {
        return _rigidBodies.Remove(rigidBody);
    }
    public RigidBody? GetRigidBody(Guid id) => _rigidBodies.FirstOrDefault(c => c.Id == id);
    public T? GetRigidBody<T>(Guid id) where T : RigidBody
    {
        return (T)_rigidBodies.FirstOrDefault(c => c.Id == id)!;
    }

    public void Update(Time deltaTime)
    {
        foreach (var rb in _rigidBodies)
        {
            rb.IsCollision = false;
            if (rb.Type == BodyType.Daynamic)
            {
                if (rb.IsGravity)
                    rb.Velocity += new Vector2f(0, _gravityScale * deltaTime.AsSeconds());

                foreach (var rb2 in _rigidBodies)
                {
                    if (rb.Id != rb2.Id)
                    {
                        if (rb.Collider!.Type == ColliderType.Rectangle)
                        {
                            if (rb2.Collider!.Type == ColliderType.Rectangle)
                            {
                                if (CollisionDetected.AABBvsAABB(rb.Collider.ColliderShape.AABB.UpdatePosition(rb.Position), rb2.Collider.ColliderShape.AABB.UpdatePosition(rb2.Position)))
                                {
                                    if (!rb2.IsTrigger)
                                    {
                                        if (rb.Position.Y - rb.OldPosition.Y != 0 && rb.Position.X - rb.OldPosition.X == 0)
                                            rb.Velocity = new Vector2f(rb.Velocity.X, 0);
                                        else if (rb.Position.X - rb.OldPosition.X != 0 && rb.Position.Y - rb.OldPosition.Y == 0)
                                            rb.Velocity = new Vector2f(0, rb.Velocity.Y);
                                        else if (rb.Position.X - rb.OldPosition.X != 0 && rb.Position.Y - rb.OldPosition.Y != 0)
                                            rb.Velocity = new Vector2f(0, 0);


                                        rb.IsCollision = true;
                                        if (!CollisionDetected.AABBvsAABB(rb.Collider.ColliderShape.AABB.UpdatePosition(rb.OldPosition), rb2.Collider.ColliderShape.AABB.UpdatePosition(rb2.OldPosition)))
                                        {
                                            rb.Position = rb.OldPosition;
                                        }
                                    }
                                }
                            }
                            else if (rb2.Collider!.Type == ColliderType.Circle)
                            {
                                if (CollisionDetected.AABBvsCircle(rb.Collider.ColliderShape.AABB.UpdatePosition(rb.Position), rb2.Collider.ColliderShape.Circle.UpdatePosition(rb2.Position)))
                                {
                                    rb.Velocity = new Vector2f();
                                    rb.Velocity -= new Vector2f(0, _gravityScale * deltaTime.AsSeconds());
                                }
                            }
                        }
                    }
                }
            }

            rb.Position += rb.Velocity;
        }
    }

    public void Draw(RenderTarget target, RenderStates states)
    {
        foreach (var rb in _rigidBodies)
        {
            if (rb.Collider.Type == ColliderType.Rectangle)
            {
                RectangleShape rectangle = new RectangleShape();
                rectangle.Position = rb.Collider.ColliderShape.AABB.UpdatePosition(rb.Position).Min;
                rectangle.Size = rb.Collider.ColliderShape.AABB.UpdatePosition(rb.Position).Max - rectangle.Position;
                rectangle.OutlineColor = Color.Black;
                rectangle.OutlineThickness = 2;
                rectangle.FillColor = Color.Transparent;

                if (rb.IsCollision)
                    rectangle.OutlineColor = Color.Red;

                target.Draw(rectangle, states);
            }
            else if (rb.Collider.Type == ColliderType.Circle)
            {
                CircleShape circle = new CircleShape(rb.Collider.ColliderShape.Circle.Radius);
                circle.Position = rb.Collider.ColliderShape.Circle.UpdatePosition(rb.Position).Point;
                circle.FillColor = Color.Transparent;
                circle.OutlineThickness = 2;
                circle.OutlineColor = Color.Black;

                if (rb.IsCollision)
                    circle.OutlineColor = Color.Red;
                
                target.Draw(circle, states);
            }
        }        
    }
}
