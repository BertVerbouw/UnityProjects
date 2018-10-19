using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 dir = Vector2.up;
    List<Transform> tail = new List<Transform>();
    bool foodEaten = false;
    public GameObject tailObject;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Move", (float)1 / Variables.Speed, (float)1 / Variables.Speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            dir = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            dir = Vector2.up;
        }
    }

    void Move()
    {
        Vector2 v = transform.position;
        transform.Translate(dir);

        if (foodEaten)
        {
            tail.Insert(0, Instantiate(tailObject, v, Quaternion.identity).transform);
            foodEaten = false;
        }
        else if (tail.Count > 0)
        {
            // Move last Tail Element to where the Head was
            tail.Last().position = v;

            // Add to front of list, remove from the back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        // Food?
        if (coll.name.StartsWith("FoodPrefab"))
        {
            // Get longer in next Move call
            foodEaten = true;

            // Remove the Food
            Destroy(coll.gameObject);
        }
        // Collided with Tail or Border
        else
        {
            // ToDo 'You lose' screen
        }
    }
}
