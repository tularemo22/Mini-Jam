using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        
    }

    [SerializeField] GameObject mordiendo;
    [SerializeField] GameObject vampiro;

    public IEnumerator PantallaDeMordida()
    {   //Activar vampiro de fondo
        Debug.Log("Iniciando coorrutina");
        vampiro.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);

        // Activar pantalla de mordida
        mordiendo.SetActive(true);
        yield return new WaitForSeconds(5);

        // Apretar la cantidad de clicks suficientes

        //Desactivar pantalla de moridda
        mordiendo.SetActive(false);
    }

    //Funcion para cambio de escenas

    public void CambiarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RecargarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void SalirDelJuego()
    {
        Application.Quit();
        Debug.Log("No se puede aplicar en unity pero si aparece este cartel es porque cerramos la aplicacion con exito");
    }

}
