using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    //private serialezed
    [SerializeField] private int amountOfStages;
    [SerializeField] private int currentStage;
    [SerializeField] private int foodIncrease;

    [SerializeField] private float nextStageTime;
    [SerializeField] private float currentNextStageTime;

    [SerializeField] private GameObject[] plantStages;

    //private
    private bool planted;
    private bool finished;
    private bool isColliding = false;

    private float dayTime;
    private float waterTimer;
    private float currentWaterAmount;

    // Start is called before the first frame update
    void Start()
    {
        ResetPlant();

        dayTime = DayTimer.Instance.dayTime;
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Colliding");
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            isColliding = false;
        }
    }
    void Update()
    {
        if (isColliding)
        {
            CheckInput();
        }

        if (!planted)
        {
            return;
        }

        if (currentStage == (amountOfStages - 1))
        {
            finished = true;
            return;
        }

        if(currentWaterAmount > 0)
        {
            GrowPlant();

            currentWaterAmount = Timer(currentWaterAmount);
        }
        else
        {
            currentWaterAmount = 0;

            waterTimer = Timer(waterTimer);
            if(waterTimer <= 0)
            {
                ResetPlant();
            }
        }
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Clicking");

            if (!planted)
            {
                ResetPlant();
                PlantSeed();
                return;
            }
            else if (finished)
            {
                //Get some food 
                Debug.Log("You harvest a plant");
                CharacterStats.Instance.ChangeFood(foodIncrease);

                ResetPlant();
                return;
            }
            else if (CharacterStats.Instance.waterAmount > 0)
            {
                CharacterStats.Instance.ChangeWater(-1);

                currentWaterAmount = dayTime;
            }
        }
    }
    private void PlantSeed()
    {
        planted = true;
        plantStages[0].SetActive(true);
    }

    private void GrowPlant()
    {
        currentNextStageTime = Timer(currentNextStageTime);
        waterTimer = (2 * dayTime);

        if (currentNextStageTime <= 0)
        {
            plantStages[currentStage].SetActive(false);
            currentStage++;
            plantStages[currentStage].SetActive(true);

            currentNextStageTime = nextStageTime;
        }
    }

    private float Timer(float timer)
    {
        timer -= Time.deltaTime;
        return timer;
    }

    private void ResetPlant()
    {
        planted = false;
        finished = false;

        for (int i = 0; i < plantStages.Length; i++)
        {
            plantStages[i].SetActive(false);
        }

        currentStage = 0;
        currentNextStageTime = nextStageTime;
        currentWaterAmount = 0;

        waterTimer = (2 * dayTime);
    }
}