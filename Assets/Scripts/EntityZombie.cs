using UnityEngine;
using System.Collections;

public class EntityZombie : Entity{

    bool move = false;
    int movx = 0;
    int movy = 0;

    void moveX()
    {
        movy = 0;
        if (x - map.player.x > 0)
            movx = -1;
        else
            movx = 1;
        move = false;
    }

    void moveY()
    {
        movx = 0;
        if (y - map.player.y > 0)
            movy = -1;
        else
            movy = 1;
        move = false;
    }

    void checkNMove()
    {
        Move(x + movx, y + movy);
        if (x == map.player.x && y == map.player.y)
        {
            map.player.stun = 2;
            GameManager.instance.combo = 1;
            dead = true;
        }
    }

    public override void OnAction()
    {
        movx = 0;
        movy = 0;
        if (x == map.player.x && y == map.player.y)
        {
            map.player.stun = 2;
            GameManager.instance.combo = 1;
            dead = true;
        }
        if (move && Mathf.Abs(x - map.player.x) < 15 && Mathf.Abs(y - map.player.y) < 8)
        {
            if (Mathf.Abs(x - map.player.x) > Mathf.Abs(y - map.player.y))
                moveX();
            else
                moveY();
            if (map.GetAt(x + movx, y + movy).Solid == false)
                checkNMove();
            else if (movx != 0)
            {
                moveY();
                if (map.GetAt(x + movx, y + movy).Solid == false)
                    checkNMove();
            }
            else if (movy != 0)
            {
                moveX();
                if (map.GetAt(x + movx, y + movy).Solid == false)
                    checkNMove();
            }

        }
        else
            move = !move;
    }
}
