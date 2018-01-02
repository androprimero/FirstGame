using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthBehavior : MonoBehaviour
{
    public enum TGameState
    {
        PLAYING = 0,
        END_GAME
    }
    public float m_RotationalSpeed;
    public TGameState state;
    public Vector3 InitialPosition;
    public GameObject m_Ball;
    // Use this for initialization
    void Start()
    {
        InitialPosition = m_Ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == TGameState.PLAYING)
        {
            updateGameState();
        }
    }
    void OnGUI()
    {
        if(state == TGameState.END_GAME)
        {
            OnGUIEndStatement();
        }
    }
    void OnGUIEndStatement()
    {
        GUI.Label(new Rect(50, 50, 100, 100), "You Win");
        if (GUI.Button(new Rect(50, 150, 100, 100), "Restart"))
        {
            RestartGame();
        }
    }
   void updateGameState()
    {
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(new Vector3(0.0f, 0.0f,m_RotationalSpeed * Time.deltaTime));
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(new Vector3(0.0f, 0.0f, -m_RotationalSpeed * Time.deltaTime));
        if (Input.GetKey(KeyCode.W))
            transform.Rotate(new Vector3(m_RotationalSpeed * Time.deltaTime, 0.0f, 0.0f));
        if (Input.GetKey(KeyCode.S))
            transform.Rotate(new Vector3(-m_RotationalSpeed * Time.deltaTime,0.0f, 0.0f));
    }
    public void setEndGame()
    {
        Time.timeScale = 0.0f;
        state = TGameState.END_GAME;
    }
    void RestartGame()
    {
        state = TGameState.PLAYING;
        transform.rotation = Quaternion.identity;
        Time.timeScale = 1.0f;
        m_Ball.transform.position = InitialPosition;
        m_Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
