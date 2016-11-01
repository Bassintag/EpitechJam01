using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageList : MonoBehaviour {

    private ArrayList images;
    public Sprite up, down, left, right, stay;
    public Image holder;
    public Image preview;

    void Start()
    {
        images = new ArrayList();
    }

    public void SetPreview(Vector2 dir)
    {
        Sprite sprite;
        if (dir.x >= 1)
            sprite = right;
        else if (dir.x <= -1)
            sprite = left;
        else if (dir.y >= 1)
            sprite = up;
        else if (dir.y <= -1)
            sprite = down;
        else
            sprite = stay;
        preview.sprite = sprite;
    }

    public void Add(Vector2 dir)
    {
        Image image;
        Sprite sprite;
        if (dir.x >= 1)
            sprite = right;
        else if (dir.x <= -1)
            sprite = left;
        else if (dir.y >= 1)
            sprite = up;
        else if (dir.y <= -1)
            sprite = down;
        else
            sprite = stay;
        image = Instantiate(holder);
        image.sprite = sprite;
        image.transform.position = new Vector2(transform.position.x - 30, 60 * 5 - 30);
        image.transform.SetParent(transform);
        images.Add(image);
        if (images.Count == 6)
        {
            Destroy(((Image)images[0]).gameObject);
            images.RemoveAt(0);
        }
        foreach (Image i in images)
        {
            StartCoroutine(Slide(i.transform, i.transform.position.y, i.transform.position.y - 60));
        }
    }

    IEnumerator Slide(Transform t, float y, float ty)
    {
        float step = 0f;
        while (step <= 1f)
        {
            step += .1f;
            t.position = Vector2.Lerp(new Vector2(t.position.x, y), new Vector2(t.position.x, ty), step);
            yield return null;
        }
    }
}
