using System.Diagnostics.Metrics;
using Core.Animation;
using Core.Content;
using Core.Utils.TmxLoader;
using SFML.Graphics;
using SFML.System;

namespace Core.Graphics.TileMap;

public class TileMapRender
{
    protected Map _map;
    protected Dictionary<string, List<Tile>> _tiles;

    public TileMapRender(Map map)
    {
        _map = map;

        _tiles = new Dictionary<string, List<Tile>>();
        //_rigidBodies = new List<RigidBody>();
    }

    public virtual void CreateRenderMap(AssetManager assetManager)
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
                                var asset = assetManager!.GetAsset<SpriteAsset>(ts.Image.Name);

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
    }

    public virtual void Draw(RenderTarget target, RenderStates states)
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
