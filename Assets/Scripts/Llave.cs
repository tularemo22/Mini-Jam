using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Llave : MonoBehaviour
{
    private void Start()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       StartCoroutine(Llaves(other));
    }

    IEnumerator Llaves(Collider2D other)
    {
        if (other.CompareTag("Jugador"))
        {
            AudioManager.instance.AgarrarLlave();
            GameManager.Instance.llave = 1;
            yield return new WaitForSeconds(0.3f);
            
            Death();
        }
    }

    void Death()
    {
    Destroy(gameObject);
    
    }

}
   
