using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class SceneLoaderWithEnemies : SceneLoader 
{
    #region DI
    CrawlerStateController.Factory crawlerFactory;
    FlyerStateController.Factory flyerFactroy;
    Vector3 spawnPosition = new Vector3(0,0,8);
    [Inject]
    public void EConstruct(CrawlerStateController.Factory crawlerFactory, FlyerStateController.Factory flyerFactroy)
    {
        this.crawlerFactory = crawlerFactory;
        this.flyerFactroy = flyerFactroy;
    }
    #endregion 

    [SerializeField] int crawlers;
    [SerializeField] int flyers;
    int enemyCount;
    protected override void Start()
    {
        base.Start();
        LoadCrawlers();
        LoadFlyers();
    }
    void LoadCrawlers()
    {
        enemyCount += crawlers;
        for (int i = 0; i < crawlers; i++)
        {
            GetSpawnPosition();
            SetCharacter(crawlerFactory.Create().GetComponent<CharacterStats>());
           
        }
          
    }
    void LoadFlyers()
    {
        enemyCount += flyers;
        for (int i = 0; i < flyers; i++)
        {
            GetSpawnPosition();
            SetCharacter(flyerFactroy.Create().GetComponent<CharacterStats>());
           
        }
    }
    void GetSpawnPosition()
    {
        spawnPosition.z += Random.Range(3f, 8f);
        if(spawnPosition.z>=17.1)
        {
            spawnPosition.z = 8;
            spawnPosition.z += Random.Range(3f, 8f);
            spawnPosition.x += 1.5f;
            if(spawnPosition.x>=4)
            {
                spawnPosition.x = 0;
                spawnPosition.x -= 1.5f;
            }
        }
        spawnPosition.x = Mathf.Clamp(spawnPosition.x, -4, 4);
    }
    protected void SetCharacter(CharacterStats character)
    {
        character.transform.position = spawnPosition;
        character.SetStats(loader.LoadData(character.CharacterType));
        targetManager.AddEnemy(character.GetComponentInChildren<Rigidbody>());
        character.gameObject.SetActive(true);
    }
}
