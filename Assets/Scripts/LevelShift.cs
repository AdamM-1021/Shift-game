using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelShift : MonoBehaviour
{
    [Header("Refs")]
    public Transform leftLevel;
    public Transform rightLevel;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ShiftLevel();
        }
    }

    private void ShiftLevel()
    {
        Vector3 temp = leftLevel.position;
        leftLevel.position = rightLevel.position;
        rightLevel.position = temp;
    }
}
