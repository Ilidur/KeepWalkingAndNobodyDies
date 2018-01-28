using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithObject : MonoBehaviour {

	GameObject target;
	// Use this for initialization

	LineRenderer lineRenderer;

	void Start()
	{
		lineRenderer = gameObject.AddComponent<LineRenderer>();
	}
	void Update()
	{
		if(OVRInput.GetDown(OVRInput.Button.Any) || UnityEngine.Input.GetKeyDown(KeyCode.A))
		{
			Ray ray = new Ray();
    		RaycastHit hit;
    		if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
			{
				lineRenderer.enabled = true;
				lineRenderer.SetPosition(0, transform.position);
				lineRenderer.SetPosition(1, hit.point);
				Debug.DrawLine(ray.origin, hit.point, Color.green);
			}
		}
		else
		{
			lineRenderer.enabled = false;
		}
	}
}
