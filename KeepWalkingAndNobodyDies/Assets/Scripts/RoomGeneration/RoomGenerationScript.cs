using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerationScript : MonoBehaviour {

	[SerializeField]
	private GameObject _roomPrefab;

	public int PuzzleHeight = 5, PuzzleDepth = 5, PuzzleWidth = 5;
	// Use this for initialization

	private List<GameObject> _allRooms;
	private GameObject _roomContainer;
	private RoomDimensions _roomDimensions;
	void Awake()
	{
		_allRooms = new List<GameObject>();
		Debug.Assert(_roomPrefab != null);
		Debug.Assert(_roomPrefab.GetComponent<RoomDimensions>() != null);
		_roomDimensions = _roomPrefab.GetComponent<RoomDimensions>();
	}
	void Start ()
	{
		_roomContainer = new GameObject("Room Container");


		for(int x = 0; x < PuzzleDepth; ++x )
		{
			for(int y = 0; y < PuzzleHeight; ++y )
			{
				for(int z = 0; z < PuzzleWidth; ++z)
				{

					GameObject roomInstance = Instantiate(_roomPrefab,
						new Vector3((x * _roomDimensions.dimensions.x) + ( _roomDimensions.dimensions.x - (_roomDimensions.dimensions.x * PuzzleDepth))/2,
									(y * _roomDimensions.dimensions.y) + ( _roomDimensions.dimensions.y - (_roomDimensions.dimensions.y * PuzzleHeight))/2,
								 	(z * _roomDimensions.dimensions.z) + ( _roomDimensions.dimensions.z - (_roomDimensions.dimensions.z * PuzzleWidth))/2),
								 Quaternion.Euler(Vector3.zero));
					roomInstance.transform.parent = _roomContainer.transform;
					_allRooms.Add(roomInstance);
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
