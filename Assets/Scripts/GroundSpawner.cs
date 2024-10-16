using UnityEngine;

/*
 * Este script genera el escenario una vez
 * con una cantidad determinada de módulos
 */

public class GroundSpawner : MonoBehaviour
{
    public GameObject[] groundModules;
    public Transform mapDisplacer;
    public int initialModulesCount = 5;
    public GameObject spawnPoint;
    public bool mapMoves = false;

    void Start()
    {
        spawnPoint = gameObject;
        for (int i = 0; i < initialModulesCount; i++)
        {
            SpawnGroundTile();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnGroundTile();
        }
    }

    public void SpawnGroundTile()
    {
        GameObject groundTile = GetGroundTile();
        GameObject clon = Instantiate(groundTile, spawnPoint.transform.position, spawnPoint.transform.rotation);
        if (mapMoves) clon.transform.SetParent(mapDisplacer);
        clon.transform.rotation = spawnPoint.transform.rotation;
        spawnPoint = clon.transform.GetChild(1).gameObject;       
    }

    private GameObject GetGroundTile()
    {
        //establecer probabilidades de modulo
        GameObject chosenTile = groundModules[Random.Range(0,groundModules.Length)];
        return chosenTile;
    }
}