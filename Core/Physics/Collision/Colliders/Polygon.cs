using SFML.System;

namespace Core.Physics.Collision.Colliders;

public struct Polygon
{
    private List<Vector2f> _vertices;
    public List<int>? _triangles;

    /// <summary>
    /// ����� ��������������
    /// </summary>
    public Vector2f Center { get; private set; }

    /// <summary>
    /// ������ ��������������
    /// </summary>
    public Vector2f Size { get; private set; }

    /// <summary>
    /// ������� ��������������
    /// </summary>
    /// <returns> List<Vector2f> </returns>
    public List<Vector2f> Vertices { get => _vertices; }

    /// <summary>
    /// ��������� �����
    /// </summary>
    /// <returns> ����� </returns>
    public int VertexCount
    {
        get
        {
            if (_vertices != null)
                return _vertices.Count;

            return 0;
        }
    }

    /// <summary>
    /// �������� �����
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Vector2f GetVertex(int index) => _vertices[index];

    public List<int>? Triangles { get => _triangles; }
    public int TriangleCount
    {
        get
        {
            if (_triangles != null)
                return _triangles.Count;

            return 0;
        }
    }
    public int GetTriangle(int index) => _triangles![index];
    
    /// <summary>
    /// �������������
    /// </summary>
    /// <param name="vertices"> ����� </param>
    public Polygon(List<Vector2f> vertices)
    {
        _vertices = vertices;

        Center = GetCenterPolygon(vertices);

        _triangles = new List<int>();
        _triangles.Add(0);
        _triangles.Add(1);
        _triangles.Add(2);
    }

    /// <summary>
    /// �������������
    /// </summary>
    /// <param name="vertices"> ������ </param>
    /// <param name="triangles"> ��������� </param>
    public Polygon(List<Vector2f> vertices, List<int> triangles)
    {
        _vertices = vertices;
        _triangles = triangles;

        Center = GetCenterPolygon(vertices);
    }


    /// <summary>
    /// �������������� ��������������
    /// </summary>
    /// <param name="position"> ������� </param>
    /// <returns> new Polygon() </returns>
    public Polygon Transform(Vector2f position)
    {
        var vertices = new List<Vector2f>();

        for (int i = 0; i < _vertices.Count; i++)
        {
            vertices.Add(_vertices[i] + position);
        }

        return new Polygon(vertices, _triangles!) { Size = Size };
    }

    /// <summary>
    /// �������������� ��������������
    /// </summary>
    /// <param name="sin"> ����� </param>
    /// <param name="cos"> ������� </param>
    /// <param name="position"> ������� </param>
    /// <returns> new Polygon() </returns>
    /// <exception cref="Exception"> ���� ����� null </exception>
    public Polygon Transform(float sin, float cos, Vector2f position)
    {
        var points = new List<Vector2f>();
        if (_vertices != null)
        {
            for (int i = 0; i < _vertices.Count; i++)
            {
                var pos = _vertices[i];

                float x = pos.X * cos - pos.Y * sin;
                float y = pos.X * sin + pos.Y * cos;

                points.Add(new Vector2f(x, y) + position);
            }
        }
        else
        {
            throw new Exception("Vertices is null.");
        }

        return new Polygon(points, _triangles!) { Size = Size };
    }

    /// <summary>
    /// �������� ����� ��������������
    /// </summary>
    /// <param name="vertices"> ������� </param>
    /// <returns> ������ </returns>
    public Vector2f GetCenterPolygon(List<Vector2f> vertices)
    {
        float sumX = 0f;
        float sumY = 0f;

        for (int i = 0; i < vertices.Count; i++)
        {
            Vector2f v = vertices[i];
            sumX += v.X;
            sumY += v.Y;
        }

        return new Vector2f(sumX, sumY) / vertices.Count;
    }

    /// <summary>
    /// �������� ������� ��������������
    /// </summary>
    /// <returns> Float </returns>
    public float GetAreaRegularPolygon()
    {
        float s = 0;

        for (int i = 0; i < _vertices.Count; i++)
        {
            var p1 = _vertices[i];
            var p2 = _vertices[(i + 1) % _vertices.Count];

            s += p1.X * p2.Y;
        }

        for (int i = 0; i < _vertices.Count; i++)
        {
            var p1 = _vertices[i];
            var p2 = _vertices[(i + 1) % _vertices.Count];

            s = p1.Y * p2.X;
        }

        if (s < 0)
            return -s / 2;

        return s / 2;
    }

    /// <summary>
    /// �������������� �������������
    /// </summary>
    /// <param name="width"> ������ </param>
    /// <param name="height"> ������ </param>
    /// <returns> ������������� </returns>
    public static Polygon BoxPolygon(float width, float height)
    {
        Vector2f[] vertices = new Vector2f[4];
        vertices[0] = new Vector2f(-width / 2, -height / 2);
        vertices[1] = new Vector2f(-width / 2, height / 2);
        vertices[2] = new Vector2f(width / 2, height / 2);
        vertices[3] = new Vector2f(width / 2, -height / 2);

        var triangles = new int[6];
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;

        return new Polygon(vertices.ToList(), triangles.ToList()) { Size = new Vector2f(width, height) };
    }
}
