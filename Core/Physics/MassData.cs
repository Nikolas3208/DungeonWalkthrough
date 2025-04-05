using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Physics
{
    public struct MassData
    {
        /// <summary>
        /// Масса тела
        /// </summary>
        public float Mass { get; }

        /// <summary>
        /// Инвертироаная масса
        /// </summary>
        public float InvMass {  get; }

        /// <summary>
        /// Инерция тела
        /// </summary>
        public float Inertia { get; }

        /// <summary>
        /// Инвертированая инерия тела
        /// </summary>
        public float InvInertia { get; }

        /// <summary>
        /// Информация про массу и инерцию
        /// </summary>
        /// <param name="mass"> Масса </param>
        /// <param name="inertia"> Инерция </param>
        public MassData(float mass, float inertia)
        {
            Mass = mass;
            Inertia = inertia;

            InvMass = Mass > 0 ? 1f / Mass : 0f;
            InvInertia = Inertia > 0 ? 1f / Inertia : 0f;
        }
    }
}
