using UnityEngine;
using System.Collections;

public class PullCube : MonoBehaviour {


    public GameObject myLeftHand;
    public GameObject myRightHand;

    private bool lefthandvisible;
    private bool righthandvisible;

    private bool thumb;
    private bool index;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (myLeftHand != null)
            lefthandvisible = myLeftHand.activeInHierarchy;

        if (myRightHand != null)
            righthandvisible = myRightHand.activeInHierarchy;
    }

    void OnTriggerEnter(Collider other)
    {
        if (index && thumb) return;// avoid entering after create cube
        if (!transform.GetComponent<touchFB>().large) return;
        if (other == null) return;
        string n1 = other.transform.name;
        Debug.Log(n1);

        if (other.transform.parent == null) return;
        string n2 = other.transform.parent.transform.name;//detect index and thumb
        Debug.Log(n2);
       

        if (other.transform.parent.transform.parent  == null) return;
        string n3 = other.transform.parent.transform.parent.transform.name;
        Debug.Log(n3);

        if (other.transform.parent.transform.parent.transform.parent == null) return;
        string touchedhand = other.transform.parent.transform.parent.transform.parent.transform.tag;
        Debug.Log(touchedhand);
        if (touchedhand == "lefthand") return;//forbid lefthand
        if (n2 == "index")
        {
            index = true;
        }
        if (n2 == "thumb")
        {
            thumb = true;
        }

        if (index && thumb)
        {
            Vector3 pos = transform.position;
            createCube(pos);
        }
        //detect right hand and then bring back pinch on cube
        //maybe create a new small adjustable cube
        //gradually

    }

    void OnTriggerExit(Collider other)
    {

    }

    void createCube(Vector3 pos)
    {
        GameObject _cube = null;
        if(transform.tag == "cube1")
        {
            _cube = GameObject.FindGameObjectWithTag("cube2");

            if (GameObject.Find("secondNum") != null)
            {
                GameObject.Find("secondNum").SetActive(false);
            }

        }
        else if(transform.tag == "cube2"){
            _cube = GameObject.FindGameObjectWithTag("cube1");
            if (GameObject.Find("firstNum") != null)
            {
                GameObject.Find("firstNum").SetActive(false);
            }
        }
        
        if(_cube == null)
        {
            Debug.Log("cannot find cubesub2");
            return;
        }

        if (GameObject.Find("secondSubNum") != null)
        {
            GameObject.Find("secondSubNum").SetActive(false);
        }

        

        _cube.transform.GetComponent<touchFB>().insideWall = false;
        _cube.transform.GetChild(0).GetComponent<TextMesh>().text = _cube.transform.GetComponent<touchFB>().saveText;
        _cube.transform.position = pos;
        Debug.Log(pos);

    }
}
