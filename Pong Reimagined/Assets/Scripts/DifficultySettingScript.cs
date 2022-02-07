using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySettingScript : MonoBehaviour
{
    GameLogic gameLogic;

    void Update()
    {
        gameLogic = FindObjectOfType<GameLogic>();
    }

    public void SetDifficultyEasy()
    {
        gameLogic.SetDifficultyEasy();
    }
    public void SetDifficultyMedium()
    {
        gameLogic.SetDifficultyMedium();
    }
    public void SetDifficultyHard()
    {
        gameLogic.SetDifficultyHard();
    }
}
