using UnityEngine;
using System.Collections;

public class EntityPlayer : Entity   {

    public override void OnAction()
    {
        Vector2 pos = (Vector2)transform.position - new Vector2(0.5f, 0.5f);
        if (Input.GetAxis("Vertical") > 0.8f)
        {
            if (true)
            {

            }
        }
        transform.position = pos + new Vector2(0.5f, 0.5f);
    }
}
