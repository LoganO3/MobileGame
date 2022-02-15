using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    public bool hasCompletedEasyTimeTrial = false;
    public bool hasCompletedIntermeidateTimeTrial = false;
    public bool hasCompletedHardTimeTrial = false;
    public bool hasCompletedEasyPointTrial = false;
    public bool hasCompletedIntermeidatePointTrial = false;
    public bool hasCompletedHardPointTrial = false;
    GameObject easyTimeTrial;
    GameObject intermeidateTimeTrial;
    GameObject hardTimeTrial;
    GameObject easyPointTrial;
    GameObject intermediatePointTrial;
    GameObject hardPointTrial;

    private void Update()
    {
        GameObject easyTimeTrial = GameObject.Find("Easy Time Marker");
        GameObject intermediateTimeTrial = GameObject.Find("Intermediate Time Marker ");
        GameObject hardTimeTrial = GameObject.Find("Hard Time Marker");
        GameObject easyPointTrial = GameObject.Find("Easy Point Marker ");
        GameObject intermediatePointTrial = GameObject.Find("Intermediate Point Marker ");
        GameObject hardPointTrial = GameObject.Find("Hard Point Marker");
        if (hasCompletedEasyTimeTrial == true)
        {
            Destroy(easyTimeTrial);
        }
        if (hasCompletedIntermeidateTimeTrial == true)
        {
            Destroy(intermeidateTimeTrial);
        }
        if (hasCompletedHardTimeTrial == true)
        {
            Destroy(hardTimeTrial);
        }
        if (hasCompletedEasyPointTrial == true)
        {
            Destroy(easyPointTrial);
        }
        if (hasCompletedIntermeidatePointTrial == true)
        {
            Destroy(intermediatePointTrial);
        }
        if (hasCompletedHardPointTrial == true)
        {
            Destroy(hardPointTrial);
        }
    }

    public void LoadingIntoAchievement()
    {
        GameObject easyTimeTrial = GameObject.Find("Easy Time Marker");
        GameObject intermediateTimeTrial = GameObject.Find("Intermediate Time Marker ");
        GameObject hardTimeTrial = GameObject.Find("Hard Time Marker");
        GameObject easyPointTrial = GameObject.Find("Easy Point Marker ");
        GameObject intermediatePointTrial = GameObject.Find("Intermediate Point Marker ");
        GameObject hardPointTrial = GameObject.Find("Hard Point Marker");
        if (easyTimeTrial)
        {
            easyTimeTrial.SetActive(true);
        }
        if (intermediateTimeTrial)
        {
            intermediateTimeTrial.SetActive(true);
        }
        if (hardTimeTrial)
        {
            hardTimeTrial.SetActive(true);
        }
        if (easyPointTrial)
        {
            easyPointTrial.SetActive(true);
        }
        if (intermediatePointTrial)
        {
            intermediatePointTrial.SetActive(true);
        }
        if (hardPointTrial)
        {
            hardPointTrial.SetActive(true);
        }
    }
    public void LoadingIntoNonachievementScene()
    {
        GameObject easyTimeTrial = GameObject.Find("Easy Time Marker");
        GameObject intermediateTimeTrial = GameObject.Find("Intermediate Time Marker ");
        GameObject hardTimeTrial = GameObject.Find("Hard Time Marker");
        GameObject easyPointTrial = GameObject.Find("Easy Point Marker ");
        GameObject intermediatePointTrial = GameObject.Find("Intermediate Point Marker ");
        GameObject hardPointTrial = GameObject.Find("Hard Point Marker");
        if (easyTimeTrial)
        {
            easyTimeTrial.SetActive(false);
        }
        if (intermediateTimeTrial)
        {
            intermediateTimeTrial.SetActive(false);
        }
        if (hardTimeTrial)
        {
            hardTimeTrial.SetActive(false);
        }
        if (easyPointTrial)
        {
            easyPointTrial.SetActive(false);
        }
        if (intermediatePointTrial)
        {
            intermediatePointTrial.SetActive(false);
        }
        if (hardPointTrial)
        {
            hardPointTrial.SetActive(false);
        }
    }
}
