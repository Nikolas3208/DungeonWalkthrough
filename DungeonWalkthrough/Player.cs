using Core.Animation;
using Core.Content;
using Core.Graphics;
using Core.Physics;
using Core.Physics.Collision;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace DungeonWalkthrough;

public class Player : Entity
{
    private float speed = 10;

    private Camera _camera;
    private Animator _animator;
    AnimSprite idle;

    public Player(RigidBody body, AssetManager assetManager, Camera camera) : base(body)
    {
        _camera = camera;

        var ss = new SpriteSheet(6, 8, true, 0, assetManager!.GetAsset<SpriteAsset>("Warrior_Red")!.Sprite);
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

        anim2.SetAnimSprite(animSprite2);

        _animator.AddAnimation("Run", anim2);
    }

    bool isGrounded = false;

    public override void OnCollisionUpdate(CollisionEvent e)
    {
        base.OnCollisionUpdate(e);

        if(e.Normal == new Vector2f(0, -1))
        {
            isGrounded = true;
        }
    }

    public Camera Update(float deltaTime)
    {
        bool isMoveUp = Keyboard.IsKeyPressed(Keyboard.Key.W);
        bool isMoveDown = Keyboard.IsKeyPressed(Keyboard.Key.S);
        bool isMoveLeft = Keyboard.IsKeyPressed(Keyboard.Key.A);
        bool isMoveRight = Keyboard.IsKeyPressed(Keyboard.Key.D);

        bool isMove = isMoveUp || isMoveDown || isMoveLeft || isMoveRight;
        bool isHorivontalMove = isMoveLeft || isMoveRight;
        bool isVerticalMove = isMoveUp || isMoveDown;

        if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && isGrounded)
        {
            Body.AddLinearVelosity(new Vector2f(0, -100f));
        }

        if (isMove)
        {
            _animator.Play("Run");
            if (isVerticalMove)
            {
                if (isMoveUp)
                {
                    Body.AddLinearVelosity(-new Vector2f(0, speed));
                }
                if (isMoveDown)
                {
                    Body.AddLinearVelosity(new Vector2f(0, speed));
                }
            }
            if (isHorivontalMove)
            {
                if (isMoveLeft)
                {
                    _animator.Scale = new Vector2f(-1, 1);
                    Body.AddLinearVelosity(new Vector2f(-speed, 0));
                }
                if (isMoveRight)
                {
                    _animator.Scale = new Vector2f(1, 1);
                    Body.AddLinearVelosity(new Vector2f(speed, 0));
                }
            }
        }
        else
        {
            _animator.Play("Idle");
        }

        isGrounded = false;

        return _camera = _camera.UpdatePosition(Position);
    }

    public override void Draw(RenderTarget target, RenderStates states)
    {
        states.Transform *= Transform;

        _animator.Draw(target, states);
    }   
}
