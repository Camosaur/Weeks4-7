using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;


public class CarManager : MonoBehaviour
{
    public GameObject carPrefab; // Prefab for the car

    public List<GameObject> cars; // List to hold the spawned cars

    public GameObject player; // Reference to the player GameObject

    public int howManyCars = 12; // Number of cars to spawn

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < howManyCars; i++)
        {
            // Instantiate a new car at a random position
            Vector3 spawnPosition = new Vector3(0, Random.Range(-3f, 3f), 0);

            cars.Add(Instantiate(carPrefab, spawnPosition, Quaternion.identity)); // Add the spawned car to the list
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        //Check if any of the cars are touching the player. If they are, reset the player's position to the starting position.
        for (int i = 0; i < cars.Count; i++)
        {
            SpriteRenderer spriteR = cars[i].GetComponent<SpriteRenderer>();
            if (spriteR.bounds.Contains(player.transform.position))
            {
                player.GetComponent<FroggerResetPos>().resetPosition();
            }
        }

    }
}
