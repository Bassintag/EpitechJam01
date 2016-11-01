using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ComboText : MonoBehaviour {

    int prev = 1;
    
	void Update ()
    {
	    if (prev != GameManager.instance.combo)
        {
            prev = GameManager.instance.combo;
            GetComponent<Text>().text = prev.ToString();
        }
	}
}
