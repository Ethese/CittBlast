using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl : MonoBehaviour {
    PointEffector2D pt;
    float dif;
    CircleCollider2D cir;
	// Use this for initialization
	void Start () {
        pt = GetComponent<PointEffector2D>();
        cir = GetComponent<CircleCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        Spawn sp = GetComponentInParent<Spawn>();
        if (dif != sp.harder)
        {
            dif = sp.harder;
            pt.forceMagnitude = pt.forceMagnitude - (dif * 0.2f);

            cir.radius = cir.radius + 3;
        }
	}
}
