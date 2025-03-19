using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallHazard : MonoBehaviour
{
    //spawnpoint reference
    [SerializeField] Transform spawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        //$ 
        Debug.Log($"I was hit by {other.gameObject.name}");

        if (other.gameObject.CompareTag("Player"))
            {
            Debug.Log("It was the Player");
               //move player to spawnpoint
               other.gameObject.transform.position = spawnPoint.position;
            }
    }
}
