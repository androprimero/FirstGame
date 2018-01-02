using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnObjective : MonoBehaviour {

    public LabyrinthBehavior m_Labyrinth;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter()
    {
        m_Labyrinth.setEndGame();
    }
}
