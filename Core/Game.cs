using Core.Content;
using Core.Graphics;
using Core.Physics;
using Core.Window;
using SFML.Graphics;
using SFML.System;

namespace Core
{
    public class Game
    {
        /// <summary>
        /// Игровое окно
        /// </summary>
        protected GameWindow gameWindow;

        /// <summary>
        /// Физический мир
        /// </summary>
        protected World physicsWorld;

        /// <summary>
        /// Менеджер ресурсов
        /// </summary>
        protected AssetManager assetManager;

        /// <summary>
        /// Игровая камера
        /// </summary>
        protected Camera camera;

        /// <summary>
        /// Количество итераций физики на кадр
        /// </summary>
        protected int physicsIterations = 20;

        /// <summary>
        /// Игровой мир
        /// </summary>
        /// <param name="gameWindow"> игоровое окно </param>
        public Game(GameWindow gameWindow)
        {
            this.gameWindow = gameWindow;
            this.physicsWorld = new World();

            camera = new Camera(gameWindow.GetSize(), new Vector2f());

            gameWindow.Update += Update;
            gameWindow.Draw += Draw;
            gameWindow.Resize += Resize;
            gameWindow.Close += Close;
        }

        /// <summary>
        /// Запуск игры
        /// </summary>
        public void Run()
        {
            Start();
            gameWindow.Run();
        }

        /// <summary>
        /// Запуск сцены
        /// </summary>
        public virtual void Start()
        {

        }

        /// <summary>
        /// Обновление игрового окна
        /// </summary>
        /// <param name="deltaTime"> время кадра </param>
        public virtual void Update(float deltaTime)
        {
            gameWindow.SetView(new View(camera.GetCameraRect()));

            physicsWorld.Step(deltaTime, physicsIterations);
        }

        /// <summary>
        /// Рисование игрового окна
        /// </summary>
        /// <param name="e"></param>
        public virtual void Draw(WindowDrawEvent e)
        {

        }

        /// <summary>
        /// Изменение размера окна
        /// </summary>
        /// <param name="width"> Ширина </param>
        /// <param name="height"> Высота </param>
        public virtual void Resize(WindowResizeEvent e)
        {
            camera = camera.UpdateSize(new Vector2u(e.Width, e.Height));
        }

        /// <summary>
        /// Закрытие окна
        /// </summary>
        public virtual void Close()
        {

        }
    }
}
