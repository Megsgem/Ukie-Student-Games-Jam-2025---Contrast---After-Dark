using UnityEngine;
using UnityEngine.SceneManagement;

public class colliderscript : MonoBehaviour
{ 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Exit")
        {
            SceneManager.LoadScene(4);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
