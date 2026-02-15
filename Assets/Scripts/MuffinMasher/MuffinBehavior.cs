using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MuffinBehavior : MonoBehaviour
{
    //Reference to the game manager
    public GameManager gameManager;

    //Spriterenderers to check boundries
    public SpriteRenderer top;
    public SpriteRenderer bottom;

    //A curve for the on-click lerp animation
    public AnimationCurve curve;

    //A timer for rotation
    Timer rotTime;
    //A timer for the on-click lerp animation
    public float t = -1;
    public float maxTime;
    public float speed;


    //Start and end scales. So I can mess with them in the editor
    public Vector2 startScale = Vector2.one;
    public Vector2 endScale;


    void Start()
    {
        //Get some components for me!
        rotTime = GetComponent<Timer>();
    }


    // Update is called once per frame
    void Update()
    {
        //---ON CLICK FUNCTIONALITY---
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        //Lerp timer code. This is defferent from the timer I use for rotation
        if (t >= 0 )
        {
            t += speed * Time.deltaTime;
        }

        if (t > maxTime) { 
            speed *= -1;
        }


        //Check when the player has clicked the muffin.
        //If the mouse was clicked and it is above any part of the muffin.
        if (Mouse.current.leftButton.wasPressedThisFrame && (top.bounds.Contains(mousePos) || bottom.bounds.Contains(mousePos))) {
            //Reset the timer
            t = 0;
            speed = Mathf.Abs(speed);

            //Tell game Manager about it
            gameManager.muffinClick();
        }


        //Set the scale to the t, lerp it. 
        transform.localScale = Vector2.Lerp(startScale, endScale, curve.Evaluate(t));

        //---ROTATE FUNCTIONALITY---
        transform.eulerAngles = new Vector3(0, 0, rotTime.currentCount);
        
    }
}
