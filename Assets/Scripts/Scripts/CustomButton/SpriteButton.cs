using UnityEngine;
using UnityEngine.InputSystem;

public abstract class SpriteButton : MonoBehaviour
{

    SpriteRenderer sr;
    public Color normalColor = Color.white;
    public Color hoverColor = Color.gray;
    public Color pressedColor = Color.red;
    //public Color 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //---check if the mouse is over the sprite---
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()); // get the current mouse position

        //Is the mouse position within the bounds of the sprite renderer?
        if (sr.bounds.Contains(mousePos))
        {
            MouseIsOver();

            sr.color = hoverColor; // change the color to hover color

            //---check if the mouse button was pressed this frame---
            if(Mouse.current.leftButton.wasPressedThisFrame) {
                LeftButtonWasPressedThisFrame();
            }

            //---check if the mouse button is pressed---
            if(Mouse.current.leftButton.isPressed) {
                sr.color = pressedColor; // change the color to pressed color
                LeftButtonIsPressed();
            }

            //---check if the mouse button was released this frame---
            if(Mouse.current.leftButton.wasReleasedThisFrame) {
                LeftButtonWasReleasedThisFrame();
            }
        }
        else { 
            sr.color = normalColor; // change the color back to normal color
            MouseIsNotOver();
        }



    }

    void LeftButtonWasPressedThisFrame() {

    }

    void LeftButtonIsPressed() {

    }

    void LeftButtonWasReleasedThisFrame() { 
    
    }

    void MouseIsOver() { 
    
    }

    void MouseIsNotOver() {

    }
}
