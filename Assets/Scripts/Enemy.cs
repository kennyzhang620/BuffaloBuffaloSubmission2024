using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyType
{
    Grunt,
    Assassin,
    Archer,
    Any
};

// This is a base Enemy class. Different types of Enemies can inherit from it.
public class Enemy : MonoBehaviour
{
    public EnemyType Class;
    public int AttackPower;
    public int Health;
    public int Speed;
    public float SpawnRate;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
