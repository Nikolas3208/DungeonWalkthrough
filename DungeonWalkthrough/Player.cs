using Core.Animation;
using Core.Content;
using Core.Graphics;
using Core.Physics;
using Core.Physics.Transformation;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace DungeonWalkthrough;

public class Player : TransformObject, Drawable
{
    private float speed = 2;
    private float maxSpeed = 3.7f;

    private RigidBody rb;
    private Camera _camera;
    private Animator _animator;
    AnimSprite idle;
    public Player(RigidBody rb, Camera camera)
    {
        this.rb = rb;
        _camera = camera;

        var ss = new SpriteSheet(6, 8, true, 0, Game.AssetManager!.GetAsset<SpriteAsset>("Warrior_Red")!.Sprite);
        _animator = new Animator();

        var anim = new Animation("Idle");
        anim.SetAnimationFrames(
            new AnimationFrame(0, 0, 0.4f),
            new AnimationFrame(1, 1, 0.4f),
            new AnimationFrame(2, 2, 0.4f),
            new AnimationFrame(3, 3, 0.4f),
            new AnimationFrame(4, 4, 0.4f),
            new AnimationFrame(5, 5, 0.4f));

        idle = new AnimSprite(ss);
        idle.Scale = new Vector2f(0.8f, 0.8f);
        _animator.Origin = new Vector2f(ss.SubWidth / 4, ss.SubHeight / 3);

        anim.SetAnimSprite(idle);

        _animator.AddAnimation("Idle", anim);

        var anim2 = new Animation("Run");
        anim2.SetAnimationFrames(
            new AnimationFrame(6, 6, 0.4f),
            new AnimationFrame(7, 7, 0.4f),
            new AnimationFrame(8, 8, 0.4f),
            new AnimationFrame(9, 9, 0.4f),
            new AnimationFrame(10, 10, 0.4f),
            new AnimationFrame(11, 11, 0.4f));

        var animSprite2 = new AnimSprite(ss);
        animSprite2.Scale = new Vector2f(0.8f, 0.8f);

        anim2.SetAnimSprite(animSprite2);

        _animator.AddAnimation("Run", anim2);
    }

    public void Update(Time deltaTime)
    {
        bool isMoveUp = Keyboard.IsKeyPressed(Keyboard.Key.W);
        bool isMoveDown = Keyboard.IsKeyPressed(Keyboard.Key.S);
        bool isMoveLeft = Keyboard.IsKeyPressed(Keyboard.Key.A);
        bool isMoveRight = Keyboard.IsKeyPressed(Keyboard.Key.D);

        bool isMove = isMoveUp || isMoveDown || isMoveLeft || isMoveRight;
        bool isHorivontalMove = isMoveLeft || isMoveRight;
        bool isVerticalMove = isMoveUp || isMoveDown;

        if (isMove)
        {
            _animator.Play("Run");
            if (isVerticalMove)
            {
                //rb.Velocity = new Vector2f(rb.Velocity.X, 0);
                
                if (isMoveUp)
                {
                    rb.Velocity -= new Vector2f(0, speed * deltaTime.AsSeconds());
                    if (rb.Velocity.Y <= -maxSpeed)
                        rb.Velocity = new Vector2f(rb.Velocity.X, -maxSpeed);
                }
                if (isMoveDown)
                {
                    rb.Velocity += new Vector2f(0, speed * deltaTime.AsSeconds());
                    if (rb.Velocity.Y >= maxSpeed)
                        rb.Velocity = new Vector2f(rb.Velocity.X, maxSpeed);
                }
            }
            else
            {
                rb.Velocity = new Vector2f(rb.Velocity.X, 0);
            }
            if (isHorivontalMove)
            {
                //rb.Velocity = new Vector2f(0, rb.Velocity.Y);

                if (isMoveLeft)
                {
                    _animator.Scale = new Vector2f(-1, 1);
                    _animator.Origin = new Vector2f(192 / 2, 192 / 3);
                    rb.Velocity -= new Vector2f(speed * deltaTime.AsSeconds(), 0);
                    if (rb.Velocity.X <= -maxSpeed)
                        rb.Velocity = new Vector2f(-maxSpeed, rb.Velocity.Y);
                }
                if (isMoveRight)
                {
                    _animator.Scale = new Vector2f(1, 1);
                    _animator.Origin = new Vector2f(192 / 4, 192 / 3);
                    rb.Velocity += new Vector2f(speed * deltaTime.AsSeconds(), 0);
                    if (rb.Velocity.X >= maxSpeed)
                        rb.Velocity = new Vector2f(maxSpeed, rb.Velocity.Y);
                }
            }
            else
            {
                rb.Velocity = new Vector2f(0, rb.Velocity.Y);
            }
        }
        else
        {
            //_animator.Origin = new Vector2f(192 / 4, 192 / 3);
            _animator.Play("Idle");

            rb.Velocity = new Vector2f();
        }

        UpdateTransform(rb);
        Vector2f camPos = Position - (Vector2f)(_camera.Size / 2);
        _camera = _camera.SetPosition(camPos);
    }

    public void Draw(RenderTarget target, RenderStates states)
    {
        states.Transform *= Transform;



        _animator.Draw(target, states);
    }
}
