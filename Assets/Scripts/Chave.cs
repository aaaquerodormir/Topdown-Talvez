using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chave : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().temChave = true;
            Destroy(this.gameObject);
        }
    }


}

