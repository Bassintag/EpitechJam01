using UnityEngine;
using System.Collections;

public class EntityEnemy : Entity {

    int right = 1;

    public override void OnAction()
    {
        Vector2 pos = (Vector2)transform.localPosition - new Vector2(0.5f, 0.5f);
        if (map.GetAt((int)pos.x + right, (int)pos.y).Solid == false)
            pos += new Vector2(right, 0);
        else
        {
            right *= -1;
            OnAction();
        }
        transform.localPosition = (Vector3)pos + new Vector3(0.5f, 0.5f, -1f);
    }
}
