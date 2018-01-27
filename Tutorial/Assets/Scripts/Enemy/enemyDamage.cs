using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyDamage : MonoBehaviour {

    public int damage;
    public int health = 50;
    private int maxHealth;

    [Header("Unity Stuff")]
    public GameObject myCanvas;
    public Image healthBar;

    private void Start()
    {
        maxHealth = health;
    }
    public void getHit(int howMuch)
    {
        myCanvas.SetActive(true);
        health -= howMuch;
        healthBar.fillAmount = (float) health / maxHealth;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            return;
        }

    }

}
