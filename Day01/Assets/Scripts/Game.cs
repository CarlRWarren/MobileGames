using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : Singleton<Game>
{
    [SerializeField] GameObject m_gameObject = null;
    [SerializeField] [Range(1, 100)] int m_numCoins = 1;
    [SerializeField] GameObject m_pausePanel = null;
    [SerializeField] TextMeshProUGUI m_scoreUI = null;

    public int score { get; set; }
    void Start()
    {
        score = 0;
     for(int i=0; i<m_numCoins; i++)
        {
            Instantiate(m_gameObject, new Vector3(Random.Range(-10.0f, 10.0f), 1.5f, Random.Range(-10.0f, 10.0f)), m_gameObject.transform.rotation);
        }
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            m_pausePanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
        m_scoreUI.text = score.ToString("D5");
    }

    public void Resume()
    {
        m_pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void addPoints(int points)
    {
        score = score + points;
    }
}
