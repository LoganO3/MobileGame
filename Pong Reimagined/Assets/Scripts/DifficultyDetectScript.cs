using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyDetectScript : MonoBehaviour
{
    GameLogic gameLogic;

    // Start is called before the first frame update
    void Start()
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
