using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnDirection
{
    Left,
    Right
}

public class EnemyCarRespawn : MonoBehaviour
{
    public SpawnDirection _dir;
    void OnTriggerEnter(Collider other)
    {
        if(_dir == SpawnDirection.Left)
        {
            other.transform.position += new Vector3(55, 0.0f, 0.0f);
        }
        else
        {
            other.transform.position = new Vector3(-25, 0.5f, -8.5f);
        }
    }
}
