using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float spinningSpeed = 5f;
    [SerializeField] Transform coinModel;
    private void Update()
    {
        //Rotate the coin a little bit every frame 
        coinModel.Rotate(Vector3.up, spinningSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            Destroy(this.gameObject);
        }
    }
}
