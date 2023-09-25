using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento do jogador.
    public bool temChave = false;
    private Rigidbody2D rb; // Referência ao Rigidbody2D do jogador.

    // Método chamado quando o componente é inicializado.
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtém a referência ao Rigidbody2D.
        temChave = false;
    }

    // Método chamado a cada quadro.
    private void Update()
    {
        // Obtém as entradas de movimento horizontal e vertical.
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Calcula o vetor de movimento.
        Vector2 movement = new Vector2(moveX, moveY);

        // Normaliza o vetor de movimento para evitar movimento mais rápido na diagonal.
        movement.Normalize();

        // Aplica a velocidade de movimento ao Rigidbody2D.
        rb.velocity = movement * moveSpeed;
    }
}

