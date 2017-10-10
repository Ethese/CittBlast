using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntaje : MonoBehaviour {
    public GameObject spawn;
    public Text count;
    public int size;
    // Use this for initialization
    void Start () {
        count = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        addPoint();
	}

    void addPoint()
    {
        List<int> ptje = new List<int>();
        Spawn sp = spawn.GetComponent<Spawn>();
        ptje = sp.ptje;
        size = ptje.Count + 1;
        count.text = "Puntaje:  " + size;
    }
}
