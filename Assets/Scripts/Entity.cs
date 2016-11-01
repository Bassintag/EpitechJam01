using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour {

    public TiledMap map { get; set; }

    public abstract void OnAction();

}
