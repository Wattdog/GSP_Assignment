using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData basic_Enemy;
	public float delay = 3f;
    
    private GameObject player;
	private float countdown;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        // Checks to see if enemy can see player
        bool currentDis = inRange();

        if (currentDis)
        {
            // Will follow the player if currentDis returns true
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, basic_Enemy.speed * Time.deltaTime);
            countdown -= Time.deltaTime;
            Debug.Log(countdown);
            if (countdown <= 0)
            {
                countdown = playerHit();
                player.GetComponent<PlayerHealth>().health -= basic_Enemy.damage;
            }
        }
    }

    bool inRange()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < basic_Enemy.distance)
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

    float playerHit()
    {
        return delay;
    }
}
