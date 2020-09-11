using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Module : Unit
{
    public GameObject ProjectileObject;

    protected void Update()
    {
        if (Target == null)
        {
            List<Enemy> Enemies = Object.FindObjectsOfType<Enemy>().ToList();
            Enemies.Sort((Enemy A, Enemy B) => Vector3.Distance(transform.position, A.transform.position).CompareTo(Vector3.Distance(transform.position, B.transform.position)));
            Target = Enemies[0].gameObject;
        }
    }
    public override IEnumerator Attack()
    {
        while (true)
        {
            if (Target != null && ProjectileObject != null)
            {
                GameObject ProjectileInstance = Instantiate(ProjectileObject, transform.position, Quaternion.identity, transform);
                Projectile ProjectileComponent = ProjectileInstance.GetComponent<Projectile>();
                ProjectileComponent.Target = Target.transform.position;
            }
            yield return new WaitForSeconds(Interval);
        }
    }
}
