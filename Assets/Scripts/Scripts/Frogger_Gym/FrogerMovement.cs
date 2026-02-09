using UnityEngine;
using UnityEngine.InputSystem;

public class FrogerMovement : MonoBehaviour
{
    [Tooltip("A timer between hops")]
    public Timer hopCooldown;

    public GameObject UIText;

    [Tooltip("The Speed of Movement. In Metres/Frame")]
    public float hopLength;

    [Tooltip("This sprite can move West and East")]
    public bool xAxis;

    [Tooltip("This sprite can move North and South")]
    public bool yAxis;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Hide the victory text at the start
        UIText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //If you are still in the cooldown, don't do anything
        if (hopCooldown.isDone())
        {
            //Jump. If you jump, reset the cooldown
            if (Jump()) {                
                hopCooldown.Reset();
            }
        }
        

    }

    public bool Jump()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);

        //Victory Condition: If you cross the top of the screen, you win!
        if (pos.y > Screen.height)
        {
            UIText.SetActive(true);
        }

        //Can this sprite move along the X-AXIS?
        if (xAxis)
        {
            //Move EAST if D or Right Arrow is pressed.
            //Only do this if you are whithin the RIGHT bound of the screen!
            if ((Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) && (pos.x < Screen.width))
            {
                transform.position += Vector3.right * hopLength;
                return true;
            }

            //Move WEST if A or Left Arrow is pressed.
            //Only do this if you are whithin the LEFT bound of the screen!
            if ((Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) && (pos.x > 0))
            {
                transform.position += Vector3.left * hopLength;
                return true;
            }
        }

        //Can this sprite move along the Y-AXIS?
        if (yAxis)
        {
            //Move NORTH if W or UP Arrow is pressed.
            //You can hop higher than the screen, so no need to check if you are within the TOP bound of the screen!
            if ((Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed))
            {
                transform.position += Vector3.up * hopLength;

                return true;
            }

            //Move SOUTH if S or DOWN Arrow is pressed.
            //Only do this if you are whithin the BOTTOM bound of the screen!
            if ((Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) && (pos.y > 0))
            {
                transform.position += Vector3.down * hopLength;
                return true;
            }
        }

        return false;
    }
}
