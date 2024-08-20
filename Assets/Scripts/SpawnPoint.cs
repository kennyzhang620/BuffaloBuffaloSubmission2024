using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public EnemyPool EnemyPool;
    ColouredEnemy[] Enemies;
    public EnemyType RequiredEnemyType;
    public Color RequiredColour;
    public bool AnyColour = true;
    public int MaxSpawn = 100;
    List<Enemy> _spawned = new List<Enemy>();

    // Start is called before the first frame update
    void Start()
    {
        if (!EnemyPool) Debug.LogError("No Enemy List!");

        Enemies = EnemyPool.Enemies;
    }

    // Update is called once per frame
    void Update()
    {
        if (_spawned.Count > MaxSpawn) return;

        float sv = Random.Range(0, 1);

        foreach (ColouredEnemy e in Enemies)
        {
            if (sv < e.SpawnRate && (e.Class == RequiredEnemyType || RequiredEnemyType == EnemyType.Any) && (e.EnemyColour == RequiredColour || AnyColour))
            {
                Enemy res = Instantiate(e, transform);

                if (!res) return;

                _spawned.Add(res);
            }
        }
    }

    public void ResetSpawner()
    {
        foreach (Enemy e in _spawned)
        {
            Destroy(e.gameObject);
        }
    }
}

[CustomEditor(typeof(SpawnPoint))]
public class SpawnPointEditor : Editor
{
    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();

        var spawnPointScr = target as SpawnPoint;
        if (GUILayout.Button("Reset"))
            spawnPointScr.ResetSpawner();
    }
}
