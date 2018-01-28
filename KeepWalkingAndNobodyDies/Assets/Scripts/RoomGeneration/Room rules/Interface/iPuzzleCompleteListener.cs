using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iPuzzleCompleteListener
{
   void OnPuzzleComplete(BaseRoomPuzzle puzzle);
   void OnPuzzleFailed(BaseRoomPuzzle puzzle);
}


