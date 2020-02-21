using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
    public TextAsset[] savedFiles;
    private void Start()
    {
        foreach (TextAsset text in savedFiles)
        {
            Debug.Log(text.text);
        }
    }
    public string ReturnFile(string name)
    {
        foreach(TextAsset text in savedFiles)
        {
            if (text.name == name)
                return text.text;
        }
        return null;
    }
  
}
