using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Cube,Sphere
}

public class PuzzleProperties : MonoBehaviour {

    public Color color;
    public ObjectType objectType;

    // Use this for initialization
    void Start () {
        color = gameObject.GetComponent<Renderer>().material.color;

    }
	
	// Update is called once per frame
	void Update () {
		
	}


}
