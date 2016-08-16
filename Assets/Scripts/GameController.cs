using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public Transform mooble;
    public Transform startPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RestartGame()
    {
        mooble.position = startPosition.position;
    }

    public void WinGame()
    {
        Debug.Log("You did it!");
        RestartGame();
    }
}
