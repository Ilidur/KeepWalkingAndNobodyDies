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
	private Bounds _roomPrefabBounds;
	void Awake()
	{
		_allRooms = new List<GameObject>();
		Debug.Assert(_roomPrefab != null);
		Renderer roomPrefabRenderer = _roomPrefab.GetComponent<Renderer>();
		Debug.Assert(roomPrefabRenderer != null);
		_roomPrefabBounds = roomPrefabRenderer.bounds;
	}
	void Start ()
	{
		_roomContainer = new GameObject("Room Container");
		Vector3 prefabDimensions = new Vector3( _roomPrefabBounds.extents.x * 2,
											_roomPrefabBounds.extents.y * 2,
											_roomPrefabBounds.extents.z * 2);

		for(int x = 0; x < PuzzleDepth; ++x )
		{
			for(int y = 0; y < PuzzleHeight; ++y )
			{
				for(int z = 0; z < PuzzleWidth; ++z)
				{

					GameObject roomInstance = Instantiate(_roomPrefab,
						new Vector3((x * prefabDimensions.x) + ( prefabDimensions.x - (prefabDimensions.x * PuzzleDepth))/2,
									(y * prefabDimensions.y) + ( prefabDimensions.y - (prefabDimensions.y * PuzzleHeight))/2,
								 	(z * prefabDimensions.z) + ( prefabDimensions.z - (prefabDimensions.z * PuzzleWidth))/2),
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
