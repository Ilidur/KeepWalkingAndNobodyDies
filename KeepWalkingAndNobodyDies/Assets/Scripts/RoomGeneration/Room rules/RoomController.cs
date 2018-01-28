using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour, iPuzzleCompleteListener
{
    public List<BaseRoomPuzzle> puzzles;

    public void OnPuzzleComplete(BaseRoomPuzzle puzzle)
    {
        throw new NotImplementedException();
    }

    public void OnPuzzleFailed(BaseRoomPuzzle puzzle)
    {
        throw new NotImplementedException();
    }

    void Start()
    {

    }
    void Update()
    {

    }
}

