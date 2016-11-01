using UnityEngine;
using System.Collections;

public class TiledMap : MonoBehaviour {

    public int Width;
    public int Height;

    public GameObject[] Tiles;

    public int[,] map { private set; get; }
    
    void Start()
    {
        map = new int[Width, Height];
        InitMap();
    }

    void InitMap()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                GameObject obj = Instantiate(Tiles[map[x, y]]);
                obj.transform.parent = transform;
                obj.name = "Tile (" + map[x, y] + ")";
                obj.transform.localPosition = new Vector2(x + .5f, y + .5f);
            }
        }
    }
    
    public void SetAt(int x, int y, int value)
    {
        map[x, y] = value;
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
