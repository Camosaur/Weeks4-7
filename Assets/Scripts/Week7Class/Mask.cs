using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Mask : MonoBehaviour
{
    public List<Transform> points;
    public Transform startPos;
    public Transform endPos;

    public int currentIndex = 0;

    public bool isPhasedOut = false;
    bool hasPath = false;

    public float maxPhaseTimer = 1;
    public float phaseSpeed = 1;
    public float phaseTime = 0;

    public AnimationCurve lerpCurve;
    public float maxLerpTimer = 1;
    public float lerpSpeed = 1;
    public float lerpTime = 1;

    SpriteRenderer spriteRenderer;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //---Phase Functionality---

        //Only do this if you are phased out
        if (isPhasedOut) {
            //Increase a timer
            phaseTime += phaseSpeed * Time.deltaTime;

            //Disable the spriteRenderer so that the player can't touch it
            spriteRenderer.enabled = false;

            //If the timer is complete, you are no longer phased out
            if (phaseTime > maxPhaseTimer) { 
                isPhasedOut=false;

                //Re-enable the renderer
                spriteRenderer.enabled=true;
            }
        }

        //--- Lerp Functionality ---

        //Only do this if you have a path
        if (hasPath)
        {

            //Update position along the lerp
            transform.position = Vector2.Lerp(startPos.position, endPos.position, lerpCurve.Evaluate(lerpTime));

            //Increase a timer
            lerpTime += lerpSpeed * Time.deltaTime;

            //If the timer is complete, you no longer have a path
            if (lerpTime > maxLerpTimer)
            {
                hasPath = false;
            }
        }
        else { 
            //On the frame where you do not have a path

            //Reset the timer
            lerpTime = 0;
            hasPath = true;

            //Get the new transforms you want.
            List<Transform> releventPoints = getPoints();

            //Update the variables
            startPos = releventPoints[0];

            endPos = releventPoints[1];
        
        }

    }

    public List<Transform> getPoints() { 
        
        //Get the first transform
        Transform start = points[currentIndex];

        //Get the second transform
        Transform end = points[changeIndex()];

        //Return them as a list
        return new List<Transform> { start, end };
    }

    public void phaseOut() { 
        //You are phased
        isPhasedOut = true;

        //Reset the phase timer
        phaseTime = 0;
    }

    
    public int changeIndex() {
        //Increase the index by 1, and reset it if it is out of list bounds. Return the current index
        currentIndex++;

        if (currentIndex >= points.Count) {
            currentIndex = 0;
        }

        return currentIndex;
    }

}
