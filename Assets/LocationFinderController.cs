using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LocationFinderController : MonoBehaviour
{
    public int line = MapData.Lines, column = MapData.Columns;
    CharacterPhysics physics;
    Vector3 StartPos;

    [SerializeField] Tilemap UI;

    // Start is called before the first frame update
    void Start()
    {
        physics = new CharacterPhysics()
        {
            Transform = transform,
            Speed = 1,
            Line = line,
            Column = column
        };
        StartPos = transform.position;
    }

    // Update is called once per frame
    public Vector2 FindLocation()
    {
        bool right = true;
        Vector2 pos = Vector2.zero;
        for (int l = MapData.Lines; l >= 0; l--)
        {
            for (int c = MapData.Columns; c > 0; c--)
            {
                if (right) physics.DecreaseOnMap(true, out line, out column);
                else physics.IncreaseOnMap(false, out line, out column);

                if (UI.HasTile(UI.WorldToCell(transform.position)))
                {
                    pos.x = c;
                    break;
                }
            }

            if (UI.HasTile(UI.WorldToCell(transform.position)))
            {
                pos.y = l;
                break;
            }

            right = !right ? true : false;
            physics.DecreaseOnMap(false, out line, out column);
        }
        transform.position = StartPos;
        return pos;
    }
}
