using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lvl1Manager : LvlManager 
{
    [SerializeField] GameObject gates;
    protected override void Win()
    {
        gates.SetActive(false);
    }
    public void NextLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
