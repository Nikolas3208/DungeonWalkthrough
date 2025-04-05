using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Physics.Collision
{
    public class CollisionEvent
    {
        public Vector2f Normal { get; }

        public float Depth { get; }

        public CollisionEvent(Vector2f normal, float depth)
        {
            Normal = normal;
            Depth = depth;
        }
    }
}
