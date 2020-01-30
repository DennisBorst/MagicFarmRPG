using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //public hideInInspector
    public int waterAmount { get; set; }

    //private serialized
    [SerializeField] private int maxWaterAmount;
    [SerializeField] private int maxFoodAmount;

    //private
    private int foodAmount;

    public void ChangeWater(int waterAmountAdded)
    {
        if (waterAmount + waterAmountAdded > maxWaterAmount)
        {
            waterAmount = maxWaterAmount;
            UImanager.Instance.ChangeWaterNumber(waterAmount, maxWaterAmount);
        }
        else if (waterAmount + waterAmountAdded < 0)
        {
            waterAmount = 0;
            UImanager.Instance.ChangeWaterNumber(waterAmount, maxWaterAmount);
        }
        else
        {
            waterAmount += waterAmountAdded;
            UImanager.Instance.ChangeWaterNumber(waterAmount, maxWaterAmount);
        }
    }

    public void ChangeFood(int foodAmountAdded)
    {
        if (foodAmount + foodAmountAdded > maxFoodAmount)
        {
            foodAmount = maxWaterAmount;
            UImanager.Instance.ChangeFoodNumber(foodAmount, maxFoodAmount);
        }
        else if (foodAmount + foodAmountAdded < 0)
        {
            foodAmount = 0;
            UImanager.Instance.ChangeFoodNumber(foodAmount, maxFoodAmount);
        }
        else
        {
            foodAmount += foodAmountAdded;
            UImanager.Instance.ChangeFoodNumber(foodAmount, maxFoodAmount);
        }
    }

    #region Singleton
    private static CharacterStats instance;
    private void Awake()
    {
        instance = this;
    }
    public static CharacterStats Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CharacterStats();
            }
            return instance;
        }
    }
    #endregion
}
