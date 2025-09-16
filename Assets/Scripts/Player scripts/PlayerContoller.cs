using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerContoller : MonoBehaviour
{
    private InputAction m_moveInputs;
    private InputAction m_jumpInputs;
    private Rigidbody2D m_playerRigidBody;
    private SpriteRenderer m_playerSpriteRenderer;
    private Vector2 m_playerDirection;
    private Vector2 m_playerJumpDirection;
    private float m_jumpDuration = 1.25f;
    private float m_jumpTime = 0.0f;

    private float a = 0.0f;
    private float b = 0.5f;
    public bool m_onGround;

    [SerializeField] private float m_playerSpeed;
    [SerializeField] private float m_maxPlayerSpeed;

    public static Transform m_playerTransform;

    private void Awake()
    {
        m_moveInputs = InputSystem.actions.FindAction("Move");
        m_jumpInputs = InputSystem.actions.FindAction("Jump");

        m_playerRigidBody = GetComponent<Rigidbody2D>();
        m_playerTransform = GetComponent<Transform>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetOnGround(bool newOnGround)
    {
        m_onGround = newOnGround;
    }

    private void Death()
    {
        if(m_playerTransform.position.y < -9.3)
        {
            SceneManager.LoadScene(3);
        }
    }
    //private void Win()
    //{
    //    if(m_playerTransform.position.x > 24)
    //    {
    //        SceneManager.LoadScene(3);
    //    }
    //}
   
    private void FixedUpdate()
    {
        //if (m_playerDirection == Vector2.left || m_playerDirection == Vector2.right)
        //{
        //    m_playerRigidBody.linearVelocity = (m_playerDirection + m_playerJumpDirection) * (m_playerSpeed * Time.fixedDeltaTime);
        //}
        //else if(m_playerDirection == Vector2.zero)
        //{
        //    m_playerRigidBody.linearVelocityX = 0f;
        //}

        //if (m_playerJumpDirection == Vector2.up)
        //{
        //    m_playerRigidBody.linearVelocity = (m_playerJumpDirection + m_playerDirection) * (m_playerSpeed * Time.fixedDeltaTime);
        //}
        ////else if(m_playerJumpDirection == Vector2.down)
        ////{
        ////    m_playerRigidBody.linearVelocity = (m_playerJumpDirection + m_playerDirection) * (m_playerSpeed + Time.fixedDeltaTime);
        ////}
        ///

        m_playerRigidBody.linearVelocity = new Vector2(m_playerDirection.x * (m_playerSpeed * Time.deltaTime), m_playerRigidBody.linearVelocityY);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_moveInputs.IsPressed())
        {
            m_playerDirection.x = m_moveInputs.ReadValue<Vector2>().x;
        }
        else
        {
            m_playerDirection = Vector2.zero;
        }

        //if (m_onGround)
        //{
        //    m_jumpTime = 0.0f;
        //}

        if (m_jumpInputs.IsPressed() && m_onGround/*Time.time > m_jumpTime*/)
        {
            Debug.Log("Jumping");
            //m_jumpTime = Time.time + m_jumpDuration;
            //m_playerJumpDirection = Vector2.up;
            //a = 0.0f;
            m_playerRigidBody.linearVelocity = new Vector2(m_playerRigidBody.linearVelocityX, 10f);
        }
        //else
        //{
        //    if(a < b)
        //    {
        //        a += Time.deltaTime;
        //        m_playerJumpDirection = Vector2.zero;
        //    }
        //    else /*if (a == b)*/
        //    {
        //        m_playerJumpDirection = Vector2.down;
        //    }
        //    //else
        //    //{
        //    //    m_playerJumpDirection = Vector2.zero;
        //    //}
        //}

        if(m_playerSpriteRenderer != null)
        {
            if(StateHandler.m_state == "Light")
            {
                m_playerSpriteRenderer.color = Color.black;
            }
            else if(StateHandler.m_state == "Dark")
            {
                m_playerSpriteRenderer.color = Color.white;
            }
        }

        //Win();
        Death();
    }
}
