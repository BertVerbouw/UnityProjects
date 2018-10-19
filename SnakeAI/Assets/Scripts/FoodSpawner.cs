using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    //food
    public GameObject foodPrefab;

    //Borders
    public Transform topBorder;
    public Transform bottomBorder;
    public Transform rightBorder;
    public Transform leftBorder;

    GameObject food;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", 1, 5);
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
    }
}
