using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
class PlayerController : MonoBehaviour
{
    public int line, column;
    public float speed;

    CharacterPhysics physics;
    private void Start()
    {
        physics = new CharacterPhysics()
        {
            Transform = transform,
            Speed = speed,
            Line = line,
            Column = column
        };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && line < MapData.Lines) physics.IncreaseOnMap(true, out line, out column);
        if (Input.GetKeyDown(KeyCode.A) && column < MapData.Columns) physics.IncreaseOnMap(false, out line, out column);
        if (Input.GetKeyDown(KeyCode.S) && line > 0) physics.DecreaseOnMap(false, out line, out column);
        if (Input.GetKeyDown(KeyCode.D) && column > 0) physics.DecreaseOnMap(true, out line, out column);
    }

    public IEnumerator Move(Vector2 position)
    {
        if (line - position.y > column - position.x) 
        {
            yield return MoveToHorizontal(position.x);
            yield return MoveToVertical(position.y);
        }
        else
        {
            yield return MoveToVertical(position.y);
            yield return MoveToHorizontal(position.x);
        }
    }

    IEnumerator MoveToHorizontal(float targetColumn)
    {
        while(column != targetColumn)
        {
            if(column < targetColumn) physics.IncreaseOnMap(false, out line, out column);
            else physics.DecreaseOnMap(true, out line, out column);

            yield return new WaitForSeconds(speed);
        }
    }

    IEnumerator MoveToVertical(float targetLine)
    {
        while (line != targetLine)
        {
            if (line < targetLine) physics.IncreaseOnMap(true, out line, out column);
            else physics.DecreaseOnMap(false, out line, out column);

            yield return new WaitForSeconds(speed);
        }
    }

    

}
