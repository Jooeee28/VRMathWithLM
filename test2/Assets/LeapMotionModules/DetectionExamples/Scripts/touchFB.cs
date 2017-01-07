using UnityEngine;
using System.Collections;
using Leap.Unity;

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

    private GameObject cube1;
    private GameObject cube2;
    public static string num1;
    public static string num2;

    private AudioSource[] sounds;
    // Use this for initialization
    void Start () {
        lefttouch = false;
        righttouch = false;
        nolefttouches = 0;
        norighttouches = 0;
        sounds = gameObject.GetComponents<AudioSource>();

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
            
            
            //Component tempCol = other.gameObject.GetComponent<BoxCollider>();
            /*
            if(other.gameObject.tag == "cube1")
            {
                cube1 = other.gameObject;
                Transform textonobj = cube1.transform.GetChild(0);
                TextMesh tm = textonobj.GetComponent<TextMesh>();
                num1 = tm.text;
            }

            if(other.gameObject.tag == "cube2")
            {
                cube2 = other.gameObject;
                Transform textonobj = cube2.transform.GetChild(0);
                TextMesh tm = textonobj.GetComponent<TextMesh>();
                num2 = tm.text;
            }
            */

            other.gameObject.SetActive(false);

            if (!createTag)//check if there is already one
            {
                // add the amount together
                GameObject thisCube = gameObject;
                num1 = thisCube.transform.GetChild(0).GetComponent<TextMesh>().text;
                num2 = other.gameObject.transform.GetChild(0).GetComponent<TextMesh>().text;
                int result=0;
                if (num1 != null && num2 != null)
                {
                    result = int.Parse(num2) + int.Parse(num1);
                }

                Debug.Log("create cube");
                // cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube = Instantiate(other.gameObject);
                cube.transform.position = tempPos;
                cube.transform.localScale = tempScale;
                cube.transform.rotation = tempRot;
                cube.transform.parent = other.gameObject.transform.parent;
                Debug.Log("parent:");
                Debug.Log(other.gameObject.transform.parent.tag);
                cube.transform.GetChild(0).GetComponent<TextMesh>().text = " " + result;

                cube.GetComponent<touchFB>().lefttouch = false;
                cube.GetComponent<touchFB>().righttouch = false;


                cube.transform.parent.GetComponent<LeapTFB>().fbleftdebug = false;
                cube.transform.parent.GetComponent<LeapTFB>().fbrightdebug = false;

                cube.transform.parent.GetComponent<LeapTFB>().refresh();

                
                cube.GetComponent<touchFB>().nolefttouches = 0;
                cube.GetComponent<touchFB>().norighttouches = 0;
                cube.GetComponent<BoxCollider>().isTrigger = true;
                cube.GetComponent<Rigidbody>().isKinematic = true;
                cube.GetComponent<Renderer>().material.color = Color.yellow;
                AudioSource ye = cube.GetComponent<AudioSource>();// the sound of addition
                ye.playOnAwake = true;
                ye.Play();
                // Rigidbody tempRig = cube.GetComponent<Rigidbody>();
                cube.name = "Cube";
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
