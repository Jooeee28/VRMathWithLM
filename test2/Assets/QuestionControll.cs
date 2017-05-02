using UnityEngine;
using System.IO;
using System.Collections;

public class QuestionControll : MonoBehaviour {
    GameObject queLine0,queLine1,queLine2,queLine3, queLine4, queLine5;
    GameObject firstNum, secondNum, thirdNum;
    GameObject firstCube, secondCube, thirdCube;
    string queNum = "";
    string[] files = { "q1.txt", "q2.txt", "q3.txt", "q4.txt", "q5.txt", "q6.txt" };
    int[] linenum = { 4, 3, 3, 3, 3, 3 };

    //Scene setting:
    Vector3 fnp_q1 = new Vector3(-1.12299991f, 2.18499875f, -0.0015f);
    Vector3 snp_q1 = new Vector3(-1.48100007f, 1.95699883f, -0.006f);
    Vector3 tfbn1p_q1 = new Vector3(-0.857f, 1.956999f, -0.26f);
    Vector3 tfbn2p_q1 = new Vector3(-1.057f, 1.836999f, -0.265f);

	// Use this for initialization
	void Start () {

       // locateObject(0);

        //loadQuestionByFileName(files[0],0);

	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void defineQuestion(int index)//called by button onclick
    {
        locateObject(index);

        loadQuestionByFileName(files[index],index);

    }

    void locateObject(int index)
    {
        GameObject n = GameObject.Find("n");

        if (n != null)
        {
            firstNum = n.transform.GetChild(0).gameObject;
            secondNum = n.transform.GetChild(1).gameObject;
            thirdNum = n.transform.GetChild(6).gameObject;
            queLine0 = n.transform.GetChild(2).gameObject;
            queLine1 = n.transform.GetChild(3).gameObject;
            queLine2 = n.transform.GetChild(4).gameObject;
            queLine3 = n.transform.GetChild(5).gameObject;
           // queLine4 = n.transform.GetChild(7).gameObject;
           // queLine5 = n.transform.GetChild(8).gameObject;

        }
        // locate the cubes
        firstCube = GameObject.FindGameObjectWithTag("cube1");
        secondCube = GameObject.FindGameObjectWithTag("cube2");
        thirdCube = GameObject.FindGameObjectWithTag("cube3");
        switch (index)
        {
            case 0:
                //thirdCube.SetActive(false);
               // queLine4.SetActive(false);
              //  queLine5.SetActive(false);

                firstNum.transform.position = fnp_q1;
                secondNum.transform.position = snp_q1;
                firstCube.transform.parent.transform.position = tfbn1p_q1;
                secondCube.transform.parent.transform.position = tfbn2p_q1;
                ; break;
        }
    }
    void loadQuestionByFileName(string name,int index)
    {
        // Example #1
        // Read the file as one string.
        string path = "Assets/Resources/"+name;
    
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        string line = "";
        if (linenum[index] == 4)
        {
            line = reader.ReadLine();
            Debug.Log(line);
            queLine0.GetComponent<TextMesh>().text = line;
            line = reader.ReadLine();
            Debug.Log(line);
            queLine1.GetComponent<TextMesh>().text = line;
            line = reader.ReadLine();
            Debug.Log(line);
            queLine2.GetComponent<TextMesh>().text = line;
            line = reader.ReadLine();
            Debug.Log(line);
            queLine3.GetComponent<TextMesh>().text = line;
            line = reader.ReadLine();
            Debug.Log(line);
            firstNum.GetComponent<TextMesh>().text = line;
            firstCube.transform.GetComponent<touchFB>().saveText = "  " + line;
           
          //  Vector3 np = new Vector3(firstNum.transform.position.x, firstNum.transform.position.y, firstNum.transform.position.z-1f);
           // firstCube.transform.parent.transform.position = np;
            // firstCube.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = "  " + line;
            line = reader.ReadLine();
            Debug.Log(line);
            secondNum.GetComponent<TextMesh>().text = line;
            secondCube.transform.GetComponent<touchFB>().saveText = "  " + line;
            //  secondCube.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = "  " + line;

        }

        reader.Close();

    }
    
}
