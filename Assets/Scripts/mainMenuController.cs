using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
public class mainMenuController : MonoBehaviour
{
    public GameObject username, addnInfo;
    public Toggle headTrackingToggle;
    public void LoadGameScene()
    {
        subjectData.subjectName = username.GetComponent<Text>().text;
        subjectData.additionalDetails = addnInfo.GetComponent<Text>().text;
        subjectData.isHeadTrackingEnabled = headTrackingToggle.isOn; 
        Debug.Log("Is Head Tracking Enabled : " + subjectData.isHeadTrackingEnabled);
        Debug.Log("Subject Name is " + subjectData.subjectName + " additional Details is " + subjectData.additionalDetails);
        Debug.Log("Loading the Game Scene");
        createDir();
        SceneManager.LoadScene(1);
    }
    public void createDir()
    {
        var rootFolderDir = "./subjectTrials/";
        subjectData.subjectTrialsDirPath = rootFolderDir + subjectData.subjectName + "_" + subjectData.isHeadTrackingEnabled.ToString() + "_" + System.DateTime.Now.ToString("dd/MMMM/yyy");
        Directory.CreateDirectory(subjectData.subjectTrialsDirPath);
        Debug.Log("New Folder created for the subject  "+ subjectData.subjectTrialsDirPath);
        if (subjectData.additionalDetails != null)
            storeAddnData(subjectData.subjectTrialsDirPath);
    }
    public void storeAddnData(string subjectPath)
    {
        string filePath = Path.Combine(subjectPath,"additionalData.txt");
        Debug.Log("File for additional data is "+filePath);
        StreamWriter writer = new StreamWriter(filePath, true);
        writer.WriteLine(subjectData.additionalDetails.ToString());
        writer.Close();
    }
}
