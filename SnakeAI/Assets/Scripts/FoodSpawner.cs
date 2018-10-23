using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    //food
    public GameObject foodPrefab;
    public int SpawnSpeed = 5;
    public int SpawnStart = 0;
    public int FoodPoints = 0;

    //Borders
    public Transform topBorder;
    public Transform bottomBorder;
    public Transform rightBorder;
    public Transform leftBorder;

    GameObject food;

    // Use this for initialization
    void Start()
    {
        Restart();
    }

    public void Stop()
    {
        CancelInvoke();
    }

    void Spawn()
    {
        int x = (int)Random.Range(leftBorder.position.x, rightBorder.position.x);
        int y = (int)Random.Range(bottomBorder.position.y, topBorder.position.y);
        if (food != null)
        {
            Destroy(food);
        }
        food = Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
        FoodPoints = SpawnSpeed;
    }

    void FoodScore()
    {
        FoodPoints--;
    }

    public void Restart()
    {
        if (food != null)
        {
            Destroy(food);
        }
        InvokeRepeating("Spawn", SpawnStart, SpawnSpeed);
        InvokeRepeating("FoodScore", SpawnStart, 1);
    }
}
