using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    float maxspeed = 12f;
    public float timer = 2f;

    void Start()
    {
        transform.rotation *= Quaternion.Euler(0, 0, 270);
    }
	void Update () {
        Move();
        Destruct();
    }
    
    void Move()
    {
        Vector3  pos = transform.position;
        Vector3 velocity = new Vector3(0, maxspeed * Time.deltaTime, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;
    }

    void Destruct()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
