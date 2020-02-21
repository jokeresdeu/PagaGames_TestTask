using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using TMPro;

public abstract class LvlManager : MonoBehaviour
{
    ITargetGiver targetGiver;
    bool gameEnded;
    [Inject]
    void Construct(ITargetGiver targetGiver)
    {
        this.targetGiver = targetGiver;
    }
    [SerializeField] protected TMP_Text text;
    [SerializeField] protected GameObject resWindow;

    // Start is called before the first frame update
    protected virtual void Win()
    {
        
    }
    protected  void Loose()
    {
        gameEnded = true;
        resWindow.SetActive(true);
        text.text = "You loose";
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    void Update()
    {
        if (gameEnded)
            return;
        if (targetGiver.Player == null)
            Loose();
        if (!CheckEnemies())
        {
            gameEnded = true;
            Invoke("Win", 3f);
        }
            
    }
    bool CheckEnemies()
    {
        foreach(Rigidbody rb in targetGiver.Enemies)
        {
            if (rb != null)
                return true;
        }
        return false;
    }
}
