using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct WallSetup
{
	[SerializeField]
	public Vector3 Position, Rotation;

}
public class Room : MonoBehaviour {

	public GameObject wallPrefab;
	public ScriptableDimensions wallSetup;

	public ScriptableRoom RoomDesign;

	private List<GameObject> walls;

	// Use this for initialization
	void Start ()
	{
		walls = new List<GameObject>();

		//6 walls, obvs.
		for(int i = 0; i < 6; ++i)
		{
			GameObject wall = Instantiate(wallPrefab, Vector3.zero, Quaternion.Euler(wallSetup.rotation[i]));
			wall.transform.parent = gameObject.transform;

			wall.GetComponentInChildren<MeshRenderer>().materials[1].color = RoomDesign.wall[i].wallColour;
			wall.transform.localPosition = new Vector3(
				wallSetup.position[i].x * wall.transform.localScale.x,
				wallSetup.position[i].y * wall.transform.localScale.y,
				wallSetup.position[i].z * wall.transform.localScale.z);
		}
	}
}
