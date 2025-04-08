using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float m_speed;
    [SerializeField] private Transform m_leftWaypoint;
    [SerializeField] private Transform m_rightWaypoint;

    private bool m_playerInSight;
    private Transform m_target;
    private Transform m_enemyTransform;
    private Vector3 m_startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_startPosition = transform.position;
        m_target = m_leftWaypoint;
    }

    private void Awake()
    {
        m_enemyTransform = GetComponent<Transform>();
    }

    private void Idle()
    {
        m_enemyTransform.position = Vector2.MoveTowards(m_enemyTransform.position, m_target.position, m_speed *  Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            m_playerInSight = true;
        }
        else if(collision.CompareTag("waypoint"))
        {
            if(m_target = m_leftWaypoint)
            {
                m_target = m_rightWaypoint;
            }
            else if(m_target = m_rightWaypoint)
            {
                m_target = m_leftWaypoint;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        while(m_playerInSight == false)
        {
            Idle();
        }
    }
}
