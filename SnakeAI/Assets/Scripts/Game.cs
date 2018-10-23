using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public GameObject Snake;
    public GameObject FoodSpawner;
    public Text ScoreLabel;

    private int _score = 0;

    void Update()
    {
        if (Variables.Eaten)
        {
            Variables.Eaten = false;
            _score += FoodSpawner.GetComponent<FoodSpawner>().FoodPoints;
        }

        if (Variables.GameOver)
        {
            Snake.GetComponent<Snake>().Stop();
            FoodSpawner.GetComponent<FoodSpawner>().Stop();
            ScoreLabel.text = "Score: " + _score + " -- Press R to Restart";

            if (Input.GetKey(KeyCode.R))
            {
                print("restarting");
                Variables.GameOver = false;
                _score = 0;
                Snake.GetComponent<Snake>().Restart();
                FoodSpawner.GetComponent<FoodSpawner>().Restart();
            }
        }
        else
        {
            ScoreLabel.text = "Score: " + _score;
        }
    }
}
