using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameObject m_gameObject = null;
    [SerializeField] [Range(1, 100)] int m_numCoins = 1;
    void Start()
    {
     for(int i=0; i<m_numCoins; i++)
        {
            Instantiate(m_gameObject, new Vector3(Random.Range(-10.0f, 10.0f), 1.5f, Random.Range(-10.0f, 10.0f)), m_gameObject.transform.rotation);
        }
    }
    
    void Update()
    {
        
    }
}
