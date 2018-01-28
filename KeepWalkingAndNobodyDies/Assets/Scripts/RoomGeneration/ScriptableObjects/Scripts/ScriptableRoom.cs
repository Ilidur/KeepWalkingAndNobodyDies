using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WallDecalType
{
	Grafitti,
	Picture,
	Scratches,
	None
}

[System.Serializable]
[CreateAssetMenu( menuName = "Room/RoomData", order = 1)]
public class ScriptableRoom : ScriptableObject
{
	public Wall[] wall = new Wall[6];
}
