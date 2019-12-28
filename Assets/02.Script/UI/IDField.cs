using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IDField : MonoBehaviour
{
    InputField inputField;

    void Awake()
    {
        NetWorkManager.GetUserID += () => GetUserID();
        inputField = GetComponent<InputField>();
    }

    string GetUserID()
    {
        if (inputField.text.Length == 0)
            return "User" + Random.Range(0, 100).ToString();

        else
            return inputField.text;
    }
}
