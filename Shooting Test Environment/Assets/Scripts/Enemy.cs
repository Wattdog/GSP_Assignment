using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float distance;
    
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Checks to see if enemy can see player
        bool currentDis = inRange();

        if (currentDis)
        {
            // Will follow the player if currentDis returns true
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    bool inRange()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < distance)
        {
            // Will return true if the distance between the player and enemy is 
            // less than the set distance
            return true;
        }
        else
        {
            // Will return false if the distance between the player and enemy is 
            // greater than the set distance
            return false;
        }
    }
}
