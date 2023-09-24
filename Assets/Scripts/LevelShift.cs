using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelShift : MonoBehaviour
{
    [Header("Refs")]
    public GameObject leftLevel;
    public GameObject rightLevel;

    public static bool leftActive = true;
    void Start()
    {
        leftLevel.SetActive(true);
        rightLevel.SetActive(false);
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
        if (leftActive)
        {
            leftLevel.SetActive(false);
            rightLevel.SetActive(true);
            leftActive = false;
        } else
        {
            rightLevel.SetActive(false);
            leftLevel.SetActive(true);
            leftActive = true;
        }
    }
}
