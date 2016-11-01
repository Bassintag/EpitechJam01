using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ComboText : MonoBehaviour {

    public Color start;
    public Color end;

    int prev = 1;

    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }
    
	void Update()
    {
	    if (prev != GameManager.instance.combo)
        {
            prev = GameManager.instance.combo;
            text.text = prev.ToString();
            float scale = 1f + Mathf.Min((float)GameManager.instance.combo / GameManager.instance.maxCombo, 1f) * .5f;
            text.color = Color.Lerp(start, end, (scale - 1f) * 2f);
            text.transform.localScale = new Vector2(scale, scale);
        }
	}
}
