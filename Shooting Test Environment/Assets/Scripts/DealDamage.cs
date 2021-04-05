using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] private GunData[] gunData;

    private GameObject player;
    private SwitchGuns currentGun;
    private int weapon;

    void Start()
    {
        player = GameObject.Find("Player");
        currentGun = player.GetComponent<SwitchGuns>();
    }

    void Update()
    {
        int weapon = currentGun.currentWeapon;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyHealth>().health -= gunData[weapon].damage;
        }
    }
}
