using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy : Unit
{
    public override IEnumerator Attack()
    {
        while (true)
        {
            SetTarget();
            // if (Target != null && ProjectileObject != null)
            // {
            //     GameObject ProjectileInstance = Instantiate(ProjectileObject, transform.position, Quaternion.identity, transform);
            //     Projectile ProjectileComponent = ProjectileInstance.GetComponent<Projectile>();
            //     ProjectileComponent.Target = Target.transform.position;
            // }
            yield return new WaitForSeconds(Interval);
        }
    }

    public override void Die()
    {
        Manager.Instance.Enemies.Remove(this);
        base.Die();
    }

    public override void SetTarget()
    {
        if (Manager.Instance == null)
            return;
        List<Module> Modules = Manager.Instance.Modules;
        Modules.Sort((Module A, Module B) => Vector3.Distance(transform.position, A.transform.position).CompareTo(Vector3.Distance(transform.position, B.transform.position)));
        Target = Modules[0].gameObject;
    }
}
