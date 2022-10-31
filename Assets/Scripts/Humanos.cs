using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humanos : MonoBehaviour
{

    [SerializeField] private float velocidad;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private float distancia;
    [SerializeField] private bool moviendoDerecha;

    private Rigidbody2D RB;

     private void Start() 
    {
        RB = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate() 
    {
      RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia);
      
      RB.velocity = new Vector2(velocidad, RB.velocity.y);

        if (informacionSuelo == false)
        {
            Girar();
        }
    }

    private void Girar()
    {
        moviendoDerecha = !moviendoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorSuelo.transform.position, controladorSuelo.position + Vector3.down * distancia);
    }








    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            GameManager.Instance.StartCoroutine("PantallaDeMordida");
            Debug.Log("Me muerde");

            GetComponent<Rigidbody2D>();

        }
    }


}
