using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu( menuName = "Room/Wall", order = 1)]
public class Wall : ScriptableObject {

    public Color wallColour;

    public WallDecal decal;
}
