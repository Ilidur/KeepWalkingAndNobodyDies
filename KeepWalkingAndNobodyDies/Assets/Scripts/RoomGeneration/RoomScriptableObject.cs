using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WallDecal
{
	Grafitti,
	Picture,
	Scratches,
	None
}

[CreateAssetMenu(fileName = "Data", menuName = "Room/Wall", order = 1)]
public class Wall : ScriptableObject {

    public Color wallColour;

    public WallDecal decal;
}