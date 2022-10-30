using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
 private void OnTriggerEnter2D(Collider2D other) 
   { 
    if (other.CompareTag("Jugador"))
    {
            if (GameManager.Instance.llave == 1)
    {   
        GameManager.Instance.SigueinteEscena();
    }
    
   }

   }
}
