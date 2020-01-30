using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UImanager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waterNumber;
    [SerializeField] private TextMeshProUGUI foodNumber;
    [SerializeField] private TextMeshProUGUI hourNumber;

    public void ChangeWaterNumber(int water, int maxWater)
    {
        waterNumber.text = "Water\n" + water + "/" + maxWater; 
    }

    public void ChangeFoodNumber(int food, int maxFood)
    {
        foodNumber.text = "Food\n" + food + "/" + maxFood;
    }

    public void HourTime(int hour)
    {
        if(hour < 10)
        {
            hourNumber.text = "0" + hour + ":00 H";
        }
        else
        {
            hourNumber.text = hour + ":00 H";
        }
    }

    #region Singleton
    private static UImanager instance;
    private void Awake()
    {
        instance = this;
    }
    public static UImanager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UImanager();
            }
            return instance;
        }
    }
    #endregion
}
