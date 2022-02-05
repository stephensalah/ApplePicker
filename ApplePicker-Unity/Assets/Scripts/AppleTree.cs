/*
 * Created by: Steve Salah
 * Date Created: Jan 31, 2022
 * Last Editted: Feb 5, 2022
 * Last Editted by: Steve Salah
 * 
 * Description: Apple Tree Script
 * */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    // Variables 
    [Header("Set in Inspector")]
    public float speed = 1f; //tree speed
    public float leftAndRightEdge = 10f; //Stay on Screen
    public GameObject applePreFab; //prefab for instantiating apples
    public float secondsBetweenAppleDrops = 1f; //time between apple drops
    public float chanceToChangeDirections = .1f; //chance that the tree will change directions


    // Start is called before the first frame update
    void Start()
    {
        Invoke( "DropApple", 2f);

        
    }
    void DropApple(){
        GameObject apple= Instantiate<GameObject>(applePreFab);
        apple.transform.position = transform.position;
        Invoke( "DropApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position; //current position
        pos.x += speed * Time.deltaTime; //adds speed to x position
        transform.position = pos; //apply the position value

        //Change Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //set speed to positive
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);//set speed to negative value
        }
        //End Update
    }
    //FixedUpdate is called on fixed intervals (50 times per second)

    private void FixedUpdate()
    {
       //Test chance of direction change
       if (Random.value*3 <chanceToChangeDirections)
        {
            speed *= -1; //change directions
        }
    }//end FixedUpdate()
}
