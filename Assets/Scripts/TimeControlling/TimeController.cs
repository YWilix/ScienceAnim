using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public Slider TimeSlider;
    [Space(20f)]
    public AnimationClip TheAnimationClip;
    public bool TimePassing
    {
        get
        {
            return _TimePassing;
        }
        set
        {
            if (value == false)
                StopButtonUI.sprite = StartDesign;
            else
                StopButtonUI.sprite = StopDesign;
            _TimePassing = value;
            MainAnimator.enabled = value;
        }
    }//Represents if the time is stoped
    private bool _TimePassing;
    [Space(5f)]
    public Timer AnimTimer;
    [Space(20f)]
    public Animator MainAnimator;
    public Image StopButtonUI;
    [Space(20f)]
    public Sprite StopDesign;
    public Sprite StartDesign;
    public Sprite ReplayDesign;

    private bool Replaying;

    public void Start()
    {
        TimePassing = false;
        SetTime();
    }

    public void Update()
    {
        if (Replaying)
        {
            Replaying = false;
        }
        else
        {
            if (TimePassing)
                TimeSlider.value = AnimTimer.PassedTime;
            if (TimeSlider.value == 1)
            {
                TimePassing = false;
                StopButtonUI.sprite = ReplayDesign;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartStopTime();
            }
        }

    }
    
    //Used for other uses
    public void StartStopTime()
    {
        if (TimeSlider.value == 1)
        {
            SetTime(0);
            TimePassing = true;
        }
        else
            TimePassing = !TimePassing;
    }

    //Used For Ui Elements
    public void SST2()
    {
        if (TimeSlider.value == 1)
        {
            Replaying = true;
            SetTime(0);
            TimePassing = true;
        }
        else
            TimePassing = !TimePassing;
    }

    public void SetTime()
    {
        StartCoroutine(_SetTime());
    }

    public void SetTime(float To)
    {
        StartCoroutine(_SetTime(To));
    }

    private IEnumerator _SetTime(float To = -1)
    {
        TimePassing = false;

        MainAnimator.enabled = true;

        var Time = (To < 0) ? TimeSlider.value : To;

        MainAnimator.Play(TheAnimationClip.name, 0, Time);

        yield return new WaitForEndOfFrame();

        MainAnimator.enabled = !(To < 0);
    }
}
