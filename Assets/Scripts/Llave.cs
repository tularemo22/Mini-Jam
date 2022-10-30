using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
   { 
    if (other.CompareTag("Jugador"))
    {
        Death();
        GameManager.Instance.llave =1;
    }
   }


    void Death()
    {
    Destroy(gameObject);
    
    }

}
   
