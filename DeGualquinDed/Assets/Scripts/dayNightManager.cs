using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dayNightManager : MonoBehaviour {
    public GameObject directional, gameover;
    public float totalSecondsTo16hours = 90;
    public float startDayRotationX = 0;
    public float endDayRotationX = 270;
    private float elapsedTime = 0;
    public float secondsLeft;
    //public Text text, text_shadow;

	// Use this for initialization
	void Start () {
        //SetText();
        Reset();	
	}
	
	// Update is called once per frame
	void Update () {
        //SetText();
        elapsedTime += Time.deltaTime;
        float rot = (endDayRotationX - startDayRotationX)
            / totalSecondsTo16hours;
        directional.transform.Rotate(-rot * Time.deltaTime, 0, 0);
        secondsLeft = totalSecondsTo16hours - elapsedTime;
        //Debug
        if (Input.GetKeyDown(KeyCode.R)) Reset();

        if (secondsLeft < 0)
        {
            //gameover es el campo de texto que tiene escrito 
            //el mensaje que se mostrará en el centro de la pantalla
            gameover.SetActive(true);
            Time.timeScale = 0;
        }
       

    }

    public void Reset()
    {
        totalSecondsTo16hours--;
        elapsedTime = 0;
        directional.transform.rotation = Quaternion.Euler(
            startDayRotationX,
            directional.transform.rotation.eulerAngles.y,
            directional.transform.rotation.eulerAngles.z);
    }

    /*void SetText()
    {
        float secondsXhour = totalSecondsTo16hours / 16.0f;
        int hour = (int)((totalSecondsTo16hours - secondsLeft) / secondsXhour);
        int minutes = (int)(((totalSecondsTo16hours - secondsLeft) / secondsXhour) - hour * 60);

        Debug.Log(hour+":"+ minutes);
        string label;

        if ((hour + 8) > 12)
            label = (hour + 8 - 12).ToString("00") + ":" +
                minutes.ToString("00") + "F G";

        else label = (hour + 8).ToString("00") + ":" +
            minutes.ToString("00") + "E G";

        text.text = text_shadow.text = label;
    }*/


}
