using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayManager : MonoBehaviour
{
    public TextMeshProUGUI dinheiroTotalText;
    public TextMeshProUGUI dinheiroGastoText;
    public TextMeshProUGUI dinheiroRecebidoText;

    public int pratosFeitos;
    public double dinheiroTotal = 300;
    public double dinheiroRecebidoDia;
    public double dinheiroGastoDia;

    DaylightCycle daylightCycle;

    void Awake()
    {
        daylightCycle = GetComponent<DaylightCycle>();
    } 

    public void ResetValue()
    {
        dinheiroTotal += dinheiroRecebidoDia;
        dinheiroTotalText.text = "Dinheiro total: R$ " + dinheiroTotal;
        pratosFeitos = 0;
        dinheiroRecebidoDia = 0;
        dinheiroGastoDia = 0;

        dinheiroRecebidoText.text = "Dinheiro recebido: R$ " + dinheiroRecebidoDia;
        dinheiroGastoText.text = "Dinheiro gasto: R$ " + dinheiroGastoDia;

        if (daylightCycle.Horas < 24 && daylightCycle.Horas >= 06)
            daylightCycle.changeDay();

        if (daylightCycle.Horas >= 00 && daylightCycle.Horas < 06)
            daylightCycle.wakeUp();      
    }

    public void VenderPrato()
    {
        dinheiroRecebidoDia += 10;
        dinheiroTotalText.text = "Dinheiro total: R$ " + (dinheiroTotal += 10);
        dinheiroRecebidoText.text = "Dinheiro recebido: R$ " + dinheiroRecebidoDia;
        pratosFeitos += 1;
    }

    public void GastarDinheiro()
    {
        dinheiroGastoDia += 5;
        dinheiroTotalText.text = "Dinheiro total: R$ " + (dinheiroTotal -= 5);
        dinheiroGastoText.text = "Dinheiro gasto: R$ " + dinheiroGastoDia;
    }
}
