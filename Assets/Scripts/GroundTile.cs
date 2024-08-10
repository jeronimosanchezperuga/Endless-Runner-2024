using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    // Start is called before the first frame update
    void Awake()
    {
        groundSpawner = FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        //groundSpawner.SpawnGroundTile();
        //Destroy(gameObject,2);
        CancelInvoke();
        Invoke(nameof(RelocateTile),2);
        
    }

    void RelocateTile()
    {
        transform.position = groundSpawner.spawnPoint.transform.position;
        transform.rotation = groundSpawner.spawnPoint.transform.rotation;
        groundSpawner.spawnPoint = transform.GetChild(1).gameObject;
    }
}
