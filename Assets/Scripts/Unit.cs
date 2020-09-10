using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Unit : MonoBehaviour
{
    public float Range;
    public float Interval;
    public float MaxHP;
    public float HP;
    public float Speed;
    // public GameObject Target;

    protected void Start()
    {
        StartCoroutine(Attack());
    }

    protected void Update()
    {
        
    }

    public abstract IEnumerator Attack();
}
