using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageList : MonoBehaviour {

    private ArrayList images;
    public Image up, down, left, right, stay;

    void Start()
    {
        images = new ArrayList();
    }

    public void Add(Vector2 dir)
    {
        Image image;
        if (dir.x >= 1)
            image = right;
        else if (dir.x <= -1)
            image = left;
        else if (dir.y >= 1)
            image = up;
        else if (dir.y <= -1)
            image = down;
        else
            image = stay;
        if (images.Count == 10)
            images.RemoveAt(9);
        foreach (Image i in images)
        {
            i.transform.position = new Vector2(i.transform.position.x, i.transform.position.y + 40);
        }
        image.transform.parent = transform;
        images.Add(image);
    }
}
