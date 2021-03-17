using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shotgun : MonoBehaviour
{
    [SerializeField] private GunData shotGun;
    public int ammo = 0;
    public int totalAmmo;

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
                shootShotgun();
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

    void shootShotgun()
    {
        RaycastHit hit;
        RaycastHit hit_1;
        RaycastHit hit_2;
        RaycastHit hit_3;

        // Bullet that goes forward
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, shotGun.range))
        {
            GameObject bul = Instantiate(bullet, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(bul, 2);

            // Apply damage
        }

        // Bullet that goes forward
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward + new Vector3(-2f, 0f, 0f), out hit_1, shotGun.range))
        {
            GameObject bul = Instantiate(bullet, hit_1.point, Quaternion.LookRotation(hit_1.normal));
            Destroy(bul, 2);

            // Apply damage
        }

        // Bullet that goes up
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward + new Vector3(0f, 0.1f, 0f), out hit_2, shotGun.range))
        {
            GameObject bul = Instantiate(bullet, hit_2.point, Quaternion.LookRotation(hit_2.normal));
            Destroy(bul, 2);

            // Apply damage
        }

        // Bullet that goes down
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward + new Vector3(0f, -0.1f, 0f), out hit_3, shotGun.range))
        {
            GameObject bul = Instantiate(bullet, hit_3.point, Quaternion.LookRotation(hit_3.normal));
            Destroy(bul, 2);

            // Apply damage
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
            ammo = 8;
            totalAmmo = totalAmmo - ammoInMag;
            ammoInMag = 0;
        }
        else
        {
            ammo = 8;
            int temp = totalAmmo - ammoInMag;
            if (temp > 0)
                totalAmmo = totalAmmo - ammoInMag;
            else
                totalAmmo = 0;
            ammoInMag = 0;
        }
    }
}
