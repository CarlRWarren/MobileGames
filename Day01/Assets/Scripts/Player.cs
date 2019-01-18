using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 360.0f)] float m_rotateRate = 90.0f;
    [SerializeField] [Range(0.0f, 60.0f)] float m_maxSpeed = 10.0f;

    [SerializeField] [Range(0.0f, 20.0f)] float m_turretRotateRate = 20.0f;

    [SerializeField] GameObject m_projectile = null;
    [SerializeField] Transform m_turret = null;
    [SerializeField] Transform m_muzzle = null;

    [SerializeField] TextMeshProUGUI m_healthUI = null;

    void Start()
    {
        
    }

    void Update()
    {
        float rotate = 0.0f;
        float forward = 0.0f;
        float right = 0.0f;

        if (Input.GetKey(KeyCode.A)) rotate = -m_rotateRate;
        if (Input.GetKey(KeyCode.D)) rotate =  m_rotateRate;
        if (Input.GetKey(KeyCode.W)) forward =  m_maxSpeed;
        if (Input.GetKey(KeyCode.S)) forward = -m_maxSpeed;
        if (Input.GetKey(KeyCode.Q)) right = -m_maxSpeed;
        if (Input.GetKey(KeyCode.E)) right =  m_maxSpeed;

        transform.rotation = transform.rotation * Quaternion.AngleAxis(rotate * Time.deltaTime, Vector3.up);
        Vector3 velocity = transform.rotation * new Vector3(right, 0.0f, forward);

        transform.position +=  velocity * Time.deltaTime;

        if(Input.GetMouseButtonDown(0))
        {
            Quaternion rotation = m_muzzle.rotation;// * Quaternion.AngleAxis(5.0f, Vector3.up);
            Instantiate(m_projectile, m_muzzle.position, rotation);
        }
        m_turret.rotation *= Quaternion.AngleAxis(-Input.GetAxis("Mouse X") * m_turretRotateRate, Vector3.forward);
        float health = GetComponent<Health>().health / 100.0f;
        m_healthUI.text = "Health: " + health.ToString("P1");
    }

    void DestroyGameObject()
    {

    }
}
