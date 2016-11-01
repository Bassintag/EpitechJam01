using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using System;

public class TiledMap : MonoBehaviour {

    public int Width;
    public int Height;

    public String Level;

    public Tile[] Tiles;

    public int[,] map { private set; get; }
    
    void Start()
    {
        map = new int[Width, Height];
        LoadLevel(Level);
        InitMap();
    }

    void InitMap()
    {
        int id;
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                id = map[x, y];
                CreateTile(x, y, id);
                if (Tiles[id].Entity)
                {
                    map[x, y] = 0;
                    CreateTile(x, y, 0);
                }
            }
        }
    }

    void CreateTile(int x, int y, int id)
    {
        GameObject obj = Instantiate(Tiles[id].gameObject);
        obj.transform.parent = transform;
        obj.name = "Tile (" + id + ")";
        obj.transform.localPosition = new Vector2(x + .5f, y + .5f);
    }

    public Tile GetAt(int x, int y)
    {
        if (x < 0 || x >= Width)
            return (Tiles[0]);
        if (y < 0 || y >= Height)
            return (Tiles[0]);
        return (Tiles[map[x, y]]);
    }
    
    public void SetAt(int x, int y, int value)
    {
        map[x, y] = value;
    }

    void LoadLevel(string path)
    {
        string line;
        StreamReader reader = new StreamReader(path, Encoding.Default);
        using (reader)
        {
            int x = 0;
            int y = 0;
            while ((line = reader.ReadLine()) != null)
            {
                string[] tiles = line.Split(',');
                if (tiles.Length > 0)
                {
                    x = 0;
                    while (x < tiles.Length)
                    {
                        map[x, y] = int.Parse(tiles[x]);
                        x++;
                    }
                }
                y++;
            }
            reader.Close();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (float i = transform.position.x; i <= transform.position.x + Width; i++)
        {
            Gizmos.DrawLine(new Vector2(i, transform.position.y), new Vector2(i, transform.position.y + Height));
        }

        for (float j = transform.position.y; j <= transform.position.y + Height; j++)
        {
            Gizmos.DrawLine(new Vector2(transform.position.x, j), new Vector2(transform.position.x + Width, j));
        }
    }
}
