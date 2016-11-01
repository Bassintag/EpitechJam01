using UnityEngine;
using System.Collections;

public class EntityEnemy : Entity {

    int right = 1;

    public override void OnAction()
    {
        if (map.GetAt(x + right, y).Solid == false)
            Move(x + right, y);
        else
            right *= -1;
    }
}
