using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    Vector3 playerPosition;
    Rigidbody myrb;
    public int chaseSpeed = 10;
	// Use this for initialization
	void Start () {
        myrb = GetComponent<Rigidbody>();
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        transform.rotation = Quaternion.Euler(0, 0, 0);

        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 difference = playerPosition - gameObject.transform.position;
        difference.Normalize();
        difference *= chaseSpeed;
        if (myrb.velocity.x < 5 && myrb.velocity.z < 5)
            myrb.AddForce(difference);
	}
}
