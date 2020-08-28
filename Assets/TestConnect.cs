using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class TestConnect : MonoBehaviourPunCallbacks
{
    private void Start(){
        print ("Connecting to server.");
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
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
    }
}
