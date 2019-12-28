using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Room : MonoBehaviour
{
    [SerializeField]
    Text roomName = null;
    [SerializeField]
    Text playerCount = null;

    public void DisplayRoomData(string _roomName,int _playerCount,int maxPlayer)
    {
        roomName.text = _roomName;
        playerCount.text = _playerCount.ToString() + " / " + maxPlayer.ToString();
    }

}
