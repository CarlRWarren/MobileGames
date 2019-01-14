using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 100.0f)] float m_force = 10.0f;
    [SerializeField] [Range(0.0f, 10.0f)] float m_lifetime = 5.0f;
    [SerializeField] AudioSource m_hit = null;

    [SerializeField] GameObject m_explosion = null;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * m_force, ForceMode.Impulse);
        Destroy(gameObject, m_lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_hit.Play();
        Instantiate(m_explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
