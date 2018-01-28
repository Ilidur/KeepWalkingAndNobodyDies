using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseRoomPuzzle : BaseListenerNotifierMonoBehaviour<iPuzzleCompleteListener>
{
	protected enum CompletionType
    {
        Success,
        Fail
    }

	[SerializeField]
	bool puzzleHasBeenCompleted = false;
	// Use this for initialization
	void Start ()
	{
		SetupPuzzle();
	}

    protected override void NotifyListeners( int notification )
    {
        foreach(var listener in listeners)
        {
            switch(notification)
            {
                case (int)CompletionType.Success:
                {
                    listener.OnPuzzleComplete(this);
                    break;
                }
                case (int)CompletionType.Fail:
                {
                    listener.OnPuzzleFailed(this);
                    break;
                }
            }
        }
    }
	protected abstract void SetupPuzzle();
}
