using UnityEngine;
using System.Collections;

public class DiscoBackground : MonoBehaviour {
    
    public float step = .1f;

    public Color Start;
    public Color End;

    float multiplicator = 0f;

	public void OnAction () {
        multiplicator += step;
        if (multiplicator > 1f)
        {
            multiplicator = 1f;
            step *= -1;
        }
        else if (multiplicator < 0f)
        {
            multiplicator = 0f;
            step *= -1;
        }
        GameManager.instance.mainCamera.backgroundColor = Color.Lerp(Start, End, multiplicator);
	}
}
