using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

   
}
