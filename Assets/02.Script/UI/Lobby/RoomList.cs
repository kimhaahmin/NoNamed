using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class RoomList : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform scrollView = null;
    public override void OnRoomListUpdate(List<Photon.Realtime.RoomInfo> roomList)
    {
    //    PhotonNetwork.LeaveLobby();
    //    PhotonNetwork.JoinLobby();
        Debug.Log("roomCount: " + roomList.Count);

        foreach (GameObject room in GameObject.FindGameObjectsWithTag("Room"))
        {
            Destroy(room);
        }

        foreach (Photon.Realtime.RoomInfo roomInfo in roomList)
        {
            Debug.Log(roomInfo.Name + "\n" +
                "MaxPlayer: " + Convert.ToInt32(roomInfo.MaxPlayers) + "\n" +
                "ConnectPlayer: " + roomInfo.PlayerCount.ToString()
                );

            GameObject room = Resources.Load("Room") as GameObject;

            room.GetComponent<Room>().DisplayRoomData(roomInfo.Name, roomInfo.PlayerCount, roomInfo.MaxPlayers);
            Instantiate(room, scrollView.transform);
        }
    }

    public void RoomUpdate()
    {
        PhotonNetwork.LeaveLobby();
        PhotonNetwork.JoinLobby();
    }
}
