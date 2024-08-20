using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyPool : MonoBehaviour
{
    public ColouredEnemy[] Enemies;
    ColouredEnemy[] _resetPool;
    // Start is called before the first frame update
    void Start()
    {
        if (Enemies.Length <= 0) { Debug.LogError("Assertion failed: Enemy pool cannot be empty!"); return; }
        _resetPool = new ColouredEnemy[Enemies.Length];
        Array.Copy(Enemies, _resetPool, Enemies.Length);
    }

    public void ResetPool()
    {
        Array.Copy(_resetPool, Enemies, _resetPool.Length);
    }
}
