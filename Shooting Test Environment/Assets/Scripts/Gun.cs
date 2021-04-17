using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField] private GunData gun;
    public int ammo = 0;
    private int totalAmmo;

    public Camera fpsCam;
    public GameObject bullet;
    public Text ammoCounter;

    private int ammoInMag;

    void Start()
    {
        totalAmmo = ammo * 4;
        ammoInMag = 0;
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
                reload(ammoInMag);
            }
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        bool checkHit = Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, gun.range); 
        if (checkHit == true)
        {
            Debug.DrawLine(fpsCam.transform.position, fpsCam.transform.position + fpsCam.transform.forward);
            GameObject bul = Instantiate(bullet, hit.point, Quaternion.identity);
            Destroy(bul, 2);
        }
        else
        {
            Debug.DrawLine(fpsCam.transform.position, Vector3.zero);
            GameObject bul = Instantiate(bullet, hit.point, Quaternion.identity);
            Destroy(bul, 2);
        }

        ammo -= 1;
        ammoInMag++;
        Debug.Log(ammoInMag);
        ammoCounter.text = ammo + " / " + totalAmmo;
    }

    void reload(int ammoUsed)
    {
        if (totalAmmo >= ammo)
        {
            ammo = 30;
            totalAmmo = totalAmmo - ammoInMag;
            ammoInMag = 0;
        }
        else if (totalAmmo <= ammo)
        {
            ammo = 30;
            int temp = totalAmmo - ammoInMag;
            if (temp > 0)
                totalAmmo = totalAmmo - ammoInMag;
            else
                totalAmmo = 0;
            ammoInMag = 0;
        }
    }
}
