using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerationScript : MonoBehaviour {

	[SerializeField]
	private GameObject _roomPrefab;

	public GameObject player;
	public ScriptableRoom entrance;
	public ScriptableRoom exit;
	public ScriptableRoom[] interestingRooms;
	public ScriptableRoom defaultRoom;

	[RangeAttribute(0,1)]
	public float densityOfInterestingRooms;
	public int PuzzleHeight = 5, PuzzleDepth = 5, PuzzleWidth = 5;
	// Use this for initialization

	private Dictionary<Vector3,Room> _allRooms;
	private GameObject _roomContainer;
	private RoomDimensions _roomDimensions;

	void Awake()
	{
		_allRooms = new Dictionary<Vector3,Room>();
		Debug.Assert(_roomPrefab != null);
		Debug.Assert(_roomPrefab.GetComponent<RoomDimensions>() != null);
		_roomDimensions = _roomPrefab.GetComponent<RoomDimensions>();
	}
	void Start ()
	{
		_roomContainer = new GameObject("Room Container");
		_roomContainer.transform.position = gameObject.transform.position;

		PlaceAllRooms();
		PlaceStart();
		PlaceExit();
	}

	void PlaceAllRooms()
	{
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

					roomInstance.transform.position += _roomContainer.transform.position;
					roomInstance.transform.parent = _roomContainer.transform;
					Room thisRoom = roomInstance.GetComponent<Room>();
					ScriptableRoom roomToAdd = GetNextRoom();
					Debug.Log("Adding room: " + roomToAdd.name);
					thisRoom.GenerateRoom(roomToAdd);
					_allRooms[new Vector3(x,y,z)] = thisRoom;
				}
			}
		}
	}
	ScriptableRoom GetNextRoom()
	{
		return Random.value < densityOfInterestingRooms ? interestingRooms[Random.Range(0, interestingRooms.Length-1)] : defaultRoom;
	}

	void PlaceStart()
	{
		//Don't start on any of the walls.
		Vector3 startRoom = new Vector3(
			Random.Range(1, PuzzleWidth-2),
			Random.Range(1, PuzzleHeight-2),
			Random.Range(1, PuzzleDepth-2));
			Debug.Log("Adding Entrance room at " + startRoom);
		_allRooms[startRoom].GenerateRoom(entrance);
		_allRooms[startRoom].gameObject.name = "Entrance room";

		if(player)
		{
			player.transform.position = new Vector3(
									(startRoom.x * _roomDimensions.dimensions.x) + ( _roomDimensions.dimensions.x - (_roomDimensions.dimensions.x * PuzzleDepth))/2,
									(startRoom.y * _roomDimensions.dimensions.y) + ( _roomDimensions.dimensions.y - (_roomDimensions.dimensions.y * PuzzleHeight))/2,
								 	(startRoom.z * _roomDimensions.dimensions.z) + ( _roomDimensions.dimensions.z - (_roomDimensions.dimensions.z * PuzzleWidth))/2);
		}
	}

	void PlaceExit()
	{
		//Don't start on any of the walls.
		Vector3 exitRoom = new Vector3(
			Random.Range(0, PuzzleWidth-1),
			Random.Range(0, PuzzleHeight-1),
			Random.Range(0, PuzzleDepth-1));

		int roomToZero = Random.Range(0, 5);
		switch(roomToZero)
		{
			case 0: { exitRoom.x = 0; break; }
			case 1: { exitRoom.y = 0; break; }
			case 2:	{ exitRoom.z = 0; break; }
			case 3: { exitRoom.x = PuzzleWidth-1; break; }
			case 4: { exitRoom.y = PuzzleHeight-1; break; }
			case 5: { exitRoom.z = PuzzleDepth-1; break; }
		}
		Debug.Log("Adding exitroom at " + exitRoom);
		_allRooms[exitRoom].GenerateRoom(exit);
		_allRooms[exitRoom].gameObject.name = "Exit room";
	}
}
