using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int cost = 20;
    public int muffins = 0;

    public List<GameObject> autoclickers;
    public GameObject autoclickerPrefab;

    //Text references
    public TextMeshProUGUI muffinsDisplay;
    public TextMeshProUGUI autoclickersDisplay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    //You clicked the muffin! Now what?
    public void muffinClick()
    {
        muffins++;

        //---Update the display text---
        muffinsDisplay.text = "You have "+ muffins.ToString()+ " muffins.";
    }

    //Purchase an autoclicker. To be called by a button
    public void AutoclickerBuy()
    {
    

    
    }

}
