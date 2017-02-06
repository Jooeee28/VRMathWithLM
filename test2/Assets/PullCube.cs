using UnityEngine;
using System.Collections;

public class PullCube : MonoBehaviour {


    public GameObject myLeftHand;
    public GameObject myRightHand;

    private bool lefthandvisible;
    private bool righthandvisible;

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
        if (!transform.GetComponent<touchFB>().large) return;
        if (other == null) return;
        string n1 = other.transform.name;

        if (other.transform.parent == null) return;
        string n2 = other.transform.parent.transform.name;

        if (other.transform.parent.transform.parent  == null) return;
        string n3 = other.transform.parent.transform.parent.transform.name;

        string touchedhand = other.transform.parent.transform.parent.transform.parent.transform.tag;

        //detect right hand and then bring back pinch on cube
        //maybe create a new small adjustable cube
        //gradually

    }

    void OnTriggerExit(Collider other)
    {

    }
}
