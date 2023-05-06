using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody body;

    private Touch touch;
    public int speedModifier;

    public void Start()
    {
        body=GetComponent<Rigidbody>();
    }
    public void Update()
    {
        if (Input.touchCount >0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase==TouchPhase.Moved)
            {
                body.velocity = new Vector3( touch.deltaPosition.x * speedModifier  *Time.deltaTime,
                 transform.position.y,
                 touch.deltaPosition.y * speedModifier*Time.deltaTime );
            }

            //transform position=for player moving
            //velocity=
            //Addforce=adding newton everytime
        }

        
    }
}
