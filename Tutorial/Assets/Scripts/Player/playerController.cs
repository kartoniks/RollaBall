using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    private Rigidbody myrb;
    public int speed = 10;
    public int jumpspeed = 8;
    public bool grounded = false;
    Vector3 mousePosition;
    Vector3 playerScreenPosition;
    public GameObject gun;
    public Camera cam;

	void Start () {
        myrb = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
        movement();
        rotateGun();
        transform.rotation = Quaternion.Euler(0, 0, 0); // locks player rotation
        if (Input.GetKey("space"))
            jump();
    }

    void OnCollisionStay(Collision collision)
    {
        grounded = true;
    }
    void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }

    void movement()
    {
        float movex = speed*Input.GetAxis("Horizontal");
        float movez = speed*Input.GetAxis("Vertical");

        Vector3 movementForce = new Vector3(movex, 0f, movez);
        if(myrb.velocity.x<5 && myrb.velocity.z<5)
            myrb.AddForce(speed*movementForce);
    }
    void jump()
    {
        if (grounded)
        {
            myrb.velocity = new Vector3(myrb.velocity.x, 0, myrb.velocity.z);
            myrb.AddForce(new Vector3(0, jumpspeed, 0), ForceMode.Impulse);
        }
    }
    void rotateGun()
    {
        mousePosition = Input.mousePosition;
        playerScreenPosition = cam.WorldToScreenPoint(transform.position);
        //Debug.Log(mousePosition - playerScreenPosition);
        Vector3 goodRotation = new Vector3(mousePosition.x - playerScreenPosition.x, 0f, mousePosition.y - playerScreenPosition.y);
        gun.transform.rotation = Quaternion.LookRotation(goodRotation);
    }
}
