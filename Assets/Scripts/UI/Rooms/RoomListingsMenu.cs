using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class RoomListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private RoomListing _roomListing;
    private List<RoomListing> _listings = new List<RoomListing>();
    private RoomCanvases _roomsCanvases;

    public void FirstInitialize(RoomCanvases roomsCanvases)
    {
        _roomsCanvases = roomsCanvases;
    }

    public override void OnJoinedRoom(){
        _roomsCanvases.CurrenRoomCanvas.Show();
    }

    public override void OnRoomListUpdate(List<Photon.Realtime.RoomInfo> roomList){
        Debug.Log("OnRoomListUpdate");
        foreach(RoomInfo info in roomList){
            if (info.RemovedFromList){
                int index = _listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index!=-1){
                    Destroy(_listings[index].gameObject);
                    _listings.RemoveAt(index);
                }
            }
            else {
                RoomListing listing = Instantiate(_roomListing, _content);
                if (listing != null)
                    listing.SetRoomInfo(info);
            }
        }
    }
}
