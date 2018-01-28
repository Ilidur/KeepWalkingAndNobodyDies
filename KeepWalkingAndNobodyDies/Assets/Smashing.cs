using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smashing : MonoBehaviour {

    float speed = 0;
    public float breakSpeed = 6.0f;
    Vector3 lastPosition = Vector3.zero;
    public GameObject sphere;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        speed = (((transform.position - lastPosition).magnitude) / Time.deltaTime);
        lastPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (speed > breakSpeed)
        {
            Debug.Log("Big collision");
            Instantiate<GameObject>(sphere, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
