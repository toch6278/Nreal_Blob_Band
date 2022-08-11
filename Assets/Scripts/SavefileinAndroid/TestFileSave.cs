using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TestFileSave : MonoBehaviour
{
    StreamWriter Writer;
    public Text log;

    // Start is called before the first frame update
    void Start()
    {
     log.text=   GetPath();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public string GetPath()
     {
         string folderPath = Application.persistentDataPath + "/myDataFolder/";
         string filePath = folderPath + "myFile.json";
         if (!Directory.Exists(folderPath))
         {
             Directory.CreateDirectory(folderPath); 
         }
         if (!File.Exists(filePath)) 
         {
             File.Create(filePath).Close();
             File.WriteAllText(filePath, "myJsonText123");
         }
         return  filePath ;
     }


        public static DirectoryInfo SafeCreateDirectory(string path)
    {
        //Generate if you don't check if the directory exists
        if (Directory.Exists(path))
        {
            return null;
        }
        return Directory.CreateDirectory(path);
    }

    public void Score_Save(string Directory_path,string date)
    {
        //Data storage
        SafeCreateDirectory(Application.persistentDataPath + "/" + Directory_path);
        string json = JsonUtility.ToJson(date);
        Writer = new StreamWriter(Application.persistentDataPath + "/" + Directory_path + "/date.json");
        Writer.Write(json);
        Writer.Flush();
        Writer.Close();
    }
/*
    public Score Score_Load(string Directory_path)
    {
        //Data acquisition
        var reader = new StreamReader(Application.persistentDataPath + "/" + Directory_path  + "/date.json");
        string json = reader.ReadToEnd();
        reader.Close();
        return json;//Convert for ease of use
    }*/
}
