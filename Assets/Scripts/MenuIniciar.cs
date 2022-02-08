using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuIniciar : MonoBehaviour
{
    public GameObject panelOpc;
    public GameObject panelSobre;

    private void Awake()
    {
        panelOpc.SetActive(false);
        panelSobre.SetActive(false);
    }

    public void Iniciar()
    {
        SceneManager.LoadScene(1);
    }

    public void IniciarCenaPath()
    {
        SceneManager.LoadScene(2);
    }

    public void Opcoes()
    {
        panelOpc.SetActive(true);
    }

    public void Sobre()
    {
        panelSobre.SetActive(true);
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void Voltar()
    {
        panelOpc.SetActive(false);
        panelSobre.SetActive(false);
    }
}
