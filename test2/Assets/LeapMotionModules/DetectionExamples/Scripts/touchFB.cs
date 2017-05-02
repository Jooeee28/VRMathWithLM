using UnityEngine;
using System.Collections;
using Leap.Unity;
using Mono.Data.Sqlite;
using System.Data;
using System;
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

    public float jumpSpeed = 250f;

    public bool insideWall = true;

    public bool large = false;

    Rigidbody _cube;

    public string saveText;

    private string type;

    private int n1, n2;

    // Use this for initialization
    void Start () {
        lefttouch = false;
        righttouch = false;
        nolefttouches = 0;
        norighttouches = 0;
        sounds = gameObject.GetComponents<AudioSource>();
        if (!createTag)
        {
            saveText = transform.GetChild(0).GetComponent<TextMesh>().text;
            transform.GetChild(0).GetComponent<TextMesh>().text = "";

        }
        type = transform.GetComponent<CubeProperty>().cubeType;
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

        if(insideWall == false && _cube!=null)
        {
            _cube.velocity = Vector3.zero;
        }

        //Debug.Log("position:");
        //Debug.Log(transform.position);
        if(transform.position.z >= 0.4)
        {
            insideWall = true;
        }

        if(transform.position.z <= 0.3)
        {
            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

    }
   
     void OnTriggerEnter(Collider other)
     {
        // gameObject.SetActive(false)
        //
        Debug.Log(other.gameObject.name);
        //&& other.gameObject.transform.GetComponent<CubeProperty>().cubeType == "addition"
        if (other.gameObject.name == "Cube" && !other.transform.GetComponent<touchFB>().large
            && !transform.GetComponent<touchFB>().large)//&& other.gameObject.transform.GetComponent<CubeProperty>().cubeType == "addition"
            //&& transform.GetComponent<CubeProperty>().cubeType == "addition")
        {
            /*
            if(other.transform.GetComponent<CubeProperty>().cubeType != "addition" || transform.GetComponent<CubeProperty>().cubeType != "addition")
            {
                Debug.Log("wrong action -> fail");
                //play fail sound;
                AudioSource[] wu = transform.GetComponents<AudioSource>();// the sound of failure
                wu[2].playOnAwake = true;
                wu[2].Play();

                num1 = transform.GetChild(0).GetComponent<TextMesh>().text;
                num2 = other.gameObject.transform.GetChild(0).GetComponent<TextMesh>().text;

                n1 = 0;
                n2 =0;
                if (num1 != null && num2 != null)
                {
                    n1 = int.Parse(num2);
                    n2 = int.Parse(num1);
                }

                InsertValue(n1, n2, -1, "addition");

                return;
            }*/
            Vector3 tempPos = other.gameObject.transform.position;
            Vector3 tempScale = other.gameObject.transform.localScale;
            Quaternion tempRot = other.gameObject.transform.rotation;
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
                cube.transform.parent = other.gameObject.transform.parent;
                cube.transform.position = tempPos;
                cube.transform.localScale = tempScale;
                cube.transform.rotation = tempRot;
                cube.transform.parent = other.gameObject.transform.parent;
                Debug.Log("parent:");
                Debug.Log(other.gameObject.transform.parent.tag);
                cube.transform.GetChild(0).GetComponent<TextMesh>().text = " " + result;
                cube.transform.GetChild(1).gameObject.SetActive(false);
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

                cube.transform.localScale = new Vector3(1, 1, 1);
                AudioSource[] ye = cube.GetComponents<AudioSource>();// the sound of addition
                ye[0].playOnAwake = true;
                ye[0].Play();
                //sounds[0].Play();
                cube.name = "Cube";
                cube.SetActive(true);
                createTag = true;
                n1 = 0;
                n2 = 0;
                if (num1 != null && num2 != null)
                {
                    n1 = int.Parse(num2);
                    n2 = int.Parse(num1);
                }

                InsertValue(n1, n2, result, "addition");

                if (GameObject.Find("add") != null)
                {

                    GameObject.Find("add").SetActive(false);
                }
                if (GameObject.Find("equation") != null)
                {
                    GameObject.Find("equation").SetActive(false);
                }
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
            /*
            if(insideWall 
                && other.transform.parent.transform.name == "index"
                && transform.tag !="cubesub2")
            {
                insideWall = false;

                string _name = transform.name;
                _cube = transform.GetComponent<Rigidbody>();

                _cube.transform.GetChild(0).GetComponent<TextMesh>().text = saveText;

                jumpForward(_cube);

                sounds = _cube.transform.GetComponents<AudioSource>();
                sounds[1].Play();
                if (_cube.tag == "cube1")
                {
                    if (GameObject.Find("firstNum") != null)
                    {
                        GameObject.Find("firstNum").SetActive(false);
                    }
                }
                if (_cube.tag == "cube2")
                {
                    if (GameObject.Find("secondNum") != null)
                    {
                        GameObject.Find("secondNum").SetActive(false);
                    }
                }
                if (_cube.tag == "cubesub1")
                {
                    if (GameObject.Find("firstSubNum") != null)
                    {
                        GameObject.Find("firstSubNum").SetActive(false);
                    }
                }
                if (_cube.tag == "cubesub2")
                {
                    if (GameObject.Find("secondSubNum") != null)
                    {
                        GameObject.Find("secondSubNum").SetActive(false);
                    }
                }

            }
            */

        }
        if (touchedhand == "righthand")
        {
            if (!righttouch)
            {
     
               //  ascomp.Play();
                righttouch = true;

            }
            norighttouches++;
            /*
            if (insideWall 
                && other.transform.parent.transform.name == "index"
                && transform.tag != "cubesub2")
            {
                insideWall = false;

                string _name = transform.name;

                _cube = transform.GetComponent<Rigidbody>();
                _cube.transform.GetChild(0).GetComponent<TextMesh>().text = saveText;
                jumpForward(_cube);
                sounds = _cube.transform.GetComponents<AudioSource>();
                sounds[1].Play();

                if (_cube.tag == "cube1")
                {
                    if (GameObject.Find("firstNum") != null)
                    {
                        GameObject.Find("firstNum").SetActive(false);
                    }
                }
                if (_cube.tag == "cube2")
                {
                    if (GameObject.Find("secondNum")!=null)
                    {
                        GameObject.Find("secondNum").SetActive(false);
                    }
                }
                if (_cube.tag == "cubesub1")
                {
                    if (GameObject.Find("firstSubNum") != null)
                    {
                        GameObject.Find("firstSubNum").SetActive(false);
                    }
                }
                if (_cube.tag == "cubesub2")
                {
                    if (GameObject.Find("secondSubNum") != null)
                    {
                        GameObject.Find("secondSubNum").SetActive(false);
                    }
                }


            }*/

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

        if (large && other.gameObject.name =="touchsphere")
        {
            //do final subtraction activate first cube.
            // GameObject firstSubCube = GameObject.FindGameObjectWithTag("cubesub1");
            /*
            if(transform.GetComponent<CubeProperty>().cubeType != "subtraction")
            {
                Debug.Log("wrong action!->fail!!!");
                AudioSource[] wu = transform.GetComponents<AudioSource>();// the sound of failure
                wu[2].playOnAwake = true;
                wu[2].Play();


                num1 = transform.GetChild(0).GetComponent<TextMesh>().text;
                num2 = other.gameObject.transform.parent.transform.GetChild(0).GetComponent<TextMesh>().text;

                n1 = 0;
                n2 = 0;
                if (num1 != null && num2 != null)
                {
                    n1 = int.Parse(num2);
                    n2 = int.Parse(num1);
                }

                InsertValue(n1, n2, -1, "subtraction");

                return;
            }*/
            GameObject _cube = null;
            if (transform.tag == "cube1")
            {
                _cube = GameObject.FindGameObjectWithTag("cube2");
            }
            else if (transform.tag == "cube2")
            {
                _cube = GameObject.FindGameObjectWithTag("cube1");
            }
            /*
            if(_cube.transform.GetComponent<CubeProperty>().cubeType != "subtraction")
            {
                Debug.Log("wrong action!->fail!!!");
                AudioSource[] wu = transform.GetComponents<AudioSource>();// the sound of failure
                wu[2].playOnAwake = true;
                wu[2].Play();

                num1 = transform.GetChild(0).GetComponent<TextMesh>().text;
                num2 = _cube.gameObject.transform.GetChild(0).GetComponent<TextMesh>().text;

                n1 = 0;
                n2 = 0;
                if (num1 != null && num2 != null)
                {
                    n1 = int.Parse(num2);
                    n2 = int.Parse(num1);
                }

                InsertValue(n1, n2, -1, "subtraction");

                return;
            }
            */
            if (_cube == null)
            {
                Debug.Log("cannot find cubesub1");
                return;
            }
            string  firstStr  = transform.GetChild(0).GetComponent<TextMesh>().text;
            string  secondSubNumStr = _cube.transform.GetChild(0).GetComponent<TextMesh>().text;
            int res = 0;
            if(firstStr !=null && secondSubNumStr != null)
            {
                res = int.Parse(firstStr) - int.Parse(secondSubNumStr);
            }

           transform.GetChild(0).GetComponent<TextMesh>().text = " "+ res;
           transform.parent.GetComponent<LeapTFB>().releaseCube();


            transform.GetComponent<CubeProperty>().cubeType = "result";
            _cube.transform.GetComponent<CubeProperty>().cubeType = "result";

            AudioSource[] ye = other.transform.parent.GetComponents<AudioSource>();// the sound of subtraction
            ye[0].playOnAwake = true;
            ye[0].Play();

            num1 = transform.GetChild(0).GetComponent<TextMesh>().text;
            num2 = _cube.gameObject.transform.GetChild(0).GetComponent<TextMesh>().text;

            n1 = 0;
            n2 = 0;
            if (num1 != null && num2 != null)
            {
                n1 = int.Parse(num2);
                n2 = int.Parse(num1);
            }

            InsertValue(n1, n2, 0, "subtraction");


            if (GameObject.Find("minus") != null)
            {
                GameObject.Find("minus").SetActive(false);
            }

            if (GameObject.Find("equationSub") != null)
            {
                GameObject.Find("equationSub").SetActive(false);
            }



        }
    }

    void jumpForward(Rigidbody _cube) 
    {
        _cube.AddRelativeForce(Vector3.forward*-2f,ForceMode.Impulse);
    }


    void InsertValue(int firstNum,int secondNum,int result,string action)
    {
        string conn = "URI=file:" + Application.dataPath + "/progressData.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = " INSERT INTO MoveData(firstnum, secondnum, action, result)" + " VALUES("+firstNum+", "+secondNum+", " + "'"+action+"'" + ", "+ result + ")";
        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery();

    }
}
