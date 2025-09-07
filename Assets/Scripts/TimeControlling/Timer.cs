using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float PassedTime;
    [Space(15f)]
    public Text PhaseText;
    [Space(10f)]
    public Phase[] Phases;

    public void Update()
    {
        for (int i = Phases.Length - 1 ; i >= 0; i--)
        {
            var Ph = Phases[i];
            if (PassedTime > Ph.TimeStart)
            {
                PhaseText.text = Ph.PhaseName;
                break;
            }
        }
    }

}

[System.Serializable]
public class Phase
{
    public float TimeStart;
    [Space(10f)]
    public string PhaseName;
}