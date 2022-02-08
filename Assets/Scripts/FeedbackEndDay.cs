using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FeedbackEndDay : MonoBehaviour
{
    public GameObject panelReport;

    public TextMeshProUGUI brutoResultText;
    public TextMeshProUGUI liquidoResultText;
    public TextMeshProUGUI pratosFeitosResultText;

    DayManager dayManager;    

    private void Awake()
    {
        panelReport.SetActive(false);
        dayManager = GetComponent<DayManager>();       
    }

    public void ReturnFeedBack()
    {
        panelReport.SetActive(true);
        Time.timeScale = 0;

        brutoResultText.text =  "R$ " + dayManager.dinheiroRecebidoDia.ToString();
        liquidoResultText.text = "R$ " + (dayManager.dinheiroRecebidoDia - dayManager.dinheiroGastoDia).ToString();
        pratosFeitosResultText.text = dayManager.pratosFeitos.ToString();
    }

    public void PanelDesactive()
    {
        panelReport.SetActive(false);
        Time.timeScale = 1;
    }
}
