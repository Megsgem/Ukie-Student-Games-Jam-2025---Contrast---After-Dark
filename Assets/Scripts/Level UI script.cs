using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUIscript : MonoBehaviour
{
    [SerializeField] private GameObject m_menuPanel;
    [SerializeField] private GameObject m_controlsPanel;
    [SerializeField] private Button m_pauseButton;

    private bool m_controlsPanelEnabled;
    private bool m_pauseMenuVisible;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void LoadGame(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void ToggleControlsPanel()
    {
        if (m_controlsPanelEnabled)
        {
            m_controlsPanel.SetActive(false);
            m_pauseButton.interactable = true;
            m_menuPanel.SetActive(true);
        }
        else
        {
            m_controlsPanel.SetActive(true);
            m_pauseButton.interactable = false;
            m_menuPanel.SetActive(false);
        }
        m_controlsPanelEnabled = !m_controlsPanelEnabled;
    }

    public void TogglePauseMenu()
    {
        if (m_pauseMenuVisible)
        {
            m_menuPanel.SetActive(false);
        }
        else
        {
            m_menuPanel.SetActive(true);
        }
        m_pauseMenuVisible = !m_pauseMenuVisible;
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
