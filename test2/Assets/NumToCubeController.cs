using UnityEngine;
using System.Collections;

public class NumToCubeController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider hand)
    {
        if (hand.transform.parent.transform.name == "index")
        {
            Debug.Log("Colide with index");
        }
    }

    void OnTriggerExit(Collider hand)
    {
    }
}
