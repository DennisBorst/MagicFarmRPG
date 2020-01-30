using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPoint : MonoBehaviour
{
    //private serialized
    [SerializeField] private int waterAdded;
    [SerializeField] private int maxWater;

    //private
    private bool isColliding = false;
    private void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
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

    private void Update()
    {
        if (isColliding)
        {
            CheckInput();
        }
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CharacterStats.Instance.ChangeWater(waterAdded);
        }
    }
}
