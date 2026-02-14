using UnityEngine;
using UnityEngine.InputSystem;

public class FroggerResetPos : MonoBehaviour
{
    //The position to reset to
    public Transform resetPos;

    public AudioSource deathSound;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deathSound = GetComponent<AudioSource>();
        resetPosition();
    }


    //Cars can call this function to reset the position of the frogger
    public void resetPosition() { 
        deathSound.Play();
        transform.position = resetPos.position;
    }
}
