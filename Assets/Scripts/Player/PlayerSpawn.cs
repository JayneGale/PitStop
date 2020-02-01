using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = transform.position;
    }

    public void Respawn()
    {
        StartCoroutine("SpawnIn");
    }

    IEnumerator SpawnIn()
    {
        yield return new WaitForSeconds(2f);
        transform.position = spawnPoint;
        GetComponent<Renderer>().enabled = true;
        GetComponent<PlayerMovement>().canMove = true;
    }
}
