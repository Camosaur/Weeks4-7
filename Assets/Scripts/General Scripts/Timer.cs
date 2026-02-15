using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float currentCount;

    public float minTime = 0; //The point at which the timer starts
    public float maxTime = 1; //The point when the timer stops counting;

    public float speed = 1; //How much the timer counts up per Second

    public bool autoReset = true; //Upon reaching MaxTime, does the timer reset automatically?

    public bool countDownUponReset = false; //Upon reseting, will this timer count back down to minTime? (set back to minTime otherwise)



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Make sure currentCount starts at a good value
        if (isDone())
        {
            currentCount = minTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Update the timer if it's not done
        if (!isDone())
        {
            currentCount += speed * Time.deltaTime;
        }


        //If the timer is done and you are supposed to reset, then reset
        if (isDone() && autoReset)
        {
            Reset();
        }
    }

    public void Reset()
    {
        //If it's supposed to count down...
        if (countDownUponReset)
        {
            //Reverse the speed
            speed *= -1;

            //Fix the count
            if (currentCount > maxTime)
            {
                currentCount = maxTime;
            }
            else if (currentCount < minTime)
            {
                currentCount = minTime;
            }
        }
        else
        {
            currentCount = minTime;
        }
    }

    public bool isDone()
    {
        return currentCount > maxTime || currentCount < minTime;
    }
}