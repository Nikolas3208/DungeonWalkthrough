using System.Numerics;
using Core;
using Core.Content;
using Core.Graphics.TileMap;
using Core.Maths;
using Core.Physics;
using Core.Physics.Collision.Colliders;
using Core.Utils.TmxLoader;
using SFML.System;

namespace DungeonWalkthrough;

public class MyTileMapRender : TileMapRender
{
    private World _physicsWorld;
    public List<RigidBody> Bodies;
    public MyTileMapRender(Map map, World physicsWorld) : base(map)
    {
        _physicsWorld = physicsWorld;
        Bodies = new List<RigidBody>();
    }

    public override void CreateRenderMap(AssetManager assetManager)
    {
        base.CreateRenderMap(assetManager);

        foreach (var c in _map.MapObjects!)
        {
            foreach (var obj in c.Objects)
            {
                if (obj.MapObjectType == MapObjectType.Poligon)
                {
                    if (obj.Size != new Vector2f())
                    {
                        var body = _physicsWorld.CreateBody(Polygon.BoxPolygon(obj.Size.X, obj.Size.Y), Material.Default, true);
                        body.Position = obj.Position + obj.Size / 2;
                        Bodies.Add(body);
                    }
                    else
                    {
                        var body = _physicsWorld.CreateBody(new Polygon(obj.Points), Material.Default, true);
                        body.Position = obj.Position;
                        Bodies.Add(body);
                    }
                }
                else if (obj.MapObjectType == MapObjectType.Circle)
                {
                    var body = _physicsWorld.CreateBody(new Circle(obj.Radius), Material.Default, true);
                    body.Position = obj.Position;
                    Bodies.Add(body);
                }
            }
        }
    }


}
