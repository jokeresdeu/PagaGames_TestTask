using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl2Manager : LvlManager 
{
    protected override void Win()
    {
        resWindow.SetActive(true);
        text.text = "You WONE!!!!!";
    }
}
