using UnityEngine;
using UnityEngine.Events;

public class ContactSensor : MonoBehaviour
{
    public SpriteRenderer hazard;
    public bool isInHazard = false;

    public UnityEvent OnEnter;
    public UnityEvent OnExit;


    public UnityEvent<float> OnRandomNumber;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hazard.bounds.Contains(transform.position))
        {
            //We're in the hazard!
            if (!isInHazard)
            {
                //If we weren't already...
                OnEnter.Invoke();
                isInHazard = true;
            }
                
        }
        else {
            //We aren't in the hazard
            if (isInHazard) {
                //We were in a hazard before this frame
                OnExit.Invoke();
                OnRandomNumber.Invoke(Random.Range(1, 1000));
                isInHazard = false;
            }
            
        }
    }

    public void ShowThisNumber(float number) {
        Debug.Log(number);
    }
}
