using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inherit from Enemy base class.
public class ColouredEnemy : Enemy
{
    // Define the colour that the enemy spawns with.
    public Color EnemyColour;
    Material _internalMat;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the meshRenderer of the enemy on Start of frame.
        MeshRenderer _meshRenderer = GetComponent<MeshRenderer>(); // underscore convention indicates inscope fields.
        if (!_meshRenderer) return; // Exception handling if _meshRenderer == nullptr.

        _internalMat = _meshRenderer.material;
        _internalMat.color = EnemyColour;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Random.Range(-0.1f, 0.1f), 0, Random.Range(-0.1f, 0.1f)));
    }
}
