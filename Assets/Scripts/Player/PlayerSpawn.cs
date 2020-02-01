using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public Vector2 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = transform.position;
    }

    public void Respawn()
    {
        transform.position = spawnPoint;
        GetComponent<Renderer>().enabled = true;
    }
}
