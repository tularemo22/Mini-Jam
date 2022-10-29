using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    Rigidbody2D jugadorRB;
    [SerializeField] float velocidadMov;
    [SerializeField] float fuerzaSalto;
    [SerializeField] private Transform pies;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float radioPies;
    bool enSuelo;

    void Start()
    {
        jugadorRB = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Saltar();
        Mover();
    }

    private void Mover()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        jugadorRB.velocity = new Vector2(moveX * velocidadMov, jugadorRB.velocity.y);

        //Para que se gire

        if (moveX < 0.0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if(moveX > 0.0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void Saltar()
    {
        //Ground check. Creo una esfera en los pies del jugador para verificar mediante un buleano si está en suelo
        enSuelo = Physics2D.OverlapCircle(pies.position, radioPies, ground);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (enSuelo)
            {
                 jugadorRB.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            }
        }
    }
}
