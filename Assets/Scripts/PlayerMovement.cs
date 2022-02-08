using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public Grid grid;
    public float moveSpeed = 5f;

    private Vector2Int playerCell;
    private Vector2 playerPosition;
    public GameObject checkSides;
    public Tilemap tileGround;

    public LayerMask checkGround;

    public bool canMove = true;

    private void Start()
    {
        // Pega a celula inicial aonde o player esta
        playerCell = (Vector2Int)grid.WorldToCell(transform.position);

        // Transforma a posicao do player no centro da celula
        transform.position = grid.CellToWorld((Vector3Int)playerCell);
    }

    private void Update()
    {
        //Variavel para calculo de movimento do player
        Vector2Int gridMovement = new Vector2Int();

        //Secao de inputs de movimento
        if (Input.GetKeyDown(KeyCode.W) && !Physics2D.Raycast(new Vector3(checkSides.transform.position.x - 0.18f, checkSides.transform.position.y + 0.1f), Quaternion.Euler(0, 0, 60) * transform.up, 0.6f, checkGround) && canMove)
        {
            gridMovement.y += 1;
        }

        if (Input.GetKeyDown(KeyCode.S) && !Physics2D.Raycast(new Vector3(checkSides.transform.position.x + 0.18f, checkSides.transform.position.y - 0.1f), Quaternion.Euler(0, 0, 60) * -transform.up, 0.6f, checkGround) && canMove)

        {
            gridMovement.y -= 1;
        }

        if (Input.GetKeyDown(KeyCode.A) && !Physics2D.Raycast(new Vector3(checkSides.transform.position.x - 0.18f, checkSides.transform.position.y - 0.1f), Quaternion.Euler(0, 0, 30) * -transform.right, 0.6f, checkGround) && canMove)
        {
            gridMovement.x -= 1;
        }

        if (Input.GetKeyDown(KeyCode.D) && !Physics2D.Raycast(new Vector3(checkSides.transform.position.x + 0.18f, checkSides.transform.position.y + 0.1f), Quaternion.Euler(0, 0, 30) * transform.right, 0.6f, checkGround) && canMove)
        {
            gridMovement.x += 1;
        }

        Debug.DrawRay(new Vector3(checkSides.transform.position.x - 0.18f, checkSides.transform.position.y + 0.1f), Quaternion.Euler(0, 0, 60) * checkSides.transform.up * 0.6f, Color.red);
        Debug.DrawRay(new Vector3(checkSides.transform.position.x + 0.18f, checkSides.transform.position.y - 0.1f), Quaternion.Euler(0, 0, 60) * -checkSides.transform.up * 0.6f, Color.red);
        Debug.DrawRay(new Vector3(checkSides.transform.position.x - 0.18f, checkSides.transform.position.y -0.1f), Quaternion.Euler(0, 0, 30) * -checkSides.transform.right * 0.6f, Color.red);
        Debug.DrawRay(new Vector3(checkSides.transform.position.x + 0.18f, checkSides.transform.position.y +0.1f), Quaternion.Euler(0, 0, 30) * checkSides.transform.right * 0.6f, Color.red);     


        //Seta as variaveis playerCell e playerPosition de acordo com a variavel gridMovement
        if (gridMovement != Vector2Int.zero)
        {
            playerCell += gridMovement;
            playerPosition = grid.CellToWorld((Vector3Int)playerCell);
        }

        //Chama o metodo MoveToward, qual serve para a movimentar o player de acordo com o grid, recebe a a variavel da posicao para qual o player vai se mover
        MoveToward(playerPosition);
    }

    private void MoveToward(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }
}
