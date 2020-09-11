using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy : Unit
{
    protected void Update()
    {
        if (Target == null)
        {
            List<Module> Modules = Object.FindObjectsOfType<Module>().ToList();
            Modules.Sort((Module A, Module B) => Vector3.Distance(transform.position, A.transform.position).CompareTo(Vector3.Distance(transform.position, B.transform.position)));
            Target = Modules[0].gameObject;
        }
    }
    public override IEnumerator Attack()
    {
        while (true)
        {
            // if (Target != null && ProjectileObject != null)
            // {
            //     GameObject ProjectileInstance = Instantiate(ProjectileObject, transform.position, Quaternion.identity, transform);
            //     Projectile ProjectileComponent = ProjectileInstance.GetComponent<Projectile>();
            //     ProjectileComponent.Target = Target.transform.position;
            // }
            yield return new WaitForSeconds(Interval);
        }
    }
}
