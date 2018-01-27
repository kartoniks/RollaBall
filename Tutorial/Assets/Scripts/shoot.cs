using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

    public GameObject bullet;
    public GameObject player;
    public GameObject bulletSpawn;
    public float firePeriod;
    float nextShootTime = 0f;
    void Start () {
        player = GameObject.Find("Player");
	}

	void Update () {
        if (playerinrange() && nextShootTime < Time.time)
            fire();
	}
    
    bool playerinrange()
    {
        Vector3 distance = player.transform.position - transform.position;

        if (distance.magnitude < 10)
            return true;
        else return false;
    }

    void fire()
    {
        Instantiate(bullet, bulletSpawn.transform.position, Quaternion.identity);
        
        nextShootTime = Time.time + firePeriod;
    }
}
