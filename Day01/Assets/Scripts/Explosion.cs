using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 100.0f)] float m_damage = 100.0f;
    [SerializeField] [Range(0.0f, 100.0f)] float m_radius = 5.0f;
    [SerializeField] [Range(0.0f, 100.0f)] float m_force = 10.0f;
    [SerializeField] LayerMask m_layerMask;

    void Start()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_radius, m_layerMask, QueryTriggerInteraction.Ignore);
        foreach(Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(m_force, transform.position, m_radius, 8.0f);
            }

            Health health = collider.GetComponent<Health>();
            if(health)
            {
                health.Damage(m_damage);
            }
        }

        Destroy(gameObject, 3.0f);
    }    
}
