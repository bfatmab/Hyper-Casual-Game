using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public CameraShaker cameraShake;
    public UIManagerr uIManagerr;

    public GameObject Cam;
    public GameObject vectorback;
    public GameObject vectorforward;

    public Rigidbody body;


    private Touch touch;

    [Range(0, 20)]
    public int speedModifier;
    public int forwardSpeed;
    public void Start()
    {
        body=GetComponent<Rigidbody>();
    }
    public void Update()
    {

        if (Variables.firsttouch == 1)
        {
            transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            Cam.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorback.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorforward.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
        }



        if (Input.touchCount >0)
        {
            touch = Input.GetTouch(0);



            if (touch.phase == TouchPhase.Began)
            {
                Variables.firsttouch = 1;
            }


            else  if (touch.phase==TouchPhase.Moved)
            {
                body.velocity = new Vector3( touch.deltaPosition.x * speedModifier  *Time.deltaTime,
                 transform.position.y,
                 touch.deltaPosition.y * speedModifier*Time.deltaTime );
            }

            //transform position=for player moving
            //velocity=
            //Addforce=adding newton everytime
        }
        else if (touch.phase==TouchPhase.Ended)
        {
            //when player don't touch screen,ball cant move.
            body.velocity = Vector3.zero;
        }
        
    }

    public GameObject[] FractureItems;

    public void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("obstacle"))
        {
            cameraShake.cameraShakeCall();
            uIManagerr.StartCoroutine("whiteEffect");
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            foreach (GameObject item in FractureItems)
            {
                item.GetComponent<SphereCollider>().enabled = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
