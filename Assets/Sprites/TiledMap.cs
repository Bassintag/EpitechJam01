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
