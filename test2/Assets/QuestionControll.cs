using UnityEngine;
using System.IO;
using System.Collections;

public class QuestionControll : MonoBehaviour {
    GameObject queLine0,queLine1,queLine2;
    GameObject firstNum, secondNum, thridNum;
    GameObject firstCube, secondCube, thirdCube;
    string queNum = "";
	// Use this for initialization
	void Start () {

        locateObject();

        loadQuestionByFileName("test.txt");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void locateObject()
    {
        GameObject n = GameObject.Find("n");

        if (n != null)
        {
            firstNum = n.transform.GetChild(0).gameObject;
            secondNum = n.transform.GetChild(1).gameObject;
            queLine0 = n.transform.GetChild(2).gameObject;
            queLine1 = n.transform.GetChild(3).gameObject;
            queLine2 = n.transform.GetChild(4).gameObject;

        }

        firstCube = GameObject.FindGameObjectWithTag("cube1");
        secondCube = GameObject.FindGameObjectWithTag("cube2");

    }
    void loadQuestionByFileName(string name)
    {
        // Example #1
        // Read the file as one string.
        string path = "Assets/Resources/"+name;

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        string line = "";
        line = reader.ReadLine();
        Debug.Log(line);
        queLine0.GetComponent<TextMesh>().text = line;
        line = reader.ReadLine();
        Debug.Log(line);
        queLine1.GetComponent<TextMesh>().text = line;
        line = reader.ReadLine();
        Debug.Log(line);
        queLine2.GetComponent<TextMesh>().text = line;
        reader.Close();

    }
    
}
