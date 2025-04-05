using SFML.Graphics;
using SFML.System;
using System.Net.Http.Headers;
using System.Numerics;
using System.Xml.Linq;

namespace Core.Utils.TmxLoader
{
    public class MapObjectGroupsLoader
    {
        public static List<MapObjectGroup> Load(XElement map)
        {
            var objectsGroup = map.Elements("objectgroup");

            var objGroups = new List<MapObjectGroup>();

            foreach (var obj in objectsGroup)
            {
                var objs = new List<MapObject>();

                var objects = obj.Elements("object");

                foreach (var o in objects)
                {
                    int id = int.Parse(o.Attribute("id")!.Value);
                    float x = float.Parse(o.Attribute("x")!.Value);
                    float y = float.Parse(o.Attribute("y")!.Value);
                    if (o.Element("polygon") == null && o.Element("ellipse") == null)
                    {
                        float width = float.Parse(o.Attribute("width")!.Value);
                        float height = float.Parse(o.Attribute("height")!.Value);

                        objs.Add(new MapObject(id, new Vector2f(x, y), new Vector2f(width, height)));
                    }
                    else if (o.Element("ellipse") != null)
                    {
                        float width = float.Parse(o.Attribute("width")!.Value);
                        float height = float.Parse(o.Attribute("height")!.Value);

                        objs.Add(new MapObject(id, new Vector2f(x, y), width / 2));
                    }
                    else if (o.Element("polygon") != null)
                    {
                        var vertices = new List<Vector2f>();

                        var v = o.Element("polygon")!.Attribute("points")!.Value;
                        var vSplit = v.Split(" ");
                        for (int i = 0; i < vSplit.Length; i++)
                        {
                            var nums = vSplit[i].Split(',');

                            vertices.Add(new Vector2f(float.Parse(nums[0]), float.Parse(nums[1])));
                        }

                        objs.Add(new MapObject(id, new Vector2f(x, y), vertices));
                    }
                    
                }

                int objGroupId = int.Parse(obj.Attribute("id")!.Value);
                string name = obj.Attribute("name")!.Value;

                objGroups.Add(new MapObjectGroup(objGroupId, name, objs));
                objs.Clear();
            }

            return objGroups;
        }
    }
}
