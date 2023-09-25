    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public Animator anima; // Referência ao Animator do personagem.
    private Rigidbody2D rdb; // Referência ao Rigidbody2D do personagem.
    private SpriteRenderer spriteRenderer; //Ref ao SpriteRender do personagem
    private float xmov; // Variável para guardar o movimento horizontal.
    private float jumpState = 0f; // Variável para controlar o estado do pulo.
    public bool temChave;
    private bool isStunned = false;
    private GameObject StunVisual;

    [SerializeField] private int speed = 5; // Velocidade do personagem.
    [SerializeField] private float jumpForce = 8f; // Força do pulo.

    // Crie uma variável para representar a camada das plataformas.
    [SerializeField] private LayerMask platformLayer;

    private void Start()
    {
        temChave = false;
        StunVisual = transform.Find("Stun").gameObject;
        rdb = GetComponent<Rigidbody2D>(); // Obter a referência ao Rigidbody2D no início.
    }

    private void Update()
    {
        if (!isStunned)
        {
            xmov = Input.GetAxis("Horizontal");

            // Captura o movimento horizontal do jogador.

            // Verifica se o botão de pulo foi pressionado.
            if (Input.GetButton("Jump"))
            {
                // Verifica se o jogador está em contato com a camada das plataformas ou no ar antes de permitir o pulo.
                if (IsGrounded() || Mathf.Abs(rdb.velocity.y) < 0.01f)
                {
                    rdb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    jumpState = 1f; // Inicia o pulo.
                }
            }
            else
            {
                jumpState = 0f; // Define jumpState como 0 quando o botão de pulo não está pressionado.
            }
        }
    }
    public void Stun(float StunDuration)
    {
        StunVisual.SetActive(true);
        isStunned = true;
        xmov = 0;
        StartCoroutine(LeaveStun(StunDuration));
    }
    private IEnumerator LeaveStun(float StunDuration)
    {
        yield return new WaitForSeconds(StunDuration);
        StunVisual.SetActive(false);
        isStunned = false;
    }
    private void FixedUpdate()
    {
        Reverser(); // Chama a função que inverte o personagem.
        anima.SetFloat("Velocity", Mathf.Abs(rdb.velocity.x)); // Define a velocidade no Animator.
        anima.SetFloat("Height", jumpState); // Define o estado do pulo no Animator.

        // Adiciona uma força para mover o personagem.
        rdb.velocity = new Vector2(xmov * speed, rdb.velocity.y);
    }

    // Verifica se o jogador está em contato com a camada das plataformas usando raycast.
    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, platformLayer);

        return hit.collider != null;
    }

    // Função para inverter a direção do personagem (visual).
    private void Reverser()
    {
        if (rdb.velocity.x > 0.1f) transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (rdb.velocity.x < -0.1f) transform.rotation = Quaternion.Euler(0, 180, 0);

     
    }


}
