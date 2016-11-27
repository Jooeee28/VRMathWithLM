using UnityEngine;
using System.Collections;

public class touchFB : MonoBehaviour {
    private AudioSource ascomp;
    public bool lefttouch;
    public bool righttouch;
    public int nolefttouches;
    public int norighttouches;
    public GameObject mylefthand;
    public GameObject myrighthand;
    private bool lefthandvisible;
    private bool righthandvisible;

    // Use this for initialization
    void Start () {
        lefttouch = false;
        righttouch = false;
        nolefttouches = 0;
        norighttouches = 0;
        ascomp = gameObject.GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (mylefthand != null)
            lefthandvisible = mylefthand.activeInHierarchy;
            
        if (myrighthand != null)
            righthandvisible = myrighthand.activeInHierarchy;


        if (!lefthandvisible)
        {
            lefttouch = false;          
            nolefttouches = 0;
           

        }
        if (!righthandvisible)
        {
    
            righttouch = false;
            norighttouches = 0;

        }


    }
   
     void OnTriggerEnter(Collider other)
     {
        // gameObject.SetActive(false);
        string touchedhand=other.transform.parent.transform.parent.transform.parent.transform.tag;
        if (touchedhand == "lefthand")
        {
            if (!lefttouch)
            {
           
                // ascomp.Play();
                lefttouch = true;
  
            }
            nolefttouches++;
            
        }
        if (touchedhand == "righthand")
        {
            if (!righttouch)
            {
     
               //  ascomp.Play();
                righttouch = true;

            }
            norighttouches++;

        }


    }
    void OnTriggerExit(Collider other)
    {
        string touchedhand = other.transform.parent.transform.parent.transform.parent.transform.tag;
        if (touchedhand == "lefthand")
        {
            nolefttouches--;

            if (nolefttouches == 0)
            {
              //  ascomp = gameObject.GetComponent<AudioSource>();
               // ascomp.Play();
                lefttouch = false;
              
            }
 
        }
        if (touchedhand == "righthand")
        {
            norighttouches--;

            if (norighttouches ==0)
            {
                //  ascomp = gameObject.GetComponent<AudioSource>();
                // ascomp.Play();
                righttouch = false;

            }

        }

    }

}
