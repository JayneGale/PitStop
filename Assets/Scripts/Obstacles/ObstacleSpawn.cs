using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public GameObject hole;
    public GameObject oilSlick;

    public Vector2[] holeSpawn;
    public Vector2[] oilSpawn;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Vector2 holePos in holeSpawn)
        {
            SpawnObject(hole, holePos);
        }
        foreach (Vector2 oilPos in oilSpawn)
        {
            SpawnObject(oilSlick, oilPos);
        }
    }

    void SpawnObject(GameObject gO, Vector2 tilePosition)
    {
        Vector3 position = new Vector3(tilePosition.x, 0.1f, tilePosition.y);
        Instantiate(gO, position, Quaternion.identity);
    }
}
