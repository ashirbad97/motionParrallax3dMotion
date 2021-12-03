using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SQLite;

public class dbConnector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SQLiteConnection connection = new SQLiteConnection(@"Data Source=\Database\ParallaxExp.db;Version=3");
        connection.Open();
    }
}
