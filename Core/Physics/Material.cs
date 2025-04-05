using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Physics
{
    public struct Material
    {
        /// <summary>
        /// Плотность тела
        /// </summary>
        public float Density {  get; }

        /// <summary>
        /// Упругость тела
        /// </summary>
        public float Restitution { get; }

        /// <summary>
        /// Статическая сила трения
        /// </summary>
        public float StaticFriction { get; }

        /// <summary>
        /// Динамическая сила трения
        /// </summary>
        public float DynamicFriction { get; }


        /// <summary>
        /// Ьатериал тела
        /// </summary>
        /// <param name="density"> Плотность </param>
        /// <param name="restitution"> Упругость </param>
        /// <param name="staticFriction"> Статическая сила трения </param>
        /// <param name="dynamicFriction"> Динамическая сила трения </param>
        public Material(float density, float restitution, float staticFriction, float dynamicFriction)
        {
            Density = density;
            Restitution = restitution;
            StaticFriction = staticFriction;
            DynamicFriction = dynamicFriction;
        }

        /// <summary>
        /// Стандартный материал (2, 0.5f, 0.6f, 0.3f)
        /// </summary>
        public static Material Default => new Material(2, 0.5f, 0.6f, 0.3f);
    }
}
