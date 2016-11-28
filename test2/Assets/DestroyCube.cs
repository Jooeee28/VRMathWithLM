using UnityEngine;
using System.Collections;

public class DestroyCube : MonoBehaviour {

    void OnCollisionEnter(Collision col) {

        Debug.Log(col.gameObject.name);
    }
}
