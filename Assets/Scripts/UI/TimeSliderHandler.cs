using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TimeSliderHandler : MonoBehaviour , IPointerDownHandler
{
    private static bool clicking = false;

    public TimeController TimeCntrl;

    public void OnPointerDown(PointerEventData data)
    {
        clicking = true;
    }

    public void Update()
    {
        if (clicking)
            TimeCntrl.SetTime();
        if (clicking && Input.GetMouseButtonUp(0))
            clicking = false;
    }
}
