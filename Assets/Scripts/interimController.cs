using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class interimController : MonoBehaviour
{
    public GameObject trialNumber;
    public GameObject userChoiceNumber;
    public Text headTrackingPlaceholder, usernamePlaceholder;
    public subjectData currentSubject;
    int actualAnswer;
    public void Start()
    {
        actualAnswer = PlayerPrefs.GetInt("CorrectPath");
        Debug.Log("The Correct Path is "+ actualAnswer);
        usernamePlaceholder.text = subjectData.subjectName;
        headTrackingPlaceholder.text = subjectData.isHeadTrackingEnabled.ToString();
    }
    public void goNextScene()
    {
        currentSubject.trialNo = trialNumber.GetComponent<Text>().text;
        currentSubject.userAnswer = userChoiceNumber.GetComponent<Text>().text;
        currentSubject.actualAnswer = actualAnswer;
        Debug.Log("Current Trial No : " + currentSubject.trialNo);
        Debug.Log("User Choice is : " + currentSubject.userAnswer);
        Debug.Log("User Name is " + subjectData.subjectName);
        Debug.Log("User HT Enabled is " + subjectData.isHeadTrackingEnabled);
        Debug.Log("User Additional Info is " + subjectData.additionalDetails);
        jsonandstore();
        SceneManager.LoadScene(1);
    }

    // Poorly coded, use the previous function with parameters
    public void saveAndQuit()
    {
        currentSubject.trialNo = trialNumber.GetComponent<Text>().text;
        currentSubject.userAnswer = userChoiceNumber.GetComponent<Text>().text;
        currentSubject.actualAnswer = actualAnswer;
        Debug.Log("Current Trial No : " + currentSubject.trialNo);
        Debug.Log("User Choice is : " + currentSubject.userAnswer);
        Debug.Log("User Name is " + subjectData.subjectName);
        Debug.Log("User HT Enabled is " + subjectData.isHeadTrackingEnabled);
        Debug.Log("User Additional Info is " + subjectData.additionalDetails);
        jsonandstore();
        Debug.Log("Application has been quit");
        Application.Quit();
    }
    public void jsonandstore()
    {
        string trialDataJson = JsonUtility.ToJson(currentSubject);
        string filePath = subjectData.subjectName + "_" + currentSubject.trialNo + "_" + ".json";
        Debug.Log("JSON string is " + trialDataJson);
        Debug.Log("Saving the file in " + subjectData.subjectTrialsDirPath);
        Debug.Log("File Name is " + filePath);
        System.IO.File.WriteAllText(Path.Combine(subjectData.subjectTrialsDirPath, filePath), trialDataJson);
    }
    public void QuitGame()
    {
        Debug.Log("Application has been quit");
        Application.Quit();
    }
}
