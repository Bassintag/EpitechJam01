using UnityEngine;
using System.Collections;

public class EntityPlayer : Entity   {

    Vector2 last; 
    
    public override void OnAction()
    {
        Vector2 pos = (Vector2)transform.localPosition - new Vector2(0.5f, 0.5f);
            if (map.GetAt((int)pos.x + (int)last.x, (int)pos.y + (int)last.y).Solid == false)
                pos += last;
        transform.localPosition = (Vector3)pos + new Vector3(0.5f, 0.5f, -1f);
        last = new Vector2(0, 0);
    }

    void Update()
    {
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
