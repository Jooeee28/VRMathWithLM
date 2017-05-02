using UnityEngine;
using System.Collections;

public class CubeControl : MonoBehaviour {

    string[] cubes = { "cube1", "cube2", "cube3" };
    string[] numBtns = { "FirstNumCan", "SecondNumCan" ,"ThirdNumCan"};
    Rigidbody _cube;
    private AudioSource[] sounds;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void popCube(int id)
    {
        GameObject cube = GameObject.FindGameObjectWithTag(cubes[id]);
        _cube = cube.GetComponent<Rigidbody>();
        _cube.transform.GetChild(0).GetComponent<TextMesh>().text = _cube.transform.GetComponent<touchFB>().saveText;
        jumpForward(_cube);
        sounds = _cube.transform.GetComponents<AudioSource>();
        sounds[1].Play();
        GameObject can = GameObject.Find(numBtns[id]);
        can.SetActive(false);
        

    }
    void jumpForward(Rigidbody _cube)
    {
        _cube.AddRelativeForce(Vector3.forward * -2f, ForceMode.Impulse);
    }
}
