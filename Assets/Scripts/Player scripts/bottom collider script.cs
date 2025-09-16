using UnityEngine;
using UnityEngine.SceneManagement;

public class bottomcolliderscript : MonoBehaviour
{
    [SerializeField] private PlayerContoller m_playerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platforms")
        {
            m_playerScript.SetOnGround(true);
            Debug.Log("On ground");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platforms")
        {
            m_playerScript.SetOnGround(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
