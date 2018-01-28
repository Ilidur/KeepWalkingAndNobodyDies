using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDimensions : MonoBehaviour{
	[SerializeField]
	private Vector3 _dimensions;
	public Vector3 dimensions {
		get{
			return new Vector3(
				_dimensions.x * gameObject.transform.localScale.x,
				_dimensions.y * gameObject.transform.localScale.y,
				_dimensions.z * gameObject.transform.localScale.z
				);
		}
		set{ dimensions = value;}
	}

}
