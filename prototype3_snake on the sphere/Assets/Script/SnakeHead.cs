using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : SnakeBody{
    public GameObject mainCamera;
    
    private void OnTriggerEnter(Collider other)
    {
        //print("yes");
        if (other.tag == "diamond")
        {
            mainCamera.GetComponent<Object_Diamond>().Effect(); 
        }
        else if (other.tag == "SnakeBody")
        {
            //print("you lose");
            mainCamera.GetComponent<UIManager>().GameOverActive();
           _Snake.GetComponent<Snake>().SetGameFlag();
        }
        else if (other.tag == "x2")
        {
            mainCamera.GetComponent<Object_x2>().Effect();
        }
    }
}
