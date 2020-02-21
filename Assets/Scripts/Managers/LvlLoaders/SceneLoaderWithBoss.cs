using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneLoaderWithBoss : SceneLoader 
{
    #region DI
    BossStateController.Factory bossFactory;
    [Inject]
    void BConstruct(BossStateController.Factory bossFactory)
    {
        this.bossFactory = bossFactory;
    }
    #endregion 
    protected override void Start()
    {
        base.Start();
        LoadBoss();
    }
    void LoadBoss()
    {
        SetCharacter(bossFactory.Create().GetComponent<CharacterStats>());
    }
    protected void SetCharacter(CharacterStats character)
    {
        character.transform.position = new Vector3(0, 1, 15);
        character.SetStats(loader.LoadData(character.CharacterType));
        targetManager.AddEnemy(character.GetComponentInChildren<Rigidbody>());
        character.gameObject.SetActive(true);
    }
}
