using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    private Vector2 _dir = Vector2.up;
    private List<Transform> _tail = new List<Transform>();
    private bool _foodEaten = false;
    public GameObject TailObject;
    public int Speed = 5;
    // Use this for initialization
    void Start()
    {
        Restart();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (_tail.Count == 0 || _dir != Vector2.left)
            {
                _dir = Vector2.right;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (_tail.Count == 0 || _dir != Vector2.up)
            {
                _dir = Vector2.down;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (_tail.Count == 0 || _dir != Vector2.right)
            {
                _dir = Vector2.left;
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            if (_tail.Count == 0 || _dir != Vector2.down)
            {
                _dir = Vector2.up;
            }
        }
    }

    public void Stop()
    {
        CancelInvoke();
    }

    public void Restart()
    {
        foreach (var tail in _tail)
        {
            Destroy(tail.gameObject);
        }
        _tail.Clear();
        _dir = Vector2.up;
        transform.localPosition = new Vector2(0, 0);
        InvokeRepeating("Move", (float)1 / Speed, (float)1 / Speed);
    }

    void Move()
    {
        Vector2 v = transform.position;
        transform.Translate(_dir);

        if (_foodEaten)
        {
            _tail.Insert(0, Instantiate(TailObject, v, Quaternion.identity).transform);
            _foodEaten = false;
        }
        else if (_tail.Count > 0)
        {
            // Move last Tail Element to where the Head was
            _tail.Last().position = v;

            // Add to front of list, remove from the back
            _tail.Insert(0, _tail.Last());
            _tail.RemoveAt(_tail.Count - 1);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name.StartsWith("FoodPrefab"))
        {
            _foodEaten = true;
            Variables.Eaten = true;
            Destroy(coll.gameObject);
        }
        else
        {
            Variables.GameOver = true;
        }
    }
}
