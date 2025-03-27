using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class test : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_text.text = "" + LevelInfo.currentLevel;
    }
}
