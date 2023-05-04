using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    public int countdownTime;
    public AIController aIController;
    public Text countdownDisplay;
    //public Puck puck;
    

    private void Awake()
    {
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0 )
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdownDisplay.text = "GO";

       

        yield return new WaitForSeconds(1f);


        countdownDisplay.gameObject.SetActive(false);
    }
}
