using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public TiledMap map;
    public float minDelay = 1f;
    public float maxDelay = 2f;

    float cooldown;

    void Start()
    {
        cooldown = maxDelay;
    }

    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            cooldown = maxDelay;
            foreach (Entity e in map.entities)
                e.OnAction();
        }
    }
}
