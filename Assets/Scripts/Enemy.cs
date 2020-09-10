using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy : Unit
{
    
    protected void Start()
    {
        base.Start();
    }

    protected void Update()
    {
        
    }

    public override IEnumerator Attack()
    {
        while (true)
        {
            // List<Module> Modules = Object.FindObjectsOfType<Module>().ToList();
            yield return new WaitForSeconds(Interval);
        }
    }
}
