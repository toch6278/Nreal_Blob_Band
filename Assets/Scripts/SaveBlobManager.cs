// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.IO;

// public static class SaveBlobManager 
// {
//     public static SaveData CurrentSaveData = new SaveData(); 

//     public const string SaveDirectory = "/SaveData/"; 
//     public const string FileName = "SaveGame.txt";

//     public static bool Save()
//     {
//         var dir = Application.persistentDataPath + SaveDirectory; 

//         //if the directory doesn't exist, then want to create the folder 
//         if(!Directory.Exists(dir))
//         {
//             Directory.CreateDirectory(dir); 
//         }

//         string json = JsonUtility.ToJson(CurrentSaveData, true); 
//         File.WriteAllText(dir + FileName, json); 

//         //GUIUtility.SystemCopyBuffer = dir; 

//         return true; 
//     }
// }
// //delete later
