using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Vida : MonoBehaviour {
    public GameObject Pl;
    public Text Hp;
    public int size;
    // Use this for initialization
    void Start()
    {
        Hp = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        addPoint();
    }

    void addPoint()
    {
        DamageHandler sp = Pl.GetComponent<DamageHandler>();
        size = sp.health;
        Hp.text = "Vida:  " + size + "%";
    }
}
