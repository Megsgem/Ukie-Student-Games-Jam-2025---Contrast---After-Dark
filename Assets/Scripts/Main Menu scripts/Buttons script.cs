using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttonsscript : MonoBehaviour
{
    [SerializeField] private GameObject m_menuPanel;
    [SerializeField] private GameObject m_controlsPanel;

    private bool m_controlsPanelEnabled;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void LoadGame(int sceneNumber)
    {
        LevelInfo.currentLevel = sceneNumber;
        SceneManager.LoadScene(sceneNumber);
    }

    public void ToggleControlsPanel()
    {
        if (m_controlsPanelEnabled)
        {
            m_controlsPanel.SetActive(false);
            m_menuPanel.SetActive(true);
        }
        else
        {
            m_controlsPanel.SetActive(true);
            m_menuPanel.SetActive(false);
        }
        m_controlsPanelEnabled = !m_controlsPanelEnabled;
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
