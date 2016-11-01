using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public TiledMap map;
    public float minDelay = .2f;
    public float maxDelay = 2f;
    public int maxCombo = 10;
    public Camera mainCamera;
    public ImageList buttonHistory;

    public bool end { get; set; }

    public int combo { get; set; }

    public float currentDelay
    {
        get
        {
            return Mathf.Max(maxDelay - combo * (1f / maxCombo) * (maxDelay - minDelay), minDelay);
        }
        private set { }
    }

    public float cooldown { get; private set; }

    void Start()
    {
        end = false;
        combo = 1;
        if (instance)
            Destroy(this);
        instance = this;
        cooldown = currentDelay;
    }

    void Update()
    {
        if (end)
            return;
        cooldown -= Time.deltaTime;
        for (int i = 0; i < map.entities.Count; i++)
        {
            if (((Entity)map.entities[i]).dead)
            {
                Destroy(((Entity)map.entities[i]).gameObject);
                map.entities.RemoveAt(i);
                i--;
            }
        }
        if (cooldown <= 0)
        {
            combo++;
            cooldown = currentDelay;
            foreach (Entity e in map.entities)
                e.OnAction();
            map.player.OnAction();
            mainCamera.GetComponent<DiscoBackground>().OnAction();
        }
    }
}
