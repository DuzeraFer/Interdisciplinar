using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PratoChange : MonoBehaviour
{
    public Material Ingredientes, Fatiado, Cozinhado;
    Renderer render;

    private void Awake()
    {
        render = GetComponent<Renderer>();
        gameObject.SetActive(false);
    }

    public void setMaterialIngredientes()
    {
        render.material = Ingredientes;
        gameObject.SetActive(true);
    }

    public void setMaterialFatiado()
    {
        render.material = Fatiado;
    }

    public void setMaterialCozinhado()
    {
        render.material = Cozinhado;
    }

    public void setPratoDisable()
    {
        gameObject.SetActive(false);
    }
}
