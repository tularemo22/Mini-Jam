using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Llave : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip agarrarLlave;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       StartCoroutine(Llaves(other));
    }

    IEnumerator Llaves(Collider2D other)
    {
        if (other.CompareTag("Jugador"))
        {
            audioSource.PlayOneShot(agarrarLlave, 0.3f);
            yield return new WaitForSeconds(0.3f);
            Death();
            GameManager.Instance.llave = 1;
        }
    }

    void Death()
    {
    Destroy(gameObject);
    
    }

}
   
