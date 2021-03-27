using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] private GunData[] gunData;

    private GameObject player;
    private GameObject bullet;
    private SwitchGuns currentGun;
    private int weapon;

    void Start()
    {
        player = GameObject.Find("Player");
        bullet = GameObject.FindGameObjectWithTag("Bullet");
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
            col.gameObject.GetComponent<Enemy>().health -= gunData[weapon].damage;
            Destroy(bullet);
        }
    }
}
