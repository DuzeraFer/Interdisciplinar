using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliders : MonoBehaviour
{
    public bool collideEstoque, collideFogao, collideFatiar, collideCliente;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Estoque")
        {
            collideEstoque = true;
        }

        if (collision.gameObject.tag == "Fogao")
        {
            collideFogao = true;
        }

        if (collision.gameObject.tag == "Fatiar")
        {
            collideFatiar = true;
        }

        if (collision.gameObject.tag == "Cliente")
        {
            collideCliente = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Estoque")
        {
            collideEstoque = false;
        }

        if (collision.gameObject.tag == "Fogao")
        {
            collideFogao = false;
        }

        if (collision.gameObject.tag == "Fatiar")
        {
            collideFatiar = false;
        }

        if (collision.gameObject.tag == "Cliente")
        {
            collideCliente = false;
        }
    }
}
