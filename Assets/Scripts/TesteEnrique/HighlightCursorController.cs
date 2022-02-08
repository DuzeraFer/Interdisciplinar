using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HighlightCursorController : MonoBehaviour
{
    public float line, column;
    [SerializeField] Grid grid;
    [SerializeField] Tilemap Ground, UI;
    [SerializeField] TileBase highlightTile;
    [SerializeField] LocationFinderController locationFinder;
    [SerializeField] PlayerController player;

    Vector3Int lastTile;
    Vector3Int cellToChange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HighlightCursor.ReturnCollider().collider != null)
        {
            if (HighlightCursor.ReturnCollider().collider.gameObject.layer == 8) OnCursorOnGround();
        }
    }

    void OnCursorOnGround()
    {
        GetCell();
        if (Input.GetMouseButtonDown(0))
        {
            print("b");
            SetPosition();
        }
    }

    void GetCell()
    {
        cellToChange = grid.WorldToCell
        (
            new Vector3
            (
                Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                0
            )
        );

        if (lastTile != null || lastTile != cellToChange) UI.SetTile(lastTile, null);

        UI.SetTile(cellToChange, highlightTile);
        UI.RefreshAllTiles();

        lastTile = cellToChange;
    }

    void SetPosition()
    {
        Ground.SetColor(Ground.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)), Color.blue);

        Vector2 pos = locationFinder.FindLocation();
        line = pos.y;
        column = pos.x;

        player.StartCoroutine(player.Move(pos));
    }
}
