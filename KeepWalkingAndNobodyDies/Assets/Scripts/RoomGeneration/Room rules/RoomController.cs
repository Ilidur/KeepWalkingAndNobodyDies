using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomController : BaseListenerNotifierMonoBehaviour<iDoorStateListener>, iPuzzleCompleteListener
{
    private enum RoomSuccessState
    {
        InProgress,
        Success,
        Fail
    }
    public List<BaseRoomPuzzle> puzzles;
    private Dictionary<BaseRoomPuzzle, bool> puzzleCompletion;
    private RoomSuccessState state;
    public void OnPuzzleComplete(BaseRoomPuzzle puzzle)
    {
        if(puzzleCompletion.ContainsKey(puzzle))
        {

            puzzleCompletion[puzzle] = true;
            bool allPuzzlesComplete = true;
            foreach(bool key in puzzleCompletion.Keys)
            {
                allPuzzlesComplete &= key;
            }
            if(allPuzzlesComplete)
            {
                NotifyListeners((int)RoomSuccessState.Success);
            }
        }
    }

    public void OnPuzzleFailed(BaseRoomPuzzle puzzle)
    {
        NotifyListeners((int)RoomSuccessState.Fail);
    }

    void Start()
    {
        foreach(BaseRoomPuzzle puzzle in puzzles)
        {
            puzzle.RegisterListener(this);
        }
    }
    void Update()
    {

    }

    protected override void NotifyListeners( int notification )
    {
        foreach(var listener in listeners)
        {
            switch(notification)
            {
                case (int)RoomSuccessState.Success:
                {
                    listener.OnRoomCleared(this);
                    break;
                }
                case (int)RoomSuccessState.Fail:
                {
                    listener.OnRoomFailed(this);
                    break;
                }
            }
        }
    }
}

