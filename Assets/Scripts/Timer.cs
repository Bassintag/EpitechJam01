using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
    float timer;

    void Update()
    {
        if (GameManager.instance.end)
            return;
        timer += Time.deltaTime;
        GetComponent<Text>().text = timer.ToString("0.00S");
    }
}
