using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 Target;
    public float Speed;
    public float Gravity;
    public Vector3 Velocity;
    public GameObject Explosion;
    public float Lifetime;
    void Start()
    {
        Vector3 Distance = Target - transform.position;
        Vector2 DistanceH = new Vector2(Distance.x, Distance.z);
        float T = Distance.magnitude / Speed;
        Vector2 VelocityH = DistanceH.normalized * Speed;
        float VelocityV = T * Gravity / 2;
        Velocity = new Vector3(VelocityH.x, VelocityV, VelocityH.y);
    }

    void FixedUpdate()
    {
        float DeltaTime = Time.fixedDeltaTime;
        Velocity.y -= Gravity * DeltaTime;
        Vector3 Displacement = Velocity * DeltaTime;
        transform.Translate(Displacement, Space.World);

        if(transform.position.y < 0)
            Explode();

            Lifetime -= Time.deltaTime;
            if(Lifetime<0)
                Destroy(gameObject);

    }

    void OnTriggerEnter(Collider ho)
    {
        var Enemy = ho.gameObject.GetComponent<Enemy>();
        if (Enemy != null)
            Explode();
    }

    void Update()
    {
        if (transform.position.y < 0)
            Explode();

        Lifetime -= Time.deltaTime;
        if (Lifetime < 0)
            Destroy(gameObject);
    }

    void Explode()
    {
        if (Explosion)
        {
            GameObject ExplosionObject = Instantiate(Explosion, transform.position, Quaternion.identity, transform.parent);
        }
        Destroy(gameObject);
    }
}
