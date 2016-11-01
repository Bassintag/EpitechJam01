using UnityEngine;
using System.Collections;

public class EntityPlayer : Entity   {

    Vector2 last;
    float timer = 0f;
    public int stun = 0;

    public override void OnAction()
    {
        if (stun > 0)
            stun--;
        else if (last != Vector2.zero && map.GetAt(x + (int)last.x, y + (int)last.y).Solid == false)
        {
            foreach (Entity e in map.entities)
            {
                if (e.isEnemy && (e.x == x + last.x && e.y == y + last.y))
                    GameManager.instance.combo = 1;
            }
            Move(x + (int)last.x, y + (int)last.y);
        }
        else
        {
            GameManager.instance.combo = 1;
        }
        GameManager.instance.buttonHistory.Add(last);
        last = Vector2.zero;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 0.1f;
            if (Input.GetAxis("Vertical") > 0.8f)
                last = new Vector2(0, 1);
            else if (Input.GetAxis("Vertical") < -0.8f)
                last = new Vector2(0, -1);
            else if (Input.GetAxis("Horizontal") > 0.8f)
                last = new Vector2(1, 0);
            else if (Input.GetAxis("Horizontal") < -0.8f)
                last = new Vector2(-1, 0);
        }
        GameManager.instance.buttonHistory.SetPreview(last);
        GameManager.instance.mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
