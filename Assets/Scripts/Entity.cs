using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour {

    public bool isEnemy;

    public int x { set; get; }
    public int y { set; get; }

    public TiledMap map { get; set; }

    public abstract void OnAction();

    public void Move(int x, int y)
    {
        StartCoroutine(Slide(this.x + .5f, this.y + .5f, x + .5f, y + .5f));
        this.x = x;
        this.y = y;
    }

    IEnumerator Slide(float x, float y, float tx, float ty)
    {
        float step = 0f;
        while (step <= 1f)
        {
            step += .1f;
            transform.localPosition = Vector2.Lerp(new Vector2(x, y), new Vector2(tx, ty), step);
            yield return null;
        }
    }
}
