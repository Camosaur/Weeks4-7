using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int cost = 20;
    public int muffins = 0;

    public List<GameObject> autoclickers;
    public GameObject autoclickerPrefab;

    //Text references
    public TextMeshProUGUI muffinsDisplay;

    //A reference to itself, because I'm not sure if I'm allowed to use the "this" keyword in this course
    public GameManager that;

    //A referance to the buy button, so I can make it un-interactable
    public Button buyButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If the player cannot afford an autoclicker, deactivate the buy button. Else make it active
        if (muffins < cost)
        {
            buyButton.interactable = false;
        }
        else { 
            buyButton.interactable = true;
        }
    }

    //You clicked the muffin! Now what?
    public void muffinClick()
    {
        //Increase the muffins by 1
        muffins++;

        //---Update the display text---
        muffinsDisplay.text = "You have " + muffins.ToString() + " muffins";
    }

    //Purchase an autoclicker. To be called by a button
    public void AutoclickerBuy()
    {

            muffins -= cost; //Pay the price in muffins by subtracting cost

            cost += cost; //Double cost. Time for some exponential growth B)

            //Instantiate a new autoclicker, and add it to the list
            autoclickers.Add(Instantiate(autoclickerPrefab, Vector2.zero, Quaternion.identity));

            //Give it's script a referance to game manager
            //It first accesses the last index of autoclickers by using count-1. This will be the most recently spawned autoclicker
            //Then it uses GetComponent to access the script I put on it, so it can assign the variable
            //Then it gives the new autoclicker a reference to itself
            autoclickers[autoclickers.Count - 1].GetComponent<Autoclicker>().gameManager = that; //For future referance, is the "this" keyword allowed in this course?

            //---Update the display text---
            muffinsDisplay.text = "You have " + muffins.ToString() + " muffins";

    
    }

}
