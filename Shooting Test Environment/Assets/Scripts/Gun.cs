using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public int ammo = 30;
    public int totalAmmo;

    public Camera fpsCam;
    public GameObject bullet;
    public Text ammoCounter;

    private int ammoInMag;

    void Start()
    {
        totalAmmo = ammo * 4;
        ammoInMag = ammo;
        ammoCounter.text = ammo + " / " + totalAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (ammo > 0)
            {
                Shoot();
            }
        }

        if (totalAmmo > 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("Reload");
                if (totalAmmo > 30)
                {
                    ammo = 30;
                }
                else
                {
                    ammo -= ammoInMag;
                }
                totalAmmo -= ammoInMag;
                ammoInMag = 30;
            }
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        bool checkHit = Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range); 
        if (checkHit == true)
        {
            ammo -= 1;
            ammoInMag -= 1;
            Debug.Log(ammoInMag);
            ammoCounter.text = ammo + " / " + totalAmmo;
            GameObject bul = Instantiate(bullet, hit.point, Quaternion.identity);
            Destroy(bul, 2);
        }
        else
        {
            ammo -= 1;
            ammoInMag -= 1;
            Debug.Log(ammoInMag);
            ammoCounter.text = ammo + " / " + totalAmmo;
            GameObject bul = Instantiate(bullet, hit.point, Quaternion.identity);
            Destroy(bul, 2);
        }
    }
}
