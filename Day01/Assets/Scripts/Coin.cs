using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 360.0f)] float m_rotateRate = 0 / 0f;
    [SerializeField] [Range(0.0f, 10.0f)] float m_amplitude = 1.0f;
    [SerializeField] [Range(0.0f, 10.0f)] float m_waveRate = 1.0f;

    float m_time = 0.0f;
    Vector3 m_startPosition = Vector3.zero;


    void Start()
    {
        m_startPosition = transform.position;
        m_time = Random.value * 1000.0f;
    }
    
    void Update()
    {
        m_time += (m_waveRate * Time.deltaTime);
        float wave = Mathf.Sin(m_time);

        transform.position = m_startPosition + new Vector3(0.0f, wave * m_amplitude, 0.0f);
        transform.rotation = transform.rotation * Quaternion.AngleAxis(m_rotateRate * Time.deltaTime, Vector3.forward);
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().Play();
        Destroy(gameObject, 1.0f);
    }
}
