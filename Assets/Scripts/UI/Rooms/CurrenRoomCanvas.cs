using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrenRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private PlayerListingsMenu _playerListingsMenu;
    RoomCanvases _roomsCanvases;

    public void FirstInitialize(RoomCanvases roomsCanvases)
    {
        _roomsCanvases = roomsCanvases;
    }

    public void Show(){
        gameObject.SetActive(true);
    }

    private void Hide(){
        gameObject.SetActive(false);
    }
}
