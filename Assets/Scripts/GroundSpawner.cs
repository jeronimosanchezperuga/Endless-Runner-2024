using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    public Transform mapDisplacer;
    public int initialModulesCount = 5;
    public GameObject spawnPoint;
    public bool mapMoves = false;
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
        GameObject clon = Instantiate(groundTile,spawnPoint.transform.position,Quaternion.identity);
        if (mapMoves) clon.transform.SetParent(mapDisplacer);
        spawnPoint = clon.transform.GetChild(1).gameObject;
    }
}
