using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneLoader : MonoBehaviour
{
    #region DI
    protected ITargetManager targetManager;
    protected ILoader loader;
    PlayerStateController.Factory playerFactory;
    [Inject]
    void Construct(PlayerStateController.Factory playerFactory, ILoader loader, ITargetManager targetManager)
    {
        this.playerFactory = playerFactory;
        this.loader = loader;
        this.targetManager = targetManager;
    }
    #endregion 

    protected virtual void Start()
    {
        LoadPlayer();
    }
    void LoadPlayer()
    {
        CharacterStats character = playerFactory.Create().GetComponent<CharacterStats>();
        character.transform.position = Vector3.zero;
        character.SetStats(loader.LoadData(character.CharacterType));
        character.gameObject.SetActive(true);
        targetManager.AddPlayer(character.GetComponentInChildren<Rigidbody>());
    }
   
}
