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
    private GameObject cube;
    public static bool createTag = false;
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
        // gameObject.SetActive(false)
        //
        Debug.Log(other.gameObject.name);
        if(other.gameObject.name == "Cube")
        {
            Vector3 tempPos = other.gameObject.transform.position;
            Vector3 tempScale = other.gameObject.transform.localScale;
            Quaternion tempRot = other.gameObject.transform.rotation;
            cube = Instantiate(other.gameObject);
            other.gameObject.SetActive(false);
            //Component tempCol = other.gameObject.GetComponent<BoxCollider>();
            
            if (!createTag)//check if there is already one
            {
                
                Debug.Log("create cube");
                // cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                
                cube.transform.position = tempPos;
                cube.transform.localScale = tempScale;
                cube.transform.rotation = tempRot;
               // Rigidbody tempRig = cube.GetComponent<Rigidbody>();
                cube.SetActive(true);
                //cube.transform.rotation = tempRot;
                createTag = true;
            }
           
            return;
        }
        if (other == null 
            || other.transform.parent == null 
            || other.transform.parent.transform.parent == null 
            || other.transform.parent.transform.parent.transform.parent == null)
        {
            return;
        }
       
        Debug.Log(other.transform.parent.transform.parent.transform.parent.transform.tag);
        string touchedhand=other.transform.parent.transform.parent.transform.parent.transform.tag;
        if (touchedhand == "Untagged") return;
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
        if (other == null 
            || other.transform.parent == null 
            || other.transform.parent.transform.parent == null 
            || other.transform.parent.transform.parent.transform.parent == null) 
        {
            return;
        }
        string touchedhand = other.transform.parent.transform.parent.transform.parent.transform.tag;
        if (touchedhand == "lefthand")
        {
            if (nolefttouches > 0) {
                nolefttouches--;
            }
          

            if (nolefttouches == 0)
            {
              //  ascomp = gameObject.GetComponent<AudioSource>();
               // ascomp.Play();
                lefttouch = false;
              
            }
 
        }
        if (touchedhand == "righthand")
        {
            if (norighttouches > 0)
            {
                norighttouches--;
            }

            if (norighttouches ==0)
            {
                //  ascomp = gameObject.GetComponent<AudioSource>();
                // ascomp.Play();
                righttouch = false;

            }

        }

    }

}
