using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SnakeMove : MonoBehaviour
{
    private Vector2 direction;
    bool goingUp;
    bool goingDown;
    bool goingLeft;
    bool goingRight;
   List<Transform> segments;
    public Transform bodyPrefab;
    public int Snakescore;
    public Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        segments = new List<Transform>();
        segments.Add(transform);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && goingDown != true)
        {
         
            direction=Vector2.up;
            goingUp = true;
            goingLeft = false;
            goingRight = false;
            goingDown=false;
        }
       
       else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) && goingRight != true)
       {
        direction=Vector2.left;
        goingLeft=true;
        goingRight=false;
        goingDown=false;
        goingUp=false;
       }

       else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) && goingLeft != true)
       {
       
        direction=Vector2.right;
        goingRight=true;
        goingLeft=false;
        goingDown=false;
        goingUp=false;
       }

       else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) && goingUp != true)
       {
         
        direction=Vector2.down;
        goingDown = true;
        goingUp=false;
        goingLeft = false;
        goingRight=false;
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
       
        scoretext.text = Snakescore.ToString();
       
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
  Snakescore++;

   Time.fixedDeltaTime -= 0.001f;

} 


else if (other.tag == "Obstacle") 
{
    SceneManager.LoadScene("Endscene");
}

}
}