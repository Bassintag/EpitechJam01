using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour {

    public int x { private set; get; }
    public int y { private set; get; }

    public TiledMap map { get; set; }

    public abstract void OnAction();

    public void Move(int x, int y)
    {
        this.x = x;
        this.y = y;
        transform.localPosition = new Vector3(x + 0.5f, y + 0.5f, -1f);
    }
}
