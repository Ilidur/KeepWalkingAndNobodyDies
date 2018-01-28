using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu( menuName = "Room/Decal", order = 1)]
public class WallDecal : ScriptableObject
{
	public WallDecalType type;
	public Texture2D Decal;
}
