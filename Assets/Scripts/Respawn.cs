using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform player;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player.position = spawnPoint.position;
        }
    }

    private void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }
}
