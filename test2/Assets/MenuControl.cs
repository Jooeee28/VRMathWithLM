using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour {
    
    public void ShowMainMenu()
    {
        Debug.Log("Show Menu");
        GameObject can2 = GameObject.Find("Canvas2");
        GameObject can1 = null;
        if (can2 != null)
        {
            can1 = can2.transform.parent.GetChild(0).gameObject;
            if (can1 != null)
            {
                can1.SetActive(true);
            }
            can2.SetActive(false);
        }

    }
    public void CloseMainMenu()
    {
        Debug.Log("Close Menu");
        GameObject can1 = GameObject.Find("Canvas1");
        GameObject can2 = null;
        if (can1 != null)
        {
            can2 = can1.transform.parent.GetChild(1).gameObject;
            if (can2 != null)
            {
                can2.SetActive(true);
            }
            can1.SetActive(false);
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StopRecord()
    {
       //VRCapture.VRCapture.Instance.StopCapture();

        /*
        if (VRCapture.VRReplay.Instance.LoadReplay())
        {
            VRCapture.VRReplay.Instance.StartReplay();
        }
        */

        GameObject.Find("Menus").transform.GetChild(2).gameObject.SetActive(false);
    }

    public void StartRecord()
    {
       // VRCapture.VRReplay.Instance.StartRecord();
       // VRCapture.VRCapture.Instance.StartCapture();
        GameObject.Find("Menus").transform.GetChild(2).gameObject.SetActive(true);
    }
}
