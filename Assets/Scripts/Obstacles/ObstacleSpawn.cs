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
            Vector3 holePosition = new Vector3(holeSpawn[i].x, 0.1f, holeSpawn[i].y);
            Instantiate(hole, holePosition, Quaternion.identity);
        }
        for (int i = 0; i < oilSpawn.Length; i++)
        {
            Vector3 oilPosition = new Vector3(holeSpawn[i].x, 0.1f, holeSpawn[i].y);
            Instantiate(oilSlick, oilPosition, Quaternion.identity);
        }
    }
}
