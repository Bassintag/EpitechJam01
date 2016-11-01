using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CooldownBar : MonoBehaviour {

    public Image BarMiddle;

    void Update()
    {
        BarMiddle.rectTransform.localScale = new Vector3(GameManager.instance.cooldown / (GameManager.instance.currentDelay), 1, 1);
    }
}
