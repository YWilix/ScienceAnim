using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSpeedController : MonoBehaviour
{
    public Animator MainAnim;
    public GameObject[] SpeedButtons;

    public void SetSpeed(SpeedBt sender)
    {
        sender.GetComponentInChildren<Image>().color = Color.white;
        sender.GetComponentInChildren<Text>().color = Color.black;

        foreach (var gb in SpeedButtons)
        {
            if (gb != sender.gameObject)
            {
                gb.GetComponentInChildren<Image>().color = new Color(0.16f,0.16f,0.16f,1);
                gb.GetComponentInChildren<Text>().color = Color.white;
            }
        }

        MainAnim.speed = sender.Speed;
    }
}
