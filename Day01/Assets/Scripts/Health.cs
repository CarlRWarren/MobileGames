using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 100.0f)] float m_maxHealth = 100.0f;

    public float health { get; set; }

    void Awake()
    {
        health = m_maxHealth;
    }

    public void Damage(float damage)
    {
        health = health - damage;
        if (health <= 0.0f)
        {
            Debug.Log("Dead");
            gameObject.SendMessage("DestroyGameObject");
        }
    }
}
