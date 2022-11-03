using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy instance { get; private set; }
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
    }

    public void OD_IrLvl1()
    {
        SceneManager.LoadScene(3);
    }
    public void OD_IrLvl2()
    {
        SceneManager.LoadScene(4);
    }
    public void OD_IrLvl3()
    {
        SceneManager.LoadScene(5);
    }
}
