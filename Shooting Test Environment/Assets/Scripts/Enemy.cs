using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float speed;
    public int distance;

    public GameObject healthBarUi;
    public Slider slider;

    private GameObject player;

    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        // Calculates current health
        slider.value = CalculateHealth();

        if (health < maxHealth)
        {
            // Health bar will become visble once the health is less than the max health
            healthBarUi.SetActive(true);
        }

        if (health <= 0)
        {
            // Destroys the enemy once its health reaches 0
            Destroy(gameObject);
        }

        if (health > maxHealth)
        {
            // Sets enemys max health
            health = maxHealth;
        }

        // Checks to see if enemy can see player
        bool currentDis = InRange();

        if (currentDis)
        {
            // Will follow the player if currentDis returns true
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    float CalculateHealth()
    {
        // Calculates enemies current health
        return health / maxHealth;
    }

    bool InRange()
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
