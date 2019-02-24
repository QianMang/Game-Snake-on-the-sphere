using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : SnakeBody{


    private void OnTriggerEnter(Collider other)
    {
        print("yes");
        if (other.tag == "item")
        {
            _Snake.GetComponent<Snake>().CreateNewBody();
        }
        if (other.tag == "SnakeBody")
        {
            print("you lose");
        }
    }
}
