using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humanos : MonoBehaviour
{

    [SerializeField] private float velocidad;
    [SerializeField] private float distancia;
    [SerializeField] private bool moviendoDerecha;

    [SerializeField] private Transform pies;
    [SerializeField] private float radioPies;
    [SerializeField] private LayerMask ground;
    bool enSuelo;

    private Rigidbody2D RB;

     private void Start() 
    {
        RB = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate() 
    {
        if (GameManager.Instance.estaMordiendo == false)
        {
             enSuelo = Physics2D.OverlapCircle(pies.position, radioPies, ground);

             RB.velocity = new Vector2(velocidad, RB.velocity.y);

             if (enSuelo == false)
              {
                 Girar();
              }

        }
    }

    private void Girar()
    {
        moviendoDerecha = !moviendoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            GameManager.Instance.StartCoroutine("PantallaDeMordida");
            Debug.Log("Me muerde");

            GetComponent<Rigidbody2D>();

        }
    }


}
