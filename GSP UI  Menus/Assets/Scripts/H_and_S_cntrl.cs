using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_and_S_cntrl : MonoBehaviour
{

    public ProgressBar healthBar;
   

    public ProgressBar StaminaBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.BarValue = 100;
        Debug.Log ("health = 100");
        StaminaBar.BarValue = 100;
        Debug.Log("stamina = 100");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
