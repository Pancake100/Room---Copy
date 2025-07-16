using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject player;

    private bool isTiming = false;
    private float timer = 0f;
    private int counter = 0;

    private float lastTriggerTime = -1f;
    private float cooldown = 0.5f;

    void Update()
    {
        if (isTiming)
        {
            timer += Time.deltaTime;
            timerText.text = "Time:" + timer.ToString("F2") + "s";
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            if(Time.time - lastTriggerTime < cooldown)
            {
                Debug.Log("Quick exit");
                return;
            }

            lastTriggerTime = Time.time;
            counter++;

            if(counter == 1)
            {
                isTiming = true;
                timer = 0f;
                Debug.Log("Timer started.");
            }
            else if(counter == 2)
            {
                isTiming = false;
                if(timer > 0f)
                {
                    Debug.Log("Timer stopped. Time:" + timer.ToString("F2") + "s");
                    timerText.text = "Time:" + timer.ToString("F2") + "s";
                }

                timer = 0f;
                counter = 0;

            }
        }
    }
}
