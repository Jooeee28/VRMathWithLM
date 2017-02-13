using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class InitAction : MonoBehaviour {

	// Use this for initialization
	void Start () {

        string conn = "URI=file:" + Application.dataPath + "/progressData.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
       
        string sqlQuery = "SELECT *" + "FROM MoveData";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int firstNum = reader.GetInt32(0);
            int secondNum = reader.GetInt32(1);
            int result = reader.GetInt32(3);
            string action = reader.GetString(2);
            int order = reader.GetInt32(4);

            Debug.Log("firstNum= " + firstNum + "  secondNum =" + secondNum + "  result =" + result + "  action =" + action + "  order =" + order);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
