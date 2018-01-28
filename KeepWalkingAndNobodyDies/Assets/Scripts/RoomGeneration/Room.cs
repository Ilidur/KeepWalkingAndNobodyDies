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
	private List<GameObject> walls;

	// Use this for initialization
	public void GenerateRoom(ScriptableRoom RoomDesign)
	{
		ClearWallsContainer();

		//6 walls, obvs.
		for(int i = 0; i < 6; ++i)
		{
			GameObject wall = Instantiate(wallPrefab, Vector3.zero, Quaternion.Euler(wallSetup.rotation[i]));
			wall.transform.parent = gameObject.transform;

			wall.GetComponentInChildren<MeshRenderer>().materials[0].color = RoomDesign.wall[i].wallColour;
			wall.GetComponentInChildren<MeshRenderer>().materials[1].color = RoomDesign.wall[i].wallColour;
			wall.transform.localPosition = new Vector3(
				wallSetup.position[i].x * wall.transform.localScale.x,
				wallSetup.position[i].y * wall.transform.localScale.y,
				wallSetup.position[i].z * wall.transform.localScale.z);

				walls.Add(wall);
		}
	}


	void ClearWallsContainer()
	{
	if(walls != null)
		{
			foreach(GameObject w in walls)
			{
				GameObject.Destroy(w);
			}
			walls.Clear();
		}
		else
		{
			walls = new List<GameObject>();
		}
	}
}