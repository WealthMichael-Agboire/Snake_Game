using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMove : MonoBehaviour
{
    private Vector2 direction;
    bool goingUp;
    bool goingDown;
    bool goingLeft;
    bool goingRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction=Vector2.up;
        }
       
       else if (Input.GetKeyDown(KeyCode.A))
       {
        direction=Vector2.left;
       }

       else if (Input.GetKeyDown(KeyCode.D))
       {
        direction=Vector2.right;
       }

       else if (Input.GetKeyDown(KeyCode.S))
       {
        direction=Vector2.down;
       }
    }

       void FixedUpdate(){
        transform.position = new Vector2 
        (Mathf.Round(transform.position.x) + direction.x,
        Mathf.Round(transform.position.y) + direction.y);
       }

       void onCollisoin2D(Collision2D collision) {
      if (CompareTag("Wall")){
        direction=Vector2.zero;
        Debug.Log("hit");
    }

    if (CompareTag("Food")){
      direction=Vector2.zero;
        Debug.Log("hit");
    }
}
}