using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public float range = 10f;
    public float fireRate = 1.0f;
    public int damage = 10;
    public GameObject explosion;
    float nextFire = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") && nextFire <= 0)
        {
            nextFire += fireRate;
            Shoot();
        }
        if(nextFire > 0)
             nextFire -= Time.deltaTime;
	}

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            if(hit.transform.tag == "Enemy")
            {
                enemyDamage target = hit.transform.gameObject.GetComponent<enemyDamage>();
                target.getHit(damage);
            }
            Instantiate(explosion, hit.point-transform.forward+ Vector3.up, Quaternion.identity);
        }

    }
}
