using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").transform.GetChild(5).gameObject.SetActive(false);
            other.GetComponent<PlayerSpawn>().Respawn();
            other.GetComponent<PlayerMovement>().canMove = false;
            other.GetComponent<PlayerPickUp>().ResetHold();
        }
    }
}
