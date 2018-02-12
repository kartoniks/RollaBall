using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour {

    public float range = 10f;
    public float fireRate = 1.0f;
    public int damage = 10;
    public GameObject explosion;
    public Image nextShotImage;
    float nextFire = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        nextShotImage.fillAmount = 1.0f - nextFire / fireRate;
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
        FindObjectOfType<AudioManager>().Play("gun");

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
