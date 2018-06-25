using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Stuff : PooledObject
{
    public Rigidbody Body { get; private set; }

    void Awake()
    {
        Body = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider enteredCollider)
    {
        if (enteredCollider.CompareTag("KillZone"))
        {
            ReturnToPool();
        }
    }
}
