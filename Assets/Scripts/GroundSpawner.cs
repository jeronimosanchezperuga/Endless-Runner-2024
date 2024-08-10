using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject[] groundModules;
    public Transform mapDisplacer;
    public int initialModulesCount = 5;
    public GameObject spawnPoint;
    public bool mapMoves = false;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = gameObject;
        for (int i = 0; i < initialModulesCount; i++)
        {
            SpawnGroundTile();
        }
    }

    // Update is called once per frame
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
        GameObject chosenTile = groundModules[Random.Range(0,groundModules.Length)];
        return chosenTile;
    }
}