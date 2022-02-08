using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
class CharacterPhysics
{
    public Transform Transform;
    public float Speed;
    public int Line, Column;

    public void IncreaseOnMap(bool right, out int _line, out int _column)
    {
        Vector3 NextPos = new Vector3
        (
            0,
            Transform.position.y + MapData.Y,
            Transform.position.z
        );

        if (right)
        {
            NextPos.x = Transform.position.x + MapData.X;
            Line++;
        }
        else
        {
            NextPos.x = Transform.position.x - MapData.X;
            Column++;
        }
        Transform.localPosition = Vector3.MoveTowards(Transform.position, NextPos, Speed);
        _column = Column;
        _line = Line;
    }

    public void DecreaseOnMap(bool right, out int _line, out int _column)
    {
        Vector3 NextPos = new Vector3
        (
            0,
            Transform.position.y - MapData.Y,
            Transform.position.z
        );

        if (right)
        {
            NextPos.x = Transform.position.x + MapData.X;
            Column--;
        }
        else
        {
            NextPos.x = Transform.position.x - MapData.X;
            Line--;
        }

        Transform.localPosition = Vector3.MoveTowards(Transform.position, NextPos, Speed);
        _column = Column;
        _line = Line;
    }
}
