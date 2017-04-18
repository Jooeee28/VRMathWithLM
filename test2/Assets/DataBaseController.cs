using UnityEngine;
using System.IO;
using Mono.Data.Sqlite;
using System.Data;

public class DataBaseController : MonoBehaviour {

    float o_x;
    float o_y;
    float o_z;
	// Use this for initialization
	void Start () {
        o_x = this.transform.position.x;
        o_y = this.transform.position.y;
        o_z = this.transform.position.z;
        string name = this.transform.tag;
        InsertMovement(name, o_x, o_y, o_z);
    }
	
	// Update is called once per frame
	void Update () {
        float x = this.transform.position.x;
        float y = this.transform.position.y;
        float z = this.transform.position.z;
        string name = this.transform.tag;
        if(x!=o_x || y!=o_y || z != o_z)
        {
            o_x = x;
            o_y = y;
            o_z = z;
            InsertMovement(name, x, y, z);
        }
	}

    public static void InsertMovement(string cube,float x,float y,float z)
    {
        string ts = GetTimestamp(System.DateTime.Now);

        string conn = "URI=file:" + Application.dataPath + "/progressData.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        // attention ! sqlite string should be very carefully written
        string sqlQuery = " INSERT INTO movements(cubename, timestamp, x, y, z)" + " VALUES(" +"'"+cube+"'"+", "+ ts + ", "+ x + ", " + y + ", " + z  +  ")";
        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery();
    }

    public static string GetTimestamp(System.DateTime value)
    {
        return value.ToString("yyyyMMddHHmmssffff");
    }

    void InsertValue(int firstNum, int secondNum, int result, string action)
    {
        string conn = "URI=file:" + Application.dataPath + "/progressData.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = " INSERT INTO MoveData(firstnum, secondnum, action, result)" + " VALUES(" + firstNum + ", " + secondNum + ", " + "'" + action + "'" + ", " + result + ")";
        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery();

    }

    void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
        string path = "Assets/Resources/movements.txt";
        string conn = "URI=file:" + Application.dataPath + "/progressData.db"; //Path to database.
        IDbConnection dbconn;
        Debug.Log(conn);
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "SELECT *" + "FROM movements";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        StreamWriter writer = new StreamWriter(path, true);
        while (reader.Read())
        {
            string line = reader.GetString(0) + "," + reader.GetInt32(1) + "," + reader.GetFloat(2) + ","
                + reader.GetFloat(3) + "," + reader.GetFloat(4);
            writer.WriteLine(line);
           
        }
        writer.Close();
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

    }
}
