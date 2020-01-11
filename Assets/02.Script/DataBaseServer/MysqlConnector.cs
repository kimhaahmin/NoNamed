using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
public static class MysqlConnector
{
    static MySqlConnection connection;

    public static void OpenSqlServer()
    {
        string strConn = "server=1.11.4.163;uid=root;pwd=autoset;database=startreamdb;";
        connection = new MySqlConnection(strConn);
        connection.Open();
        Debug.Log("디비연결");
    }

}
