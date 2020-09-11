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
    public GameObject Target;
    bool IsAttacking = false;

    protected void Start()
    {
        
    }

    protected void FixedUpdate()
    {
        if (Target == null)
            return;

        Vector3 Distance = Target.transform.position - transform.position;
        if (Distance.magnitude > Range)
        {
            if (IsAttacking)
            {
                StopCoroutine(Attack());
                IsAttacking = false;
            }
            
            Vector3 Displacement = Distance.normalized * Speed * Time.fixedDeltaTime;
            transform.Translate(Displacement, Space.World);
        }
        else
        {
            if (!IsAttacking)
            {
                StartCoroutine(Attack());
                IsAttacking = true;
            }
        }
    }

    public abstract IEnumerator Attack();
}
