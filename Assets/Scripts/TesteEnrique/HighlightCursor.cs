using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
class HighlightCursor
{
    public static bool CheckIfColliderExist()
    {
        return Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
    public static RaycastHit2D ReturnCollider()
    {
        return Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
    }
}
