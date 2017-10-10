using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    List<int> numbersToChooseFromx = new List<int>(new int[] {15, -15});
    List<int> numbersToChooseFromy = new List<int>(new int[] { 8, -8 });
    public List<int> ptje = new List<int>();
    public int numero = 0;
    int randomNumberx;
    int randomNumbery;
    public GameObject meteoro;
    public bool running = true;
    private Transform spot;
    public Transform fspot;
    public int dificult;
    public GameObject difi;
    public float harder;

    void Start()
    {
        StartCoroutine(StartCount());
    }

    void Update()
    {
        randomNumberx = numbersToChooseFromx[Random.Range(0, numbersToChooseFromx.Count)];
        randomNumbery = numbersToChooseFromx[Random.Range(0, numbersToChooseFromy.Count)];
        spot = this.transform;
        Puntaje points = difi.GetComponent<Puntaje>();
        harder = dificult  - (points.size / 10f);
        if (harder <= 1)
        {
            harder = 0.5f;
        }
    }

    IEnumerator StartCount()
    {
        yield return new WaitForSeconds(0.5f);
        while (running == true)
        {
            Vector3 position = new Vector3(spot.transform.position.x + randomNumberx, spot.transform.position.y + randomNumbery, 0);  // creates a new position to spawn object created this by getting the "x" and "y" positions.
            if (meteoro != null)
            {
                Instantiate(meteoro, position, Quaternion.identity);  // hazard is prefab, position declared variable above. Quanternion is the spin. By addeding "identity", it's set to none.
                yield return new WaitForSeconds(harder);
                ptje.Add(1);
                Debug.Log(numero.ToString());
            }else
            {
                GameObject met = (GameObject)Instantiate(Resources.Load("Comet"), position, Quaternion.identity);
                yield return new WaitForSeconds(harder);
                numero = numero++;
            }
        }
    }
}
