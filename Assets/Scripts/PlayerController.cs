using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float xSpeed = 5.0f;
    public float jumpForce = 7.0f;
    private Rigidbody2D rb;
    private bool isChao = false;
    public Transform isChaoCheck;
    public LayerMask isChaoLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Primeiro verifica se o jogador está no chão;
        isChao = Physics2D.OverlapCircle(isChaoCheck.position, 0.1f, isChaoLayer);

        //Movimenta o jogador horizontalmente
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * xSpeed, rb.velocity.y);

        //Verifica se o jogador está no chão e se o botão de pulo foi pressionado
        if(isChao && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

    }
}
