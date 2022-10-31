using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    Rigidbody2D jugadorRB;
    bool enSuelo;
    Animator jugadorAnim;

    [SerializeField] float velocidadMov;
    [SerializeField] float fuerzaSalto;

    [SerializeField] private Transform pies;     // Chequeo de suelo
    [SerializeField] private LayerMask ground;  //
    [SerializeField] private float radioPies;  //

    void Start()
    {
        jugadorRB = GetComponent<Rigidbody2D>();
        jugadorAnim = GetComponent<Animator>();
    }


    void Update()
    {
        Saltar();
        Mover();

        if (GameManager.Instance.mordiendoAnimacion == true)
        {
            jugadorAnim.SetBool("Mordiendo", true);
        }
        else
        {
            jugadorAnim.SetBool("Mordiendo", false);
        }
        if (GameManager.Instance.muertoAnimacion == true)
        {
            jugadorAnim.SetBool("Muerto", true);
        }

    }

    private void Mover()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        if (GameManager.Instance.estaMordiendo == false && GameManager.Instance.sePuedeMover == true)
        {
            jugadorRB.velocity = new Vector2(moveX * velocidadMov, jugadorRB.velocity.y);
        }
        else
        {
            jugadorRB.velocity = Vector2.zero;
        }
        
        //Para que se gire

        if (moveX < 0.0f && GameManager.Instance.estaMordiendo == false && GameManager.Instance.sePuedeMover == true)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if(moveX > 0.0f && GameManager.Instance.estaMordiendo == false && GameManager.Instance.sePuedeMover == true)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        //Setear anim de correr 
        if (moveX != 0.0f && GameManager.Instance.estaMordiendo == false && GameManager.Instance.sePuedeMover == true)
        {
            jugadorAnim.SetBool("Correr", true);
        }
        else
        {
            jugadorAnim.SetBool("Correr", false);
        }
    }

    private void Saltar()
    {
        //Ground check. Crea una esfera en los pies del jugador para verificar mediante un buleano si está en suelo
        enSuelo = Physics2D.OverlapCircle(pies.position, radioPies, ground);

        if (Input.GetKeyDown(KeyCode.Space) && GameManager.Instance.sePuedeMover == true)
        {
            if (enSuelo)
            {
                 jugadorRB.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            }
        }
    }
}
