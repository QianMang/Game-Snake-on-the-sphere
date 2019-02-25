using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour {
    protected GameObject _Snake;
    protected int index=0;
    private int maxIndex;
	// Use this for initialization
	void Start () {
        _Snake = GameObject.FindWithTag("Snake");
        maxIndex = _Snake.GetComponent<Snake>().maxPathIndex;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetIndex(int newIndex)
    {
        index = newIndex;
    }

    public void MoveBody()
    {
        this.transform.position = _Snake.GetComponent<Snake>().GetPath(index);
        
        this.transform.LookAt(Vector3.zero);
        if (index == maxIndex-1)
            index = 0;
        else
            index++;
    }

    public int GetIndex()
    {
        return index;
    }

    //public void ResetIndex(int gap)
    //{
    //    index -= gap;
    //}

}
