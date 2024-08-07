using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject[] groundModules;
    public Transform mapDisplacer;
    public int initialModulesCount = 5;
    public GameObject spawnPoint;
    public bool mapMoves = false;
    public Vector3 moduleOrientation = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < initialModulesCount; i++)
        {
            SpawnGroundTile();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnGroundTile()
    {
        GameObject groundTile = GetGroundTile();
        GameObject clon = Instantiate(groundTile, spawnPoint.transform.position, spawnPoint.transform.rotation);
        if (mapMoves) clon.transform.SetParent(mapDisplacer);
        clon.transform.Rotate(moduleOrientation);
        spawnPoint = clon.transform.GetChild(1).gameObject;
    }

    private GameObject GetGroundTile()
    {
        GameObject chosenTile = groundModules[Random.Range(0,groundModules.Length)];
        return chosenTile;
    }
}