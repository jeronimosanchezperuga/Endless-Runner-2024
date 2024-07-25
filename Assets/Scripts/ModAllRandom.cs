using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModAllRandom : MonoBehaviour
{
    public GameObject[] wallVariants;

    // Start is called before the first frame update
    void Start()
    {
        GenerateRandomWalls();
    }

    public void GenerateRandomWalls()
    {
        foreach (GameObject wall in wallVariants)
        {
            wall.GetComponent<SetVariantes>().ActivateRandomVariant();
        }
    }
}
