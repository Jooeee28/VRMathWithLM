using UnityEngine;
using System.Collections;

public class OnCollision : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Enter called");
    }
    void OnCollisionStay(Collision col)
    {
        Debug.Log("Enter stay");
    }
    void OnCollisionEnd(Collision col)
    {
        Debug.Log("Enter end");
    }
}
