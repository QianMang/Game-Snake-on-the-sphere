using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour {
    
    public Text lengthText;
    public GameObject GameOver;
    public GameObject Buff;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetLengthText(int length)
    {
        lengthText.text = "Length:  "+length.ToString();
    }

    public void BuffActive(bool isActive)
    {
        Buff.SetActive(isActive);
    }
    

    public void GameOverActive()
    {
        GameOver.SetActive(true);
    }

    public void RetryBtn()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
