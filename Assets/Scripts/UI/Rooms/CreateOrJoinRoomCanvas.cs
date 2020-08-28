using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoinRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private CreateRoomMenu _createRoomMenu;
    [SerializeField]
    private RoomListingsMenu _roomListingsMenu;
    RoomCanvases _roomsCanvases;

    public void FirstInitialize(RoomCanvases roomsCanvases)
    {
        _roomsCanvases = roomsCanvases;
        _createRoomMenu.FirstInitialize(roomsCanvases);
        _roomListingsMenu.FirstInitialize(roomsCanvases);   
    }
}
