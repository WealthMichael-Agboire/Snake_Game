using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeMove : MonoBehaviour
{
    private Vector2 direction;
    bool goingUp;
    bool goingDown;
    bool goingLeft;
    bool goingRight;
   List<Transform> segments;
    public Transform bodyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        segments = new List<Transform>();
        segments.Add(transform);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
         
            direction=Vector2.up;
        }
       
       else if (Input.GetKeyDown(KeyCode.LeftArrow))
       {
        direction=Vector2.left;
       }

       else if (Input.GetKeyDown(KeyCode.RightArrow))
       {
       
        direction=Vector2.right;
       }

       else if (Input.GetKeyDown(KeyCode.DownArrow))
       {
         
        direction=Vector2.down;
       }




      if (direction==Vector2.up) 
      {
        direction!=Vector2.down;
      }

      else if (direction==Vector2.down)
      {
        direction!=Vector2.up;
      }

      else if (direction==Vector2.left)
      {
        direction!=Vector2.right;
      }

      else if (direction==Vector2.right)
      {
        direction!=Vector2.left;
      }
      }

       void FixedUpdate()
       {
      for (int i = segments.Count - 1; i>0; i--)
      {
        segments[i].position = segments [i - 1].position;
      }
      
        transform.position = new Vector2 
        (Mathf.Round(transform.position.x) + direction.x,
        Mathf.Round(transform.position.y) + direction.y);
       }

void Grow()
 {
  Transform segment = Instantiate(bodyPrefab);
  segment.position = segments[segments.Count - 1].position;
  segments.Add(segment);
}

  // void OnCollisoin2D(Collision2D collision) {
  //    if (CompareTag("Wall"))
    //  {
   //     direction=Vector2.zero;
      //  Debug.Log("hit");
 //   }


 //   if (CompareTag("Food"))
 //   {
 //     direction=Vector2.zero;
   //     Debug.Log("hit");
   // }
  // }

void OnTriggerEnter2D (Collider2D other) {
if (other.tag == "Food")
{
    Debug.Log("hit");
    Grow();
} 

else if (other.tag == "Obstacle") 
{
    SceneManager.LoadScene("Endscene");
}
}
}