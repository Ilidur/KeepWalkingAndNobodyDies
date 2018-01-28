using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu( menuName = "Room/RoomDimensions", order = 1)]
public class ScriptableDimensions : ScriptableObject
{
	public Vector3[] position = new Vector3[6];
	public Vector3[] rotation = new Vector3[6];

}
