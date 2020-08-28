using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PundDebugTest : MonoBehaviourPunCallbacks
{
    private void Start(){
        print ("Connecting to server.");
        PhotonNetwork.NickName = "Gracz-" + UnityEngine.Random.Range(0, 9999).ToString();
        PhotonNetwork.GameVersion = "1.0";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster(){
        print("Connected to server.");
        print(PhotonNetwork.LocalPlayer.NickName);
        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(Photon.Realtime.DisconnectCause cause){
        print("Disconnected from server, for reason: " + cause.ToString());
        print(PhotonNetwork.LocalPlayer.NickName);
    }

    public override void OnJoinedLobby()
    {
        print("Joined lobby.");
        JoinOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        print("Joined room.");
        GetCurrentRoomPlayers();
    }

    public override void OnRoomListUpdate(List<Photon.Realtime.RoomInfo> roomList)
    {
        Debug.Log("  OnRoomListUpdate - number of rooms: " + PhotonNetwork.CountOfRooms);
        Debug.Log("  OnRoomListUpdate - list of rooms:");
        foreach(RoomInfo info in roomList){
            Debug.Log("  " + info.Name);
        }
        //GetCurrentRoomPlayers();
    }


    public void JoinOrCreateRoom(){
        RoomOptions roomOptions = new RoomOptions{MaxPlayers = 4};
        Debug.Log("JoinOrCreateRoom: Pokój-1");
        PhotonNetwork.JoinOrCreateRoom("Pokój-1", roomOptions, TypedLobby.Default);
    }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            Debug.Log(" Create room failed: " + message);
        }

    private void GetCurrentRoomPlayers()
    {
        Debug.Log("List of players ");
        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom?.Players)
        {
            Debug.Log("  " + playerInfo.Value.NickName);
        }
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Debug.Log("  " + newPlayer.NickName + " has entered the room " + PhotonNetwork.CurrentRoom.Name);     
        //GetCurrentRoomPlayers();   
    }


    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        Debug.Log("  " + otherPlayer.NickName + " has left the room " + PhotonNetwork.CurrentRoom.Name);        
        GetCurrentRoomPlayers();
    }



}
