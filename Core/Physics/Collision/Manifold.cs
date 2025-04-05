using SFML.System;
using System.Numerics;

namespace Core.Physics.Collision;

public readonly struct Manifold
{
    /// <summary>
    /// ���� �
    /// </summary>
    public readonly RigidBody BodyA;

    /// <summary>
    /// ���� �
    /// </summary>
    public readonly RigidBody BodyB;

    /// <summary>
    /// ������ ���������� �������������
    /// </summary>
    public readonly Vector2f Normal;

    /// <summary>
    /// ������� ������������
    /// </summary>
    public readonly float Depth;

    /// <summary>
    /// ������ �������
    /// </summary>
    public readonly Vector2f Contact1;

    /// <summary>
    /// ������ �������
    /// </summary>
    public readonly Vector2f Contact2;

    /// <summary>
    /// ���������� ���������
    /// </summary>
    public readonly int ContactCount;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="bodyA"> ���� � </param>
    /// <param name="bodyB"> ���� � </param>
    /// <param name="normal"> ������ ���������� ������������� </param>
    /// <param name="depth"> ������� ������������ </param>
    /// <param name="contact1"> ������ ������� </param>
    /// <param name="contact2"> ������ ������� </param>
    /// <param name="contactCount"> ���������� ��������� </param>
    public Manifold(RigidBody bodyA, RigidBody bodyB, Vector2f normal, float depth, Vector2f contact1, Vector2f contact2, int contactCount)
    {
        BodyA = bodyA;
        BodyB = bodyB;
        Normal = normal;
        Depth = depth;
        Contact1 = contact1;
        Contact2 = contact2;
        ContactCount = contactCount;
    }
}
