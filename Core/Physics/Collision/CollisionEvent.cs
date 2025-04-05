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
        /// <summary>
        /// Вектор нормали
        /// </summary>
        public Vector2f Normal { get; }

        /// <summary>
        /// Глубина
        /// </summary>
        public float Depth { get; }

        /// <summary>
        /// Событие столкновения
        /// </summary>
        /// <param name="normal"> Вектор нормали </param>
        /// <param name="depth"> Глубина </param>
        public CollisionEvent(Vector2f normal, float depth)
        {
            Normal = normal;
            Depth = depth;
        }
    }
}
