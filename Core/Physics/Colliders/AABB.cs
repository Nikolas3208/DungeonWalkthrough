using SFML.System;

namespace Core.Physics.Colliders;

public struct AABB
{
    public Vector2f Min { get; private set; }
    public Vector2f Max { get; private set; }

    public AABB(Vector2f min, Vector2f max)
    {
        Min = min;
        Max = max;
    }

    public AABB(Vector2f max)
    {
        Min = new Vector2f();
        Max = max;
    }

    public AABB UpdatePosition(Vector2f position) => new AABB(Min + position, Max + position);

}
