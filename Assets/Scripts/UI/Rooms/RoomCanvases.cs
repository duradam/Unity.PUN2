using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCanvases : MonoBehaviour
{
    [SerializeField]
    private CreateOrJoinRoomCanvas _createOrJoinRoomCanvas;
    public CreateOrJoinRoomCanvas CreateOrJoinRoomCanvas => _createOrJoinRoomCanvas;

    [SerializeField]
    private CurrenRoomCanvas _currenRoomCanvas;
    public CurrenRoomCanvas CurrenRoomCanvas => _currenRoomCanvas;

    private void Awake()
    {
        FirstInitialize();
    }

    private void FirstInitialize()
    {
        CreateOrJoinRoomCanvas.FirstInitialize(this);
        CurrenRoomCanvas.FirstInitialize(this);
    }
}
