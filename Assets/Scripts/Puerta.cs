using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{

    Animator puertaAnimator;

    private void Start()
    {
        puertaAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (GameManager.Instance.llave == 1)
        {
            puertaAnimator.SetTrigger("PasandoNivel");

        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
        { 
         if (other.CompareTag("Jugador"))
         {
             if (GameManager.Instance.llave == 1)
             {
                StartCoroutine(PasarNivel());
             }
    
        }   
       
   }
    
    IEnumerator PasarNivel()
    {
        
        GameManager.Instance.sePuedeMover = false;
        yield return new WaitForSeconds(1); 
        GameManager.Instance.sePuedeMover = true;
        GameManager.Instance.SigueinteEscena();
    }
}
