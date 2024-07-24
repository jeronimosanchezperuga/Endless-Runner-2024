using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModAllRandom : MonoBehaviour
{
    public GameObject[] wallVariants;
    public Transform[] wallsTransforms;

    // Start is called before the first frame update
    void Start()
    {
        GenerateRandomWalls();
    }

    public void GenerateRandomWalls()
    {
        DeactivateAllWalls();
        for (int i = 0; i < wallsTransforms.Length; i++)
        {
            int randomWallindex = Random.Range(0, wallVariants.Length);
            GameObject randomWall = wallVariants[randomWallindex];
            randomWall.SetActive(true);
            randomWall.transform.position = wallsTransforms[i].position;
            randomWall.transform.rotation = wallsTransforms[i].rotation;
        }
    }

    void DeactivateAllWalls()
    {
        foreach (var w in wallVariants)
        {
            w.SetActive(false);
        }
    }
}
