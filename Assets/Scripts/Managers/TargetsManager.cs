using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsManager : ITargetManager, ITargetGiver 
{
    protected List<Rigidbody> enemies = new List<Rigidbody>();
    protected Rigidbody player;

    public List<Rigidbody> Enemies { get { return enemies; } }

    public Rigidbody Player { get { return player; } }

    public void AddPlayer(Rigidbody player)
    {
        this.player = player;
    }
    public void AddEnemy(Rigidbody enemy)
    {
        enemies.Add(enemy);
    }
}
