using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dbconnect : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            MysqlConnector.OpenSqlServer();
        }
    }
}
