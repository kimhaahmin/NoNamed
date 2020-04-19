using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class MessageBox : MonoBehaviour
{
    public static event Func<string> ErrorMessage;
    Image image;
    Text text;

    private void Awake()
    {
        image = GetComponent<Image>();
        text = GetComponentInChildren<Text>();
        image.enabled = false;
        text.enabled = false;
    }


    IEnumerator ShowMessage()
    {
        image.enabled = true;
        text.enabled = true;
        yield return new WaitForSecondsRealtime(3);
        image.enabled = false;
        text.enabled = true;
    }
}
