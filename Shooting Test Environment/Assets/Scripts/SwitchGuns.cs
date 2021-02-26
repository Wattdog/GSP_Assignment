using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGuns : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] weapons; // push your prefabs

    public int currentWeapon = 0;

    private int nrWeapons; // Number of Weapons

    void Start()
    {
        nrWeapons = weapons.Length;

        switchWeapon(currentWeapon); // Set default gun
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 1; i <= nrWeapons; i++)
        {
            if (Input.GetKeyDown("" + i))
            {
                currentWeapon = i - 1;

                switchWeapon(currentWeapon);
            }
        }
    }

    void switchWeapon(int index)
    {
        for (int i = 0; i < nrWeapons; i++)
        {
            if (i == index)
            {
                weapons[i].gameObject.SetActive(true);
            }
            else
            {
                weapons[i].gameObject.SetActive(false);
            }
        }
    }
}
