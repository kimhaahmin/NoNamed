using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PhotonInit : MonoBehaviourPunCallbacks
{

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("로비 입장");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("방 입장");
        CreatePlayer();
    }

    private void OnGUI()
    {
        GUILayout.Label("isConnect:" + PhotonNetwork.IsConnected.ToString() + "\r\n" +
            "Version:" + PhotonNetwork.GameVersion);
        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("랜덤 입장 실패");
        PhotonNetwork.CreateRoom("MyRoom");
    }

    void CreatePlayer()
    {
        PhotonNetwork.Instantiate("Player", new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-11f, 10f)), Quaternion.identity);
    }
}
