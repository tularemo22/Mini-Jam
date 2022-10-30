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
    {   


        yield return new WaitForSeconds(2);

       
        yield return new WaitForSeconds(5);

        // Apretar la cantidad de clicks suficientes

        //Desactivar pantalla de moridda
    }

    //Funciones para cambio de escenas

    public void IniciarJuego()
    {
        SceneManager.LoadScene(2);
    }
    public void IrMenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }
    public void IrCreditos()
    {
        SceneManager.LoadScene(1);
    }
    public void SigueinteEscena()
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
