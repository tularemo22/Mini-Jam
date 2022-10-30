using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humanos : MonoBehaviour
{
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
