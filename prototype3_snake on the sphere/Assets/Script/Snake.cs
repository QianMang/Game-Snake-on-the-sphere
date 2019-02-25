using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Snake : MonoBehaviour {

    //private int snakeLength=1;
    
    private float velocity=0.65f;     //0.5 ;10     0.7;8
    private int IndexGap = 8;     
    private const float angleV = 3f;

    public GameObject mainCamera;
    public GameObject sphere;
    public GameObject snakeHead;
    private List<GameObject> _snakeBody=new List<GameObject>() { };
    public  GameObject empty;
    public GameObject BodyPrefeb;

    public List<Vector3> path=new List<Vector3>() { };
    int path_index=0;
    public int maxPathIndex = 4000;
    private GameObject finalBody;    //the last body
    private Vector3 rotateAxis;

    //int k = 0;
	// Use this for initialization
	void Start () {
        finalBody = snakeHead;
        rotateAxis = -snakeHead.transform.right;
        _snakeBody.Add(snakeHead);
        mainCamera.GetComponent<UIManager>().SetLengthText(_snakeBody.Count);
	}
	
	// Update is called once per frame
	void Update () {
       
        print(path_index.ToString()+"  "+finalBody.GetComponent<SnakeBody>().GetIndex().ToString());
        CreateNewPath();
        MoveSnake();
        if (Input.anyKey)
            ChangeDirection();
       
    }


    void CreateNewPath()
    {
        empty.transform.position = snakeHead.transform.position;
        empty.transform.RotateAround(sphere.transform.position, rotateAxis, velocity);
        Vector3 newPosition = empty.transform.position;

        if (path.Count == maxPathIndex)        //if full,  overlap the previous
        {
            if (path_index == maxPathIndex)
            {
                path[0] = newPosition;
                path_index = 1;
            }
            else
            {
                path[path_index] = newPosition;
                path_index++;
            }
        }
        else
        {
            path.Add(newPosition);   
        }
    }

    void MoveSnake()
    {
        //print(_snakeBody.Count);
        for(int i=0 ; i<_snakeBody.Count ; i++) {
            if (i != 0)
            {
                _snakeBody[i].GetComponent<SnakeBody>().MoveBody();
            }
            else
            {
                _snakeBody[i].GetComponent<SnakeHead>().MoveBody();
            }
        }
    }
    
    public  Vector3 GetPath(int index)
    {
        return path[index];
    }

    void ChangeDirection()
    {
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            
            Quaternion from = snakeHead.transform.rotation;
            Quaternion to = Quaternion.AngleAxis(angleV,-snakeHead.transform.forward);
            rotateAxis = to* rotateAxis;
           
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            
            Quaternion from = snakeHead.transform.rotation;
            Quaternion to = Quaternion.AngleAxis(angleV, snakeHead.transform.forward);
            rotateAxis = to * rotateAxis;
           
        }
    }

    public void CreateNewBody()
    {
        Vector3 newPosition = Vector3.zero;//= path[path.Count - 1];
        Quaternion q = Quaternion.identity;
        int final_Index = finalBody.GetComponent<SnakeBody>().GetIndex();
        int newIndex = final_Index - IndexGap;
        if (newIndex < 0)
        {
            newIndex = maxPathIndex + newIndex;
        }
        finalBody= GameObjectPool.GetInstance().Object_Instantiate(BodyPrefeb, newPosition.x, newPosition.y, newPosition.z, q,newIndex);
        _snakeBody.Add(finalBody);
        mainCamera.GetComponent<UIManager>().SetLengthText(_snakeBody.Count);
    }

   
}
