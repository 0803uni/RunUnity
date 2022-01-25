using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private TriggerEvent onTriggerEnter = new TriggerEvent();
    [SerializeField] private TriggerEvent onTriggerStay = new TriggerEvent();

    void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke(other);
    }
    void OnTriggerStay(Collider other)
    {
        onTriggerStay.Invoke(other);
    }
    [Serializable]
    public class TriggerEvent : UnityEvent<Collider>
    {

    }
}
