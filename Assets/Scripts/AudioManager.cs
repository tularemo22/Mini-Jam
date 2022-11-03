using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
  public static AudioManager instance { get; private set;}

    public AudioSource audioSource;
    public string nombreEscena;

    [Header("Audio y musica")]
    public AudioClip AudioInicioJuego;
    public AudioClip Nivel1;
    public AudioClip Nivel2;
    public AudioClip Nivel3;

   [Header("Efectos de sonido")]

    public AudioClip mordida;
    public AudioClip aldeanoMuriendo;
    public AudioClip aparicionDracula;
    public AudioClip agarrarLlave;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        audioSource = GetComponent<AudioSource>();

    }
   
    private void Update()
    {
      MusicaDeNiveles();

    }

    private void MusicaDeNiveles()
    {
        nombreEscena = SceneManager.GetActiveScene().name;

        if (nombreEscena == "Nivel 1")
        {
            audioSource.Pause();
            audioSource.clip = Nivel1;
            audioSource.Play();
        }
        if (nombreEscena == "Nivel 2")
        {
            audioSource.Pause();
            audioSource.clip = Nivel2;
            audioSource.Play();
        }
        if (nombreEscena == "Nivel 3")
        {
            audioSource.Pause();
            audioSource.clip = Nivel3;
            audioSource.Play();
        }
        if (nombreEscena == "Creditos Finales")
        {
            audioSource.Pause();
            audioSource.clip = AudioInicioJuego;
            audioSource.Play();
        }
    }

    public void AgarrarLlave()
    {     
            audioSource.PlayOneShot(agarrarLlave, 1f);       
    }

}
