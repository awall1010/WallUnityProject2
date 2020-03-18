using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public int score = 0;

    public void updateScore()
    {
        GetComponent<Text>().text = "Score: " + score;
    }
}
