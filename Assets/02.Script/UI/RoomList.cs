﻿using System;
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
            Debug.Log("roomCount: "+ roomList.Count);

            GameObject room = Resources.Load("Room") as GameObject;
           
            room.GetComponent<Room>().DisplayRoomData(roomInfo.Name, roomInfo.PlayerCount, roomInfo.MaxPlayers);
            Instantiate(room, scrollView.transform);
        }
        

    }
}
