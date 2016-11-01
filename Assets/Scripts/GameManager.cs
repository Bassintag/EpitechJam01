using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public TiledMap map;
    public float minDelay = 1f;
    public float maxDelay = 0.5f;

    float cooldown;

    void Start()
    {
        if (instance)
            Destroy(this);
        instance = this;
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
