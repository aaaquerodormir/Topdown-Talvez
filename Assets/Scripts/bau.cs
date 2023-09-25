using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bau : MonoBehaviour
{
    public string level;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(other.gameObject.GetComponent<PlayerMovement>().temChave == true && other.gameObject.tag == "Player")
            {
                MyLoading.LoadLevel(level);
                Debug.Log("Abrir Bau");
            }
            else
            {
                Debug.Log("Voce precisa coletar a chave!");
            }
        }
    }
}
