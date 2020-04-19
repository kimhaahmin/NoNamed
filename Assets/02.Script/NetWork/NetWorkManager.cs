using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using Photon.Realtime;

public class NetWorkManager : MonoBehaviourPunCallbacks
{
    public static event Func<float> GetMaxPlayer;
    public static event Func<string> GetRoomName;
    public static event Func<string> GetID;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        PhotonNetwork.LogLevel = PunLogLevel.Full;
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }


    public override void OnJoinedLobby()
    {
        PhotonNetwork.NickName = GetID();
        Debug.Log("로비 입장");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("방 입장");
    }

    private void OnGUI()
    {
        GUILayout.Label("isConnect:" + PhotonNetwork.IsConnected.ToString() + "\r\n" +
            "Version:" + PhotonNetwork.GameVersion);

        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("랜덤 입장 실패");
    }
    public override void OnCreatedRoom()
    {
    }



    public void OnClickCreateRoomButton()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = (byte)GetMaxPlayer();
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        PhotonNetwork.CreateRoom(GetRoomName(),roomOptions);
    }

    public void OnClickRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
}
