using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : SnakeBody{
    public GameObject mainCamera;

    private void OnTriggerEnter(Collider other)
    {
        print("yes");
        if (other.tag == "diamond")
        {
            mainCamera.GetComponent<Object_Diamond>().Effect();
            
            
        }
        if (other.tag == "SnakeBody")
        {
            print("you lose");
        }
    }
}
