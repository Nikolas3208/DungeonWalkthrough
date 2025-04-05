using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Window
{
    public class WindowUpdateEvent
    { 
        public float DeltaTime;

        public WindowUpdateEvent(float deltaTime)
        {
            DeltaTime = deltaTime;
        }
    }

    public class WindowDrawEvent
    {
        public RenderTarget Target;
        public RenderStates States;

        public float DeltaTime;

        public WindowDrawEvent(RenderTarget target, RenderStates states, float deltaTime)
        {
            Target = target;
            States = states;
            DeltaTime = deltaTime;
        }
    }

    public class WindowResizeEvent
    {
        public uint Width;
        public uint Height;

        public WindowResizeEvent(uint width, uint height)
        {
            Width = width;
            Height = height;
        }
    }
}
