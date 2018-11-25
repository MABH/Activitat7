using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightActivator : MonoBehaviour {
    //public Material normalMaterial;
    //public Material lightedMaterial;
    public GameObject[] lucesCasas;
    public GameObject[] lucesFarolas;
    public dayNightManager dayNight;
    public float minutesLeftToActivate = 30;
    public GameObject[] lucesCoches;
    bool actived;
    public Text text, text_shadow;

    private MeshRenderer myRenderer;

	// Use this for initialization
	void Start () {
        //myRenderer = GetComponent<MeshRenderer>();
        TurnOff();
        actived = false;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("dayNight.secondsLeft= " + dayNight.secondsLeft);
        if ((dayNight.secondsLeft <= minutesLeftToActivate) && (!actived))
        {
            Debug.Log("Se encienden las luces");
            actived = true;
            TurnOn();
        }
        else if ((dayNight.secondsLeft > minutesLeftToActivate) && (actived))
        {
            Debug.Log("Se apagan las luces");
            TurnOff();
            actived = false;
        }
        SetText();
    }

    void TurnOn()
    {
        for (int i = 0; i< lucesCasas.Length; i++) {
            lucesCasas[i].SetActive(true);            
        }
        for (int i = 0; i < lucesFarolas.Length; i++)
        {
            lucesCasas[i].SetActive(true);
        }
        for (int i = 0; i < lucesCoches.Length; i++)
        {
            lucesCasas[i].SetActive(true);
        }
        //myRenderer.material = lightedMaterial;
    }

    void TurnOff()
    {
        for (int i = 0; i < lucesCasas.Length; i++)
        {
            lucesCasas[i].SetActive(false);
        }
        for (int i = 0; i < lucesFarolas.Length; i++)
        {
            lucesCasas[i].SetActive(false);
        }
        for (int i = 0; i < lucesCoches.Length; i++)
        {
            lucesCasas[i].SetActive(false);
        }
        //myRenderer.material = normalMaterial;
    }

    void SetText()
    {
        float secondsXhour = dayNight.totalSecondsTo16hours / 16.0f;
        int hour = (int)((dayNight.totalSecondsTo16hours - dayNight.secondsLeft) / secondsXhour);
        int minutes = (int)(((dayNight.totalSecondsTo16hours - dayNight.secondsLeft) / secondsXhour) - hour * 60);

        Debug.Log(hour + ":" + minutes);
        string label;

        if ((hour + 8) > 12)
            label = (hour + 8 - 12).ToString("00") + ":" +
                minutes.ToString("00") + "F G";

        else label = (hour + 8).ToString("00") + ":" +
            minutes.ToString("00") + "E G";

        text.text = text_shadow.text = label;
    }
}
