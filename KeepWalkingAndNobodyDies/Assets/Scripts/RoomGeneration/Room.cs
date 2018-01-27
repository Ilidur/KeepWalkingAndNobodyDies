using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct WallSetup
{
	[SerializeField]
	public Vector3 Position, Rotation;

	[SerializeField]
	public Color Colour;
}
public class Room : MonoBehaviour {

	public GameObject wallPrefab;
	public WallSetup[] wallSetup;

	private List<GameObject> walls;

	// Use this for initialization
	void Start ()
	{
		walls = new List<GameObject>();

		for(int i = 0; i < wallSetup.Length; ++i)
		{
			GameObject wall = Instantiate(wallPrefab, Vector3.zero, Quaternion.Euler(wallSetup[i].Rotation));
			wall.transform.parent = gameObject.transform;

			wall.GetComponentInChildren<MeshRenderer>().materials[1].color = wallSetup[i].Colour;
			wall.transform.localPosition = wallSetup[i].Position;
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
