using UnityEngine;
using System.Collections;

public class textonobject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    Transform toFollow;
     
    void  Update()
    {
        transform.position = Camera.main.WorldToViewportPoint(toFollow.position);
    }

}
