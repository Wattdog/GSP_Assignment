using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_Movment : MonoBehaviour {

    public Rigidbody projectile;
    public Transform shotPos;
    public float shotForce = 1000f;
    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensativity = 2.0f;
    public float smoothing = 2.0f;
    GameObject Character;
	// Use this for initialization
	void Start () {
        Character = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensativity * smoothing, sensativity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, mouseDelta.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseDelta.y, 1f / smoothing);
        mouseLook += smoothV;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        Character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Character.transform.up);

        if (Input.GetButtonUp("Fire1"))
        {
            Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
            shot.AddForce(shotPos.forward * shotForce);
        }
	}
}
