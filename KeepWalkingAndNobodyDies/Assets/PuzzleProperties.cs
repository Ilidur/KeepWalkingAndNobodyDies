using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    Cube,Sphere
}

public class PuzzleProperties : MonoBehaviour {

    public Color color;
    public Type objectType;

    // Use this for initialization
    void Start () {
        color = gameObject.GetComponent<Renderer>().material.color;

    }
	
	// Update is called once per frame
	void Update () {
		
	}


}
