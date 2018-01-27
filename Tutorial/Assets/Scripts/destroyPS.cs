using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyPS : MonoBehaviour {

    public float aliveTime = 2.0f;
	
	// Update is called once per frame
	void Update () {
        aliveTime -= Time.deltaTime;
        if (aliveTime < 0)
            Destroy(gameObject);
	}
}
