using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MuffinLookChanger : MonoBehaviour
{
    //Spriterenderers to modify
    public SpriteRenderer flavour;
    public SpriteRenderer wrapper;

    //A refrence to the wrapper slider. Or three of them, since HSV isn't in what we've learned I think
    public Slider r;
    public Slider g;
    public Slider b;

    //Flavour stuff
    public List<Sprite> flavours;
    int flavourIndex = 0;

    void Start()
    {
        //Change the sprite
        flavour.sprite = flavours[flavourIndex];
    }


    void Update()
    {
        //---Set the color of the wrapper based on the slider's value---
        wrapper.color = new Color(r.value, g.value, b.value);
    }

    //Change the flavour. To be called by a button
    public void FlavourChange()
    {
        //Update FlavourIndex
        flavourIndex++;
        if (flavourIndex >= flavours.Count) { 
            flavourIndex = 0;
        }

        //Change the sprite
        flavour.sprite = flavours[flavourIndex];
    }
}
