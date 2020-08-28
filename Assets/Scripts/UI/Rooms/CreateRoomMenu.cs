using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _roomName;

    RoomCanvases _roomsCanvases;

    public void FirstInitialize(RoomCanvases roomsCanvases)
    {
        _roomsCanvases = roomsCanvases;
    }


    public void OnClick_CreateRoom(){
        //CreateRoom
        //JoinOrCreateRoom
        RoomOptions roomOptions = new RoomOptions{MaxPlayers = 4};
        PhotonNetwork.JoinOrCreateRoom(_roomName.text, roomOptions, TypedLobby.Default);
    }

    public override void OnCreatedRoom(){
        //MasterManager.DebugConsole
        Debug.Log("Created room successfully");
        _roomsCanvases.CurrenRoomCanvas.Show(); 
    }

    public override void OnCreateRoomFailed(short returnCode, string message){
        Debug.LogError("Room creation failed: " + message);
    }   
}
