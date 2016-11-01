using UnityEngine;
using System.Collections;

public class EntityEnd : Entity {
    
    public override void OnAction()
    {
        if (map.player.x == x && map.player.y == y)
            GameManager.instance.end = true;
    }
}
