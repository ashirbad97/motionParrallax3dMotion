using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class interpolation : MonoBehaviour
{
    [SerializeField] private Transform targetBall;
    [SerializeField] private Transform[] pathpoints = new Transform[20];
    [SerializeField] GameObject plane;
    GameObject[] labelpoints;
    int num;
    [SerializeField] float speed = 1;
    private float interpolateAmount;
    private void Start()
    {
        //Enable or disable head tracking
        //Disables the Mesh Renderer of the GameObject to make it invisible in runtime
        plane.GetComponentInChildren<Renderer>().enabled = false;
        //Disabling the MeshRenderer of the path points to make them invisible
        foreach (Transform pathpoint in pathpoints)
        {
            pathpoint.GetComponentInChildren<Renderer>().enabled = false;
        }
        //Finding all number labels with tag numbers
        labelpoints = GameObject.FindGameObjectsWithTag("numbers");
        //Iterating through each of the labelpoints and disabling them
        foreach (GameObject labelpoint in labelpoints)
        {
            labelpoint.SetActive(false);
        }
        //Finds a random number inthe range of 0-19 to select a random target point
        num = Random.Range(0, 19);
        Debug.Log(num);
        PlayerPrefs.SetInt("CorrectPath", num);
    }
    private void FixedUpdate()
    {
        targetBall.position = Vector3.MoveTowards(targetBall.position, pathpoints[num].position, speed);
        if (targetBall.position == pathpoints[num].position)
        {
            ReachedTarget();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Loading Interim Menu");
            SceneManager.LoadScene(2);
        }
    }
    private void ReachedTarget()
    {
        //After ball arrived at target display the nnumbers again
        foreach (GameObject labelpoint in labelpoints)
        {
            labelpoint.SetActive(true);
        }
        //Hide the ball after it has reached the target
        targetBall.GetComponentInChildren<Renderer>().enabled = false;
    }
}
