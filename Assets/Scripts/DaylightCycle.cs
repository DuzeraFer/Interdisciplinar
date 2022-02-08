using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DaylightCycle : MonoBehaviour
{
    public TextMeshProUGUI horarioText;
    public TextMeshProUGUI diaText;
    [HideInInspector]
    public float Minutos;
    [HideInInspector]
    public float Horas;
    [HideInInspector]
    public int dia;

    FeedbackEndDay feedbackEndDay;

    // Start is called before the first frame update
    void Start()
    {
        feedbackEndDay = GetComponent<FeedbackEndDay>();

        Horas = 06;
        Minutos = 00;
        dia++;
        diaText.text = ("Dia: " + dia);
    }

    // Update is called once per frame
    void Update()
    {
        changeHour();

        if (Horas == 02)
        {
            feedbackEndDay.ReturnFeedBack();
        }
    }

    //Metodo a ser utilizado quando ocorrer a troca de dia, seja por botao ou por horario
    public void changeDay()
    {
        Horas = 06;
        Minutos = 00;
        dia++;
        diaText.text = ("Dia: " + dia);

        feedbackEndDay.PanelDesactive();
    }

    public void wakeUp()
    {
        Horas = 06;
        Minutos = 00;

        feedbackEndDay.PanelDesactive();
    }

    //Metodo chamado no update para que ocorra a contagem do horario
    public void changeHour()
    {
        //Trocar o valor do multiplicador para ajustar o tempo do dia do jogo
        //4 para durar 6 minutos, 3 para durar 8 minutos, 2.4 para durar 10 minutos, 2 para durar 12 minutos.
        Minutos += Time.deltaTime * 3f;

        if (Minutos > 60)
        {
            Minutos = 0;
            Horas += 1;
        }

        if (Horas < 10)
        {
            if (Minutos < 10)
            {
                horarioText.text = "0" + Horas + ":0" + (int)Minutos;
            }
            else
                horarioText.text = "0" + Horas + ":" + (int)Minutos;
        }
        else
            horarioText.text = Horas + ":" + (int)Minutos;

        if (Horas == 24)
        {
            Horas = 00;
            dia++;
            diaText.text = ("Dia: " + dia);
        }
    }
}
