using System.Diagnostics.Metrics;
using Core.Animation;
using Core.Content;
using Core.Physics;
using Core.Physics.Colliders;
using Core.Utils.TmxLoader;
using SFML.Graphics;
using SFML.System;

namespace Core.Graphics.TileMap;

public class TileMapRender
{
    private Map _map;
    private Dictionary<string, List<Tile>> _tiles;
    private List<RigidBody> _rigidBodies;

    private readonly IGame _game;
    public TileMapRender(Map map, IGame game)
    {
        _map = map;
        _game = game;

        _tiles = new Dictionary<string, List<Tile>>();
        _rigidBodies = new List<RigidBody>();
    }

    public void CreateRenderMap()
    {
        if (_map == null)
            return;

        foreach (var mapLayer in _map.MapLayers)
        {
            var tiles = new List<Tile>();

            for (int x = 0; x < mapLayer.Width; x++)
            {
                for (int y = 0; y < mapLayer.Height; y++)
                {
                    int tileId = x + y * mapLayer.Width;

                    if (tileId < mapLayer.TileIds.Length)
                    {
                        var id = mapLayer.TileIds[tileId];

                        if (id > 0)
                        {
                            TileSet? ts = null;

                            foreach (var tileSet in _map.TileSets)
                            {
                                if (tileSet.ContainsTile(id))
                                {
                                    ts = tileSet;
                                    break;
                                }
                            }

                            if (ts != null)
                            {
                                var asset = _game.AssetManager!.GetAsset<SpriteAsset>(ts.Image.Name);

                                var ss = new SpriteSheet(ts.TileWidth, ts.TileHeight, false, 0, asset!.Sprite);
                                Tile? tile = null;

                                if (ts.TileFrames == null)
                                {
                                    tile = new Tile(new Sprite(ss.Sprite));
                                    tile.TextureRect = ss.GetTextureRect(id - ts.FirstId);


                                }
                                else
                                {
                                    List<AnimationFrame> frames = [];
                                    for (int i = 0; i < ts.TileFrames.Count; i++)
                                    {
                                        frames.Add(new AnimationFrame(i, ts.TileFrames[i].TileId, ts.TileFrames[i].Duration));
                                    }

                                    Animator animator = new Animator();
                                    var anim = new Animation.Animation(ts.Image.Name, frames.ToArray());
                                    anim.SetAnimSprite(new AnimSprite(ss));

                                    animator.AddAnimation(ts.Image.Name, anim);

                                    tile = new Tile(animator);
                                }

                                int yOffset = ss.SubWidth / _map.TileHeight - 1;

                                tile!.Position = new Vector2f(x * _map.TileWidth, (y - yOffset) * _map.TileHeight);

                                tiles.Add(tile);

                            }
                        }
                    }
                }
            }

            if (!_tiles.ContainsKey(mapLayer.Name))
                _tiles.Add(mapLayer.Name, tiles);
        }

        foreach (var c in _map.MapObjects!)
        {
            foreach (var obj in c.Objects)
            {
                var aabb = new AABB(new Vector2f(obj.Rect.Left, obj.Rect.Top), new Vector2f(obj.Rect.Width, obj.Rect.Height) + new Vector2f(obj.Rect.Left, obj.Rect.Top));

                var cillider = new Collider(ColliderType.Rectangle, new ColliderShape(aabb));

                _rigidBodies.Add(_game.World!.CreateRigidBody(cillider));
            }
        }
    }

    public void Draw(RenderTarget target, RenderStates states)
    {
        foreach (var tiles in _tiles)
        {
            foreach (var tile in tiles.Value)
            {
                tile.Draw(target, states);
            }
        }
    }
}
