using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionMenu : MonoBehaviour
{
    bool temIngredientes, cozinhouIngredientes, fatiouIngredientes;
    public GameObject interactionMenu;
    DayManager dayManager;
    public PlayerColliders player;
    public PlayerMovement playerMov;
    public PratoChange pratoChange;

    private void Awake()
    {
        interactionMenu.SetActive(false);

        dayManager = GetComponent<DayManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interactionMenu.SetActive(!interactionMenu.activeSelf);
        }
    }

    public void PegarIngredientes()
    {
        if (player.collideEstoque && temIngredientes == false)
        {
            //Ir ate a geladeira e pegar ingredientes necessarios
            StartCoroutine(WaitPegarIngredientes());
            interactionMenu.SetActive(!interactionMenu.activeSelf);
        }       
    }   

    IEnumerator WaitPegarIngredientes()
    {
        playerMov.canMove = false;

        yield return new WaitForSeconds(3);

        Debug.Log("Pegou ingredientes, pode fatiar eles");
        temIngredientes = true;

        dayManager.GastarDinheiro();

        pratoChange.setMaterialIngredientes();
        playerMov.canMove = true;
    }

    public void Fatiar()
    {
        if (player.collideFatiar && temIngredientes)
        {
            //Ir ate a mesa de corte e fatiar os ingredientes necessarios para a receita    
            StartCoroutine(WaitFatiar());
            interactionMenu.SetActive(!interactionMenu.activeSelf);
        }
        else Debug.Log("Precisa pegar os ingredientes primeiro");
    }
    
    IEnumerator WaitFatiar()
    {
        playerMov.canMove = false;

        yield return new WaitForSeconds(4);

        Debug.Log("Fatiou ingredientes necessarios, agora pode cozinhar eles");
        temIngredientes = false;
        fatiouIngredientes = true;

        pratoChange.setMaterialFatiado();
        playerMov.canMove = true;
    }

    public void Cozinhar()
    {
        if (player.collideFogao && fatiouIngredientes)
        {
            //Ir ate o fogao e cozinhar os ingredientes necessarios para a receita
            StartCoroutine(WaitCozinhar());
            interactionMenu.SetActive(!interactionMenu.activeSelf);
        }
        else Debug.Log("Precisa fatiar os ingredientes primeiro");
    }

    IEnumerator WaitCozinhar()
    {
        playerMov.canMove = false;

        yield return new WaitForSeconds(5);

        Debug.Log("Cozinhou ingredientes necessarios, agora pode entregar eles");
        fatiouIngredientes = false;
        cozinhouIngredientes = true;

        pratoChange.setMaterialCozinhado();
        playerMov.canMove = true;
    }

    public void Entregar()
    {
        if (player.collideCliente && cozinhouIngredientes)
        {
            //Pegar posicao do cliente e levar a comida ate ele
            Debug.Log("Ingredientes entregue, parabens!!");
            cozinhouIngredientes = false;

            interactionMenu.SetActive(!interactionMenu.activeSelf);

            pratoChange.setPratoDisable();
            dayManager.VenderPrato();
        }
        else Debug.Log("Precisa cozinhar os ingredientes primeiro");
    }
}
