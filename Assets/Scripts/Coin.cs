using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float spinningSpeed = 5f;
    [SerializeField] Transform coinModel;
    [SerializeField] GameManagerSO gameManager;
    private void Update()
    {
        //Rotate the coin a little bit every frame 
        coinModel.Rotate(Vector3.up, spinningSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.coins += 1; //Add a coin!
            Destroy(this.gameObject);
        }
    }
}
