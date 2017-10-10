using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour {

    public  int playerTurnAxisTouch = 0;
    public  int playerMoveAxsisTouch = 0;

    // Use this for initialization


    //Left Button Down
    public void playerLeftUIPointerDown()
    {
        playerTurnAxisTouch = -1;
    }

    //Left Button Up
    public void playerLeftUIPointerUp()
    {
        playerTurnAxisTouch = 0;
    }

    //Right Button Down
    public void playerRightUIPointerDown()
    {
        playerTurnAxisTouch = 1;
    }

    //Right Button Down
    public void playerRightUIPointerUp()
    {
        playerTurnAxisTouch = 0;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
