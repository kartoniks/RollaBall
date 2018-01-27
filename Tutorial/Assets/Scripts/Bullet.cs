using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float aliveTime;
    public float speed = 10;
    Rigidbody playerRB;
    Rigidbody bulletRB;
    private void Start() //bullet is fired in player direction
    {
        playerRB = GameObject.Find("Player").GetComponent<Rigidbody>();
        bulletRB = GetComponent<Rigidbody>();
        bulletRB.velocity = speed*(playerRB.transform.position - transform.position).normalized;
    }
    private void Update()
    {
        aliveTime -= 1 * Time.deltaTime; //bullet is destroyed in alivetime
        if (aliveTime < 0)
            Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        aliveTime = 0.1f;
    }
} 
