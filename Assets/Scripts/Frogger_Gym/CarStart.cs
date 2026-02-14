using UnityEngine;

public class CarStart : MonoBehaviour
{
    public Timer timer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Initialize the timer to a random value so that not all cars start at the same time. Also set the max time to the width of the screen.
        timer.maxTime = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
        timer.minTime = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x;
        timer.currentCount = Random.Range(0, timer.maxTime);
        timer.speed = Random.Range(1f, 2f); // Set the speed to a random value between -1 and 1, so that some cars go left and some go right.
    }

    void Update()
    {
        //Set the x position of the car to the current count of the timer, so that it moves across the screen.
        transform.position = new Vector3(timer.currentCount, transform.position.y, transform.position.z);

        //If it's going right. Rotate the car to face right. Otherwise, rotate it to face left.
        if (timer.speed > 0) { 
            transform.eulerAngles = new Vector3(0, 0, 270);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }

    }
}
