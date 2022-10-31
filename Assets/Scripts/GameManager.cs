using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

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

   
    [SerializeField] CinemachineVirtualCamera camaraVirtual;

    [SerializeField] GameObject apretarBoton;

    [SerializeField] Animator playerAnimator;

    public int VecesApretadasElBoton = 0;
    public float tiempoParaEscapar;
    public bool estaMordiendo; //Seteada para que no pueda moverse mientras muerde
    public bool sePuedeMover;
    bool pudoEscapar;
    //llave
    public int llave = 0;
    public bool personaDesaparece = false; //
    public bool mordiendoAnimacion = false;
    public bool muertoAnimacion = false; //

    //Paramecanica
    public bool caminosInicio = false;
    public bool caminosLomuerde = false;
    public bool caminosLoSuelta = false;

    private void Start()
    {
        sePuedeMover = true;
    }
    public IEnumerator PantallaDeMordida()
    {
        estaMordiendo = true;
        // zoom
        mordiendoAnimacion = true;
        

        for (float i = 10; i > 5; i -= 1)
        {
            camaraVirtual.m_Lens.OrthographicSize = i;
            yield return new WaitForSeconds(0.5f);
        }

        //Aca se setea mordida caminos



        //Llamar funcion
        StartCoroutine(EvitaMorder());
        personaDesaparece = true; //////

        //Desactivar vampiro y persona
        //Iniciar anim de mordiendo

        //Tiempo para escapar antes de mirar la condicion
        yield return new WaitForSeconds(tiempoParaEscapar);
        //Condicional si escapo o no
        if (pudoEscapar)
        {
           StartCoroutine(Soltarse());
            mordiendoAnimacion = false;
            VecesApretadasElBoton = 0;
        }
        else
        {
           StartCoroutine(Morderlo());
            VecesApretadasElBoton = 0;
        }

        apretarBoton.SetActive(false);

        estaMordiendo = false;
        caminosLomuerde = false;
        caminosLoSuelta = false;
        camaraVirtual.m_Lens.OrthographicSize = 10;
    }

    IEnumerator EvitaMorder()
    {
        //Apretar un boton repetidas veces para soltarte.
        apretarBoton.SetActive(true);

        //Crear un numero aleatorio que indique cuantas veces tenemos que apretar
        int clicsNecesarios = Random.Range(5, 10);

        yield return new WaitForSeconds(2.5f);

        if (VecesApretadasElBoton > clicsNecesarios)
        { 
            pudoEscapar = true;
            

        }
        else
        {       
            pudoEscapar = false;
           // caminosLomuerde = true;
        }
    }



    IEnumerator Soltarse()
    {
        playerAnimator.SetBool("CaminoLosuelta", true);

        yield return new WaitForSeconds(4.5f);
        // Volver camara
        camaraVirtual.m_Lens.OrthographicSize = 10;
        personaDesaparece = true;

        sePuedeMover = true;
        mordiendoAnimacion = false;

        //Reiniciar las veces apretadas a 0

        Debug.Log("Tras un duro esfuerzo conseguimos soltarnos");
    }
     IEnumerator Morderlo()
    {
        //Setear animacion de morderlo
        caminosLomuerde = true;
        yield return new WaitForSeconds(1.44f); //Tiempo que dura la animacion
        //Setear anim de muerte
        //Reiniciar la esccena
        personaDesaparece = true;
        morirPersonaje();

        Debug.Log("MORDIENDO �AM �AM");
        yield return new WaitForSeconds(2);
        RecargarEscena();
        muertoAnimacion = false;
    }

    void morirPersonaje()
    {
        sePuedeMover = false;
        muertoAnimacion = true;

    }
    //Llamarlo cada vez que se aprete clic
    public void ApretaElBoton()
    {
        VecesApretadasElBoton++;
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
        llave = 0;
    }

    public void RecargarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        llave = 0;
    }
    
    public void SalirDelJuego()
    {
        Application.Quit();
        Debug.Log("No se puede aplicar en unity pero si aparece este cartel es porque cerramos la aplicacion con exito");
    }

}
