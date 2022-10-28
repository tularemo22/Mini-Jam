using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    Rigidbody2D jugadorRB;
    [SerializeField] float velocidadMov;

    void Start()
    {
        jugadorRB = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

    }

    private void FixedUpdate()
    {
        Mover();
        Saltar();
    }

    private void Mover()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        jugadorRB.velocity = new Vector2(moveX * velocidadMov, jugadorRB.velocity.y);
    }

    private void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            jugadorRB.AddForce(new Vector2(0, 10));
        }
    }
}
