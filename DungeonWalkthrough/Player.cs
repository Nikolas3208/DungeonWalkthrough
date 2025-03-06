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
    private RigidBody rb;
    private Animator animator;

    public Player(RigidBody rb)
    {
        this.rb = rb;

        var ss = new SpriteSheet(6, 8, true, 0, Game.AssetManager!.GetAsset<SpriteAsset>("Warrior_Red")!.Sprite);
        animator = new Animator();
        animator.Origin = new Vector2f(-28, animator.Origin.Y - 15);

        var anim = new Animation("Idle");
        anim.SetAnimationFrames(
            new AnimationFrame(0, 0, 0.4f),
            new AnimationFrame(1, 1, 0.4f),
            new AnimationFrame(2, 2, 0.4f),
            new AnimationFrame(3, 3, 0.4f),
            new AnimationFrame(4, 4, 0.4f),
            new AnimationFrame(5, 5, 0.4f));

        var animSprite = new AnimSprite(ss);
        animSprite.Scale = new Vector2f(0.8f, 0.8f);

        anim.SetAnimSprite(animSprite);

        animator.AddAnimation("Idle", anim);

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

        animator.AddAnimation("Run", anim2);
    }

    public void Update(Time deltaTime)
    {
        bool isMoveUp = Keyboard.IsKeyPressed(Keyboard.Key.W);
        bool isMoveDown = Keyboard.IsKeyPressed(Keyboard.Key.S);
        bool isMoveLeft = Keyboard.IsKeyPressed(Keyboard.Key.A);
        bool isMoveRight = Keyboard.IsKeyPressed(Keyboard.Key.D);

        bool isMove = isMoveUp || isMoveDown || isMoveLeft || isMoveRight;

        if (isMove)
        {
            animator.Play("Run");

            if (isMoveUp)
            {
                rb.Velocity -= new Vector2f(0, 10 * deltaTime.AsSeconds());
            }
            if (isMoveDown)
            {
                rb.Velocity += new Vector2f(0, 10 * deltaTime.AsSeconds());
            }
            if (isMoveLeft)
            {
                animator.Scale = new Vector2f(-1, 1);
                animator.Origin = new Vector2f(28, animator.Origin.Y);
                rb.Velocity -= new Vector2f(10 * deltaTime.AsSeconds(), 0);
            }
            if (isMoveRight)
            {
                animator.Scale = new Vector2f(1, 1);
                animator.Origin = new Vector2f(-28, animator.Origin.Y);
                rb.Velocity += new Vector2f(10 * deltaTime.AsSeconds(), 0);
            }
        }
        else
        {
            animator.Play("Idle");

            rb.Velocity = new Vector2f();
        }

        UpdateTransform(rb);
    }

    public void Draw(RenderTarget target, RenderStates states)
    {
        states.Transform *= Transform;

        animator.Draw(target, states);
    }
}
