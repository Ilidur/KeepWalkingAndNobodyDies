using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectingOtherObject : MonoBehaviour {

    Color color;
    public ObjectType objectType;
    public List<PuzzleProperties> list;
    public GameObject fire;
    public GameObject Target;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter(Collider other)
    {
        PuzzleProperties properties = other.gameObject.GetComponent<PuzzleProperties>();
        if (properties != null)
        {
            Debug.Log("Entered the trigger field");
            list.Add(properties);
            if (objectType == properties.objectType)
            {
                if (properties.color == Color.blue)
                {
                    properties.color = Color.red;
                    other.gameObject.GetComponent<Renderer>().material.color = Color.red;
                }
                else
                {

                    properties.color = Color.blue;
                    other.gameObject.GetComponent<Renderer>().material.color = Color.blue;
                }
            }

            if (list.Count > 1)
            {
                Debug.Log("More than one!");
                Instantiate<GameObject>(fire, Target.transform.position, fire.transform.rotation);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PuzzleProperties properties = other.gameObject.GetComponent<PuzzleProperties>();
        if (properties != null)
        {
            Debug.Log("Left the trigger field");
            list.Remove(properties);
            if (objectType == properties.objectType)
            {
                if (properties.color == Color.blue)
                {
                    properties.color = Color.green;
                    other.gameObject.GetComponent<Renderer>().material.color = Color.green;
                }
                else
                {

                    properties.color = Color.blue;
                    other.gameObject.GetComponent<Renderer>().material.color = Color.blue;
                }
            }
            if (list.Count < 2)
            {
                Debug.Log("One or less!");
            }
        }
    }
}
