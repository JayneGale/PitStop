﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Renderer>().enabled = false;
            other.GetComponent<PlayerSpawn>().Respawn();
        }
    }
}