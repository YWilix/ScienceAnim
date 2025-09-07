using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlace : MonoBehaviour
{
    internal static bool CanMove;

    public Camera Cam;

    public void Update()
    {
        var Pos = Cam.ScreenToViewportPoint(Input.mousePosition);

        var min = GetComponent<RectTransform>().anchorMin;
        var max = GetComponent<RectTransform>().anchorMax;

        CanMove = Pos.x >= min.x && Pos.y >= min.y && Pos.x <= max.x && Pos.y <= max.y;
    }
}
