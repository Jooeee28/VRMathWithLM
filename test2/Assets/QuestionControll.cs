using UnityEngine;
using System.IO;
using System.Collections;
using UnityEngine.SceneManagement;

public class QuestionControll : MonoBehaviour {

    GameObject queLine0,queLine1,queLine2,queLine3, queLine4, queLine5;
    GameObject firstNum, secondNum, thirdNum;
    GameObject firstCube, secondCube, thirdCube;
    GameObject firNumCan, secNumCan, thiNumCan;
    public string attach;

    string queNum = "";
    string[] files = { "q1.txt", "q2.txt", "q3.txt", "q4.txt", "q5.txt", "q6.txt" };

    //Scene setting:
    Vector3[] q1_setting = {
        new Vector3(-1.017933f,2.098011f,-0.31f),
        new Vector3(-1.389942f,1.881001f,-0.31f),
        new Vector3(-1.009f,2.097799f,-0.275f),
        new Vector3(-1.402f,1.884999f,-0.275f)};

    Vector3[] q2_setting =
    {
        new Vector3(-0.8619118f,2.098011f,-0.31f),
        new Vector3(0.007534027f,1.662998f,-0.31f),
        new Vector3(-0.8700001f,2.097799f,-0.275f),
        new Vector3(0.01100003f,1.654999f,-0.275f),
    };

    Vector3[] q3_setting =
    {
        new Vector3(-0.8619118f,2.098011f,-0.31f),
        new Vector3(-0.2740669f,1.860996f,-0.31f),
        new Vector3(-0.5944252f,1.666996f,-0.31f),
        new Vector3(-0.8700001f,2.097799f,-0.275f),
        new Vector3(-0.27f,1.866999f,-0.275f),
        new Vector3(-0.591f,1.660999f,-0.275f)
    };

    Vector3[] q4_setting =
    {
        new Vector3(-0.8998299f,2.092999f,-0.31f),
        new Vector3(-1.681919f,1.860996f,-0.31f),
        new Vector3(0.3757286f,1.868999f,-0.31f),
        new Vector3(-0.889f,2.096999f,-0.275f),
        new Vector3(-1.676f,1.866999f,-0.275f),
        new Vector3(0.379f,1.868999f,-0.275f)
    };

    Vector3[] q5_setting =
    {
        new Vector3(-0.08993149f,2.092999f,-0.31f),
        new Vector3(-0.5820274f,1.860996f,-0.31f),
        new Vector3(-0.4510689f,1.659f,-0.31f),
        new Vector3(-0.09999997f,2.096999f,-0.275f),
        new Vector3(-0.566f,1.866999f,-0.275f),
        new Vector3(-0.414f,1.652999f,-0.275f)
    };

    Vector3[] q6_setting =
    {
        new Vector3(0.1634026f,2.092999f,-0.31f),
        new Vector3(-1.778584f,1.860996f,-0.31f),
        new Vector3(-0.5846596f,1.659f,-0.31f),
        new Vector3(0.1530001f,2.096999f,-0.275f),
        new Vector3(-1.774f,1.866999f,-0.275f),
        new Vector3(-0.543f,1.652999f,-0.275f)
    };
  
	// Use this for initialization
	void Start () {


        //locateAll();
        locateAll();

        if (attach == "n")
        {
            emptyText();
        }
        //defineQuestion(5);
       // defineQuestion(4);
       // defineQuestion(3);
        //defineQuestion(2);
        //defineQuestion(1);
       // defineQuestion(0);
        //outPutNumsPosandCubePos();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void outPutNumsPosandCubePos()
    {
        string path = "Assets/Resources/pos.txt";
        StreamWriter writer = new StreamWriter(path, true);
        Debug.Log("firNumCan Pos:");
        writer.WriteLine("firNumCan Pos:");
        Debug.Log("(" + firNumCan.transform.position.x + "f," + firNumCan.transform.position.y + "f," + firNumCan.transform.position.z+"f)");
        writer.WriteLine("(" + firNumCan.transform.position.x + "f," + firNumCan.transform.position.y + "f," + firNumCan.transform.position.z + "f)");
        Debug.Log("secNumCan Pos:");
        writer.WriteLine("secNumCan Pos:");
        Debug.Log("(" + secNumCan.transform.position.x + "f," + secNumCan.transform.position.y + "f," + secNumCan.transform.position.z+"f)");
        writer.WriteLine("(" + secNumCan.transform.position.x + "f," + secNumCan.transform.position.y + "f," + secNumCan.transform.position.z + "f)");
        Debug.Log("thiNumcan Pos:");
        writer.WriteLine("thiNumcan Pos:");
        Debug.Log("(" + thiNumCan.transform.position.x + "f," + thiNumCan.transform.position.y + "f," + thiNumCan.transform.position.z + "f)");
        writer.WriteLine("(" + thiNumCan.transform.position.x + "f," + thiNumCan.transform.position.y + "f," + thiNumCan.transform.position.z + "f)");

        Debug.Log("firstCube Pos:");
        writer.WriteLine("firstCube Pos:");
        Debug.Log("(" + firstCube.transform.position.x + "f," + firstCube.transform.position.y + "f," + firstCube.transform.position.z+"f)");
        writer.WriteLine("(" + firstCube.transform.position.x + "f," + firstCube.transform.position.y + "f," + firstCube.transform.position.z + "f)");
        Debug.Log("secondCube Pos:");
        writer.WriteLine("secondCube Pos:");
        Debug.Log("(" + secondCube.transform.position.x + "f," + secondCube.transform.position.y + "f," + secondCube.transform.position.z + "f)");
        writer.WriteLine("(" + secondCube.transform.position.x + "f," + secondCube.transform.position.y + "f," + secondCube.transform.position.z + "f)");
        Debug.Log("thirdCube Pos:");
        writer.WriteLine("thirdCube Pos:");
        Debug.Log("(" + thirdCube.transform.position.x + "f," + thirdCube.transform.position.y + "f," + thirdCube.transform.position.z + "f)");
        writer.WriteLine("(" + thirdCube.transform.position.x + "f," + thirdCube.transform.position.y + "f," + thirdCube.transform.position.z + "f)");
        writer.Close();
    }

    public void defineQuestion(int index)//called by button onclick
    {

        //recover
        firNumCan.SetActive(true);
        secNumCan.SetActive(true);
        if (index > 1) thiNumCan.SetActive(true);

        locateObject(index);
        loadQuestionByFileName(files[index],index);

    }

    void locateAll()
    {

        GameObject n = GameObject.Find("n");

        if (n != null)
        {
            firNumCan = n.transform.GetChild(0).gameObject;
            secNumCan = n.transform.GetChild(1).gameObject;
            thiNumCan = n.transform.GetChild(2).gameObject;
            queLine0 = n.transform.GetChild(3).gameObject;
            queLine1 = n.transform.GetChild(4).gameObject;
            queLine2 = n.transform.GetChild(5).gameObject;
            queLine3 = n.transform.GetChild(6).gameObject;
            queLine4 = n.transform.GetChild(7).gameObject;
            queLine5 = n.transform.GetChild(8).gameObject;

        }

        // locate the cubes

        firstCube = GameObject.FindGameObjectWithTag("cube1");
        secondCube = GameObject.FindGameObjectWithTag("cube2");
        thirdCube = GameObject.FindGameObjectWithTag("cube3");
    }

    void emptyText()
    {
        firNumCan.SetActive(false);
        secNumCan.SetActive(false);
        thiNumCan.SetActive(false);
        queLine0.GetComponent<TextMesh>().text = "";
        queLine1.GetComponent<TextMesh>().text = "";
        queLine2.GetComponent<TextMesh>().text = "";
        queLine3.GetComponent<TextMesh>().text = "";
        queLine4.GetComponent<TextMesh>().text = "";
        queLine5.GetComponent<TextMesh>().text = "";

    }
    void locateObject(int index)
    {
        GameObject n = GameObject.Find("n");

        if (n != null)
        {
            firNumCan = n.transform.GetChild(0).gameObject;
            secNumCan = n.transform.GetChild(1).gameObject;
            thiNumCan = n.transform.GetChild(2).gameObject;
            queLine0 = n.transform.GetChild(3).gameObject;
            queLine1 = n.transform.GetChild(4).gameObject;
            queLine2 = n.transform.GetChild(5).gameObject;
            queLine3 = n.transform.GetChild(6).gameObject;
            queLine4 = n.transform.GetChild(7).gameObject;
            queLine5 = n.transform.GetChild(8).gameObject;


        }
        // locate the cubes
        firstCube = GameObject.FindGameObjectWithTag("cube1");
        secondCube = GameObject.FindGameObjectWithTag("cube2");
        thirdCube = GameObject.FindGameObjectWithTag("cube3");
        switch (index)
        {
            case 0:
                thiNumCan.SetActive(false);
                queLine4.SetActive(false);
                queLine5.SetActive(false);
                firNumCan.transform.position = q1_setting[0];
                secNumCan.transform.position = q1_setting[1];
                firstCube.transform.parent.transform.position = q1_setting[2];
                secondCube.transform.parent.transform.position = q1_setting[3];
                ; break;
            case 1:
                thiNumCan.SetActive(false);
                queLine4.SetActive(true);
                queLine5.SetActive(true);
                firNumCan.transform.position = q2_setting[0];
                secNumCan.transform.position = q2_setting[1];
                firstCube.transform.parent.transform.position = q2_setting[2];
                secondCube.transform.parent.transform.position = q2_setting[3];
                break;
            case 2:
                thiNumCan.SetActive(true);
                queLine4.SetActive(true);
                queLine5.SetActive(true);
                firNumCan.transform.position = q3_setting[0];
                secNumCan.transform.position = q3_setting[1];
                thiNumCan.transform.position = q3_setting[2];
                firstCube.transform.parent.transform.position = q3_setting[3];
                secondCube.transform.parent.transform.position = q3_setting[4];
                thirdCube.transform.parent.transform.position = q3_setting[5];
                break;
            case 3:
                thiNumCan.SetActive(true);
                queLine4.SetActive(true);
                queLine5.SetActive(false);
                firNumCan.transform.position = q4_setting[0];
                secNumCan.transform.position = q4_setting[1];
                thiNumCan.transform.position = q4_setting[2];
                firstCube.transform.parent.transform.position = q4_setting[3];
                secondCube.transform.parent.transform.position = q4_setting[4];
                thirdCube.transform.parent.transform.position = q4_setting[5];
                break;
            case 4:
                thiNumCan.SetActive(true);
                queLine4.SetActive(false);
                queLine5.SetActive(false);
                firNumCan.transform.position = q5_setting[0];
                secNumCan.transform.position = q5_setting[1];
                thiNumCan.transform.position = q5_setting[2];
                firstCube.transform.parent.transform.position = q5_setting[3];
                secondCube.transform.parent.transform.position = q5_setting[4];
                thirdCube.transform.parent.transform.position = q5_setting[5];
                break;
            case 5:
                thiNumCan.SetActive(true);
                queLine4.SetActive(true);
                queLine5.SetActive(false);
                firNumCan.transform.position = q6_setting[0];
                secNumCan.transform.position = q6_setting[1];
                thiNumCan.transform.position = q6_setting[2];
                firstCube.transform.parent.transform.position = q6_setting[3];
                secondCube.transform.parent.transform.position = q6_setting[4];
                thirdCube.transform.parent.transform.position = q6_setting[5];
                break;

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
        switch (index)
        {
            case 0:
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
                if (firNumCan) firNumCan.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0)
                      .GetComponent<UnityEngine.UI.Text>().text = line;
                if (firstCube) firstCube.transform.GetComponent<touchFB>().saveText = "  " + line;
                line = reader.ReadLine();
                Debug.Log(line);
                if (secNumCan) secNumCan.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0)
                       .GetComponent<UnityEngine.UI.Text>().text = line;
                if (secondCube) secondCube.transform.GetComponent<touchFB>().saveText = "  " + line;
                break;

            case 1:
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
                queLine4.GetComponent<TextMesh>().text = line;
                line = reader.ReadLine();
                Debug.Log(line);
                queLine5.GetComponent<TextMesh>().text = line;
                line = reader.ReadLine();
                Debug.Log(line);
                if (firNumCan) firNumCan.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0)
                      .GetComponent<UnityEngine.UI.Text>().text = line;
                if (firstCube) firstCube.transform.GetComponent<touchFB>().saveText = "  " + line;
                line = reader.ReadLine();
                Debug.Log(line);
                if (secNumCan) secNumCan.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0)
                       .GetComponent<UnityEngine.UI.Text>().text = line;
                if (secondCube) secondCube.transform.GetComponent<touchFB>().saveText = "  " + line;
                break;
            case 2:
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
                queLine4.GetComponent<TextMesh>().text = line;
                line = reader.ReadLine();
                Debug.Log(line);
                queLine5.GetComponent<TextMesh>().text = line;
                line = reader.ReadLine();
                Debug.Log(line);
                if (firNumCan) firNumCan.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0)
                      .GetComponent<UnityEngine.UI.Text>().text = line;
                if (firstCube) firstCube.transform.GetComponent<touchFB>().saveText = "  " + line;
                line = reader.ReadLine();
                Debug.Log(line);
                if (secNumCan) secNumCan.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0)
                       .GetComponent<UnityEngine.UI.Text>().text = line;
                if (secondCube) secondCube.transform.GetComponent<touchFB>().saveText = "  " + line;
                line = reader.ReadLine();
                Debug.Log(line);
                if (thiNumCan) thiNumCan.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0)
                       .GetComponent<UnityEngine.UI.Text>().text = line;
                if (thirdCube) thirdCube.transform.GetComponent<touchFB>().saveText = "  " + line;
                break;
            case 3:
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
                queLine4.GetComponent<TextMesh>().text = line;
                line = reader.ReadLine();
                Debug.Log(line);
                if (firNumCan) firNumCan.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0)
                      .GetComponent<UnityEngine.UI.Text>().text = line;
                if (firstCube) firstCube.transform.GetComponent<touchFB>().saveText = "  " + line;
                line = reader.ReadLine();
                Debug.Log(line);
                if (secNumCan) secNumCan.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0)
                       .GetComponent<UnityEngine.UI.Text>().text = line;
                if (secondCube) secondCube.transform.GetComponent<touchFB>().saveText = "  " + line;
                line = reader.ReadLine();
                Debug.Log(line);
                if (thiNumCan) thiNumCan.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0)
                       .GetComponent<UnityEngine.UI.Text>().text = line;
                if (thirdCube) thirdCube.transform.GetComponent<touchFB>().saveText = "  " + line;
                break;
            case 4:
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
                if (firNumCan) firNumCan.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0)
                      .GetComponent<UnityEngine.UI.Text>().text = line;
                if (firstCube) firstCube.transform.GetComponent<touchFB>().saveText = "  " + line;
                line = reader.ReadLine();
                Debug.Log(line);
                if (secNumCan) secNumCan.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0)
                       .GetComponent<UnityEngine.UI.Text>().text = line;
                if (secondCube) secondCube.transform.GetComponent<touchFB>().saveText = "  " + line;
                line = reader.ReadLine();
                Debug.Log(line);
                if (thiNumCan) thiNumCan.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0)
                       .GetComponent<UnityEngine.UI.Text>().text = line;
                if (thirdCube) thirdCube.transform.GetComponent<touchFB>().saveText = "  " + line;
                break;
            case 5:
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
                queLine4.GetComponent<TextMesh>().text = line;
                line = reader.ReadLine();
                Debug.Log(line);
                if (firNumCan) firNumCan.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0)
                      .GetComponent<UnityEngine.UI.Text>().text = line;
                if (firstCube) firstCube.transform.GetComponent<touchFB>().saveText = "  " + line;
                line = reader.ReadLine();
                Debug.Log(line);
                if (secNumCan) secNumCan.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0)
                       .GetComponent<UnityEngine.UI.Text>().text = line;
                if (secondCube) secondCube.transform.GetComponent<touchFB>().saveText = "  " + line;
                line = reader.ReadLine();
                Debug.Log(line);
                if (thiNumCan) thiNumCan.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0)
                       .GetComponent<UnityEngine.UI.Text>().text = line;
                if (thirdCube) thirdCube.transform.GetComponent<touchFB>().saveText = "  " + line;
                break;

        }

        reader.Close();

    }

    public void cleanAllTexts()//deactive all texts
    {
        

    }

    public void activateByContext(int id)
    {
        if (firNumCan) firNumCan.SetActive(true);
        if (secNumCan) secNumCan.SetActive(true);
        //if (thiNumCan) thiNumCan.SetActive(true);
        if (queLine0) queLine0.SetActive(true);
        if (queLine1) queLine1.SetActive(true);
        if (queLine2) queLine2.SetActive(true);
        if (queLine3) queLine3.SetActive(true);

        if (firstCube) firstCube.SetActive(true);
        if (secondCube) secondCube.SetActive(true);
        //if (thirdCube) thirdCube.SetActive(true);
        switch (id)
        {
            case 0:

                ; break;
        }
    }
    
}
