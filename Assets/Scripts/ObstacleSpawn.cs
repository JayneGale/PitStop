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
        for (int i = 0; i < holeSpawn.Length; i++)
        {
            Instantiate(hole, holeSpawn[i], Quaternion.identity);
        }
        for (int i = 0; i < oilSpawn.Length; i++)
        {
            Instantiate(oilSlick, oilSpawn[i], Quaternion.identity);
        }
    }
}
