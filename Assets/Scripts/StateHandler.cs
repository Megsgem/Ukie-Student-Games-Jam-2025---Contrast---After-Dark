using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class StateHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_stateText;
    [SerializeField] private GameObject m_background;
    [SerializeField] private Tilemap m_platformsLight;
    [SerializeField] private Tilemap m_platformsDark;
    [SerializeField] private GameObject m_exit;

    private InputAction m_switchInput;
    private SpriteRenderer m_backgroundRenderer;
    private SpriteRenderer m_exitRenderer;
    private TilemapCollider2D m_darkPlatformsCollider;
    private TilemapCollider2D m_lightPlatformsCollider;
    private float m_switchTimeout = 2f;
    private float m_switchTime = 0.0f;


    public static string m_state;

    private void Awake()
    {
        m_switchInput = InputSystem.actions.FindAction("Switch");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_state = "Light";
        m_backgroundRenderer = m_background.GetComponent<SpriteRenderer>();
        m_exitRenderer = m_exit.GetComponent<SpriteRenderer>();
        m_lightPlatformsCollider = m_platformsLight.GetComponent<TilemapCollider2D>();
        m_darkPlatformsCollider = m_platformsDark.GetComponent<TilemapCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_state == "Light")
        {
            m_platformsLight.enabled = true;
            m_platformsDark.GetComponent<TilemapRenderer>().enabled = false;
            m_platformsDark.enabled = false;
            m_platformsLight.GetComponent<TilemapRenderer>().enabled = true;

            if (m_backgroundRenderer != null)
            {
                m_backgroundRenderer.color = Color.white;
            }

            if (m_exitRenderer != null)
            {
                m_exitRenderer.color = Color.black;
            }

            if(m_darkPlatformsCollider != null)
            {
                m_darkPlatformsCollider.enabled = false;
            }

            if(m_lightPlatformsCollider != null)
            {
                m_lightPlatformsCollider.enabled = true;
            }
        }
        else if (m_state == "Dark")
        {
            m_platformsLight.enabled = false;
            m_platformsLight.GetComponent<TilemapRenderer>().enabled = false;
            m_platformsDark.enabled = true;
            m_platformsDark.GetComponent<TilemapRenderer>().enabled = true;

            if (m_backgroundRenderer != null)
            {
                m_backgroundRenderer.color = Color.black;
            }

            if (m_exitRenderer != null)
            {
                m_exitRenderer.color = Color.white;
            }

            if(m_lightPlatformsCollider != null)
            {
                m_lightPlatformsCollider.enabled = false;
            }

            if(m_darkPlatformsCollider != null)
            {
                m_darkPlatformsCollider.enabled = true;
            }
        }

        if (m_switchInput.IsPressed() && Time.time > m_switchTime)
        {
            m_switchTime = Time.time + m_switchTimeout;

            if(m_state == "Light")
            {
                m_state = "Dark";
            }
            else if(m_state == "Dark")
            {
                m_state = "Light";
            }
            //if (m_state == "Light")
            //{
            //    m_state = "Dark";
            //    m_platformsDark.enabled = true;
            //    m_platformsDark.GetComponent<TilemapRenderer>().enabled = true;
            //    m_platformsLight.enabled = false;
            //    m_platformsLight.GetComponent<TilemapRenderer>().enabled = false;

            //    if (m_backgroundRenderer != null)
            //    {
            //        m_backgroundRenderer.color = Color.black;
            //    }

            //    if (m_exitRenderer != null)
            //    {
            //        m_exitRenderer.color = Color.white;
            //    }
            //}
            //else if (m_state == "Dark")
            //{
            //    m_state = "Light";
            //    m_platformsDark.enabled = false;
            //    m_platformsLight.GetComponent<TilemapRenderer>().enabled = true;
            //    m_platformsLight.enabled = true;
            //    m_platformsDark.GetComponent<TilemapRenderer>().enabled = false;

            //    if (m_backgroundRenderer != null)
            //    {
            //        m_backgroundRenderer.color = Color.white;
            //    }

            //    if (m_exitRenderer != null)
            //    {
            //        m_exitRenderer.color = Color.black;
            //    }
            //}
        }

        m_stateText.text = "State: " + m_state;
    }
}
