using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iDoorStateListener
{
   void OnRoomCleared(RoomController room);
   void OnRoomFailed(RoomController room);
}
