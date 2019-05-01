using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditText : MonoBehaviour
{
    public Text countText;
    public int timer;

    public IEnumerator countDown()
    { //Called by gamestate.DelayEnumerator

        Controller.TurnChanging = true;
        int timer_local = timer;

        for (int i = 0; i < timer_local; i++)
        {
            countText.text = (timer_local - i).ToString();
            yield return new WaitForSeconds(1);
        }

        this.gameObject.SetActive(false);
        Controller.TurnChanging = false;
    }

    public void setTimer(int timerDuration)
    {
        timer = timerDuration;
    }
}
