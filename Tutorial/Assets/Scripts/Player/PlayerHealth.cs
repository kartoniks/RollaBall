using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int health;
    public int score;
    public GameObject healthtext;
    public GameObject scoretext;
    Text playerhp;

	void Start () {
        playerhp = healthtext.GetComponent<Text>();
        playerhp.text = "Health: " + health;
	}
	
	void Update () {
        //display player health and score
        playerhp.text = "Health: " + health;
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        //take damage
        if (collision.gameObject.tag == "Enemy")
        {
            enemyDamage colliderDmg = collision.gameObject.GetComponent<enemyDamage>();
            health -= colliderDmg.damage;
        }
    }
    private void OnTriggerEnter(Collider other) //gather objective
    {
        if (other.gameObject.tag == "Collect")
        {
            LevelManager.objectiveCount -= 1;
            Destroy(other.gameObject);
        }
    }
}
