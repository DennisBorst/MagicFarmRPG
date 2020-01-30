using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimer : MonoBehaviour
{
    //public
    public int dayTime;

    public Light sunLight;

    //private serialized
    [SerializeField] private int beginHour;
    [SerializeField] private int currentDay;

    //private
    private int currentHour;

    private float currentTime;
    private float hourTime;
    private float currentHourTimer;

    void Start()
    {
        currentTime = 0;
        currentHourTimer = 0;

        hourTime = (dayTime / 24);
        currentHour = beginHour;
    }

    void Update()
    {
        currentTime = Timer(currentTime);

        ColorDay();
        HourUpdate();
    }

    private void ColorDay()
    {
        if (currentHour >= 18 || currentHour < 6)
        {
            sunLight.color = Color.black;
        }
        else
        {
            sunLight.color = Color.white;
        }
    }

    private void HourUpdate()
    {
        currentHourTimer = Timer(currentHourTimer);

        if(currentHourTimer >= hourTime)
        {
            currentHour++;
            currentHourTimer = 0;

            UImanager.Instance.HourTime(currentHour);
        }

        if(currentHour >= 24)
        {
            currentDay++;
            currentHour = 0;
            UImanager.Instance.HourTime(currentHour);
        }
    }

    private float Timer(float timer)
    {
        timer += Time.deltaTime;
        return timer;
    }

    #region Singleton
    private static DayTimer instance;
    private void Awake()
    {
        instance = this;
    }
    public static DayTimer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DayTimer();
            }
            return instance;
        }
    }
    #endregion
}
