using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{   

private void OnTriggerEnter2D(Collider2D other)
 {
    if (other.CompareTag("Jugador"))
    {
        Destroy(gameObject);

    }


}

}
