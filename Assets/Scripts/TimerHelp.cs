using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerHelp
{
    float TotalTime { get; set; }
    float CurrentTime { get; set; }
    public bool TimeOver = false;

    public TimerHelp()
    {
        CurrentTime =TotalTime;
    }
    public TimerHelp(float time)
    {
        TotalTime = time;
        CurrentTime = TotalTime; ;
    }

    public void CountDown()
    {
        if(CurrentTime >0)
            CurrentTime -=Time.deltaTime;
        else
        {
            CurrentTime = 0;
            TimeOver = true;
        }    
    }

    public void ResetTime()
    {
        CurrentTime = TotalTime; 
        TimeOver = false;
    }
    public void SetTotalTime(float totalTime)
    {
        TotalTime = totalTime;
    }

}
