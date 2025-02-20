using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.Tmx.Loaders
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
                    float width = float.Parse(o.Attribute("width")!.Value);
                    float height = float.Parse(o.Attribute("height")!.Value);

                    objs.Add(new MapObject(id, new FloatRect(x, y, width, height)));
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
