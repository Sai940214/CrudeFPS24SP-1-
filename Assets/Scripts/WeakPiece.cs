using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class WeakPiece : MonoBehaviour
{
    Rigidbody Rigid;

    Renderer weakPieceRender;
    private void Start()
    {
        Rigid = GetComponent<Rigidbody>();
        weakPieceRender = GetComponent<Renderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("something stepped on me");

        //only start falling if we were touched by player
        if(other.gameObject.CompareTag("Player"))
        {
            weakPieceRender.material.color = Color.red; //change the color
            
            //Destroy(this.gameObject);
                                                        
            StartCoroutine(FallDelay()); //Start timer;
        }


    }
    IEnumerator FallDelay()
    {
        yield return new WaitForSeconds(0.5f); //wait
        Rigid.isKinematic = false; //release the piece

    }
}
