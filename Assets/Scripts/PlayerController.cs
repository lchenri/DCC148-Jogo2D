using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    public float xSpeed = 5.0f;
    public float jumpForce = 7.0f;
    private Rigidbody2D rb;
    private bool isChao = false;
    public Transform isChaoCheck;
    public LayerMask isChaoLayer;
    private bool run;
    private bool jump;
    public Transform GameOver;
    public Transform LevelClear;
    public int life = 3;
    public Transform Life1;
    public Transform Life2;
    public Transform Life3;


    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        GameOver.gameObject.SetActive(false);
        LevelClear.gameObject.SetActive(false);
    }

    void Update()
    {
        jump = false;
        
        //Primeiro verifica se o jogador está no chão;
        isChao = Physics2D.OverlapCircle(isChaoCheck.position, 0.5f, isChaoLayer);

        //Movimenta o jogador horizontalmente
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * xSpeed, rb.velocity.y);

        run = Mathf.Abs(xInput) > 0.3f;

        //Inverte a direção do sprite
        if(xInput > 0)
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        else if(xInput < 0)
            transform.eulerAngles = new Vector3(0f, 180f, 0f);

        //Verifica se o jogador está no chão e se o botão de pulo foi pressionado
        if(isChao && Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jump = true;
        }

        animator.SetBool("Running", run);
        animator.SetBool("Jumping", jump);

        // Debug.Log("FPS: " + (1.0f / Time.deltaTime));

        Application.targetFrameRate = 60;

        if(transform.position.y < -25)
        {
            PlayerDeath();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            if(life == 3)
            {
                Life3.gameObject.SetActive(false);
                life--;
            }
            else if(life == 2)
            {
                Life2.gameObject.SetActive(false);
                life--;
            }
            else if(life == 1)
            {
                Life1.gameObject.SetActive(false);
                life--;
            }
            else if(life == 0)
            {
                PlayerDeath();
            }
        }
    }

    void PlayerDeath()
    {
        Destroy(gameObject);
        GameOver.gameObject.SetActive(true);
    }
}
