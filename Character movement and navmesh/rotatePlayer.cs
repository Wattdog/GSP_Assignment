using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatePlayer : MonoBehaviour
{

    public float speed = 15;
    public bool leanLeft = false;
    public bool leanRight = false;
    public Transform Body;
    public int zRotate = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Q))
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, (zRotate));
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, (-zRotate));
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }

        /*if (Input.GetKey(KeyCode.Q))
            transform.localRotation = Quaternion.Euler(0f, 0f, (zRotate));

        if (Input.GetKey(KeyCode.E))
            transform.localRotation = Quaternion.Euler(0f, 0f, (-zRotate));

        if (Input.GetKey(KeyCode.R))
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);*/
    }
}
