using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    //public GameObject timerText;
    float currCountdownValue = 1;
    public bool countdownStarted = false;

    private void Start()
    {
        CountdownRegulator();
    }

    public void CountdownRegulator()
    {
        if (countdownStarted == false)
        {
            countdownStarted = true;
            StartCoroutine(StartCountdown());
        }

        IEnumerator StartCountdown(float countdownValue = 5)
        {
            currCountdownValue = countdownValue;
            while (currCountdownValue > 0)
            {
                Debug.Log("Countdown: " + currCountdownValue);
                yield return new WaitForSeconds(1.0f);
                currCountdownValue--;
               // timerText.GetComponent<UnityEngine.UI.Text>().text = "Time = " + currCountdownValue.ToString();
            }
        }
    }

    public void MoveWall()
    {
        if (currCountdownValue == 0)
        {
         //   countdownStarted == false;
            
            CountdownRegulator();
        }
    }
}
