using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float m_speed;

    private bool m_playerInSight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            m_playerInSight = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
