using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainUI : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler
{
    private static int HitObj;
    private static bool ClickingOnUI;

    public void Update()
    {
        if (HitObj != 0 && Input.GetMouseButtonDown(0))
        {
            ClickingOnUI = true;
        }

        if (ClickingOnUI && Input.GetMouseButtonUp(0))
        {
            ClickingOnUI = false;
        }
    }

    public void OnPointerEnter(PointerEventData data)
    {
        HitObj++;
    }    
    
    public void OnPointerExit(PointerEventData data)
    {
        HitObj--;
    }


    public static bool CanMoveCam()
    {
        return HitObj == 0 && !ClickingOnUI;
    }
}
