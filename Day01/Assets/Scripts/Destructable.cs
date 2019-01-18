using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 5.0f)] float m_delay = 0.0f;
    [SerializeField] GameObject m_explosion = null;
    [SerializeField] bool m_activateRigidBody = false;
    [SerializeField] int m_points = 0;

    bool m_destroyed = false;

    void DestroyGameObject()
    {
        if (!m_destroyed)
        {
            m_destroyed = true;
            Game.Instance.addPoints(m_points);
            if(m_activateRigidBody)
            {
                GetComponent<Rigidbody>().isKinematic = false;
            }
            if(m_explosion)
            {
                Instantiate(m_explosion, transform.position, transform.rotation);
            }
            Destroy(gameObject, m_delay);
        }
    }
}
