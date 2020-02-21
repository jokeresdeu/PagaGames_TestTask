using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SaveLoadSystem : ILoader 
{
    //string path =  "Assets/Resources/CharactersStats/";
    string path;
    public void Save(SavedStats stats)
    {
        //#if UNITY_ANDROID
        //        //path = Application.persistentDataPath+ "!/assets/Resources/CharactersStats/";
        //        path = "jar:file://" + Application.persistentDataPath + "!/assets/";

        //#endif
        //#if UNITY_ENGINE
        //        path = Aplication.dataPath + "/ StreamingAssets/Resources/CharactersStats/";
        //#endif
        //        Debug.Log("Here");
       
        //using (FileStream fileStream = new FileStream(path + stats.characterType + ".json", FileMode.Create))
        //{
        //    using (StreamWriter writer = new StreamWriter(fileStream))
        //    {
        //        writer.Write(jSon);
        //    }
        //}
    }
    public SavedStats LoadData(string fileName)
    {
//#if UNITY_ANDROID
//        path = "jar:file://" + Application.dataPath + "!/assets/";
//#endif
//#if UNITY_ENGINE
//        path = Aplication.dataPath
//#endif
        Saver saver = GameObject.FindObjectOfType<Saver>();
        SavedStats savedStats = null;
        string jSon = saver.ReturnFile(fileName);
        Debug.Log(jSon);
        savedStats = JsonUtility.FromJson<SavedStats>(jSon);
        return savedStats;
        //if (File.Exists(path + fileName + ".json"))
        //{
        //    string jSon = File.ReadAllText(path + fileName + ".json");
        //    savedStats = JsonUtility.FromJson<SavedStats>(jSon);
        //}
        //return savedStats;
    }
}
