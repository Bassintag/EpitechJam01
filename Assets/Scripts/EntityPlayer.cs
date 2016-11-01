using UnityEngine;
using System.Collections;

public class EntityPlayer : Entity   {

    Vector2 last;
    float timer = 0f;

    public override void OnAction()
    {
        Vector2 pos = (Vector2)transform.localPosition - new Vector2(0.5f, 0.5f);
        if (map.GetAt((int)pos.x + (int)last.x, (int)pos.y + (int)last.y).Solid == false)
        {
            if (map.GetAt((int)pos.x + (int)last.x, (int)pos.y + (int)last.y).Entity == true)
            {
                GameManager.instance.combo = 0;
            }
            pos += last;
        }
        transform.localPosition = (Vector3)pos + new Vector3(0.5f, 0.5f, -1f);
        last = new Vector2(0, 0);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 0.15f;
            if (Input.GetAxis("Vertical") > 0.8f)
                last = new Vector2(0, 1);
            else if (Input.GetAxis("Vertical") < -0.8f)
                last = new Vector2(0, -1);
            else if (Input.GetAxis("Horizontal") > 0.8f)
                last = new Vector2(1, 0);
            else if (Input.GetAxis("Horizontal") < -0.8f)
                last = new Vector2(-1, 0);
        }
    }
}
