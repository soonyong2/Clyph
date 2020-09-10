using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Module : Unit
{
    public GameObject ProjectileObject;

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
            List<Enemy> Enemies = Object.FindObjectsOfType<Enemy>().ToList();
            if (Enemies.Count == 0)
                yield return new WaitForSeconds(Interval);
            
            Vector3 Position = transform.position;
            Enemies.Sort((Enemy A, Enemy B) => Vector3.Distance(Position, A.transform.position).CompareTo(Vector3.Distance(Position, B.transform.position)));
            if (ProjectileObject != null)
            {
                GameObject ProjectileInstance = Instantiate(ProjectileObject, transform.position, Quaternion.identity, transform);
                Projectile ProjectileComponent = ProjectileInstance.GetComponent<Projectile>();
                ProjectileComponent.Target = Enemies[0].transform.position;
            }
            yield return new WaitForSeconds(Interval);
        }
    }
}
