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
    GameObject easypointTrial;
    GameObject intermediatepointTrial;
    GameObject hardpointTrial;

    private void Update()
    {
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
            Destroy(easypointTrial);
        }
        if (hasCompletedIntermeidatePointTrial == true)
        {
            Destroy(intermediatepointTrial);
        }
        if (hasCompletedHardPointTrial == true)
        {
            Destroy(hardpointTrial);
        }
    }
}
