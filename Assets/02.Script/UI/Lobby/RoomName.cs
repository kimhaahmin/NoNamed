using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomName : MonoBehaviour
{
    InputField inputField;

    void Awake()
    {
        NetWorkManager.GetRoomName += () => GetRoomName();
        inputField = GetComponent<InputField>();
    }

    string GetRoomName()
    {
        if (inputField.text.Length == 0)
            return Photon.Pun.PhotonNetwork.NickName+"SERVER";

        else
            return inputField.text;
    }
}
