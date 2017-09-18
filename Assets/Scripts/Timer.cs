using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public float myTime;
    public Text textTime;
    private float starts;
    private bool finnished;
    private string seconds;
    private string minutes;
    [SerializeField]
    private finishLvl checkWin;
    [SerializeField]
    private GameObject fromThat;
    void Awake()
    {
        //textTime = GetComponent<Text>();    
    }
    void Start () {
        fromThat = GetComponent<GameObject>();
    }

    void Update()
    {

        if (!checkWin.finishLevel)
        {
            if (finnished) return;

                myTime -= Time.deltaTime;
                //Deel het door 60 zodat je weet hoeveel minuten eruit moeten geprint worden
                string minute = ((int)myTime / 60).ToString();
                //Pak de rest waarden van de minuten zodat je de secondes hebt
                string second = (myTime % 60).ToString("f0");
                //Check of het 2 decimalen bevat en anders sluit een '0' aan

            if (second.Length == 1) { seconds = "0" + second; } else { seconds = second; }
            if (minute.Length == 1) { minutes = "0" + minute; } else { minutes = minute; }

            //Text wordt vervangen met de recente tijd
            textTime.text = minutes + ":" + seconds;


                //Als de tijd om is activeer de Finnished functie
                if (myTime <= 0.0001f) Finnished();

        }
    }
    public void Finnished()
    {
        finnished = true;
        textTime.color = Color.red;
        SceneManager.LoadScene("LoseScreen");
    }

}
