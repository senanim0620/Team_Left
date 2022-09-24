using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Opening : MonoBehaviour
{
    public Canvas option_canvas;
    public Canvas control_canvas;
    // Start is called before the first frame update
    void Start()
    {
        option_canvas.enabled = false;
        control_canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScene()
    {
        SceneManager.LoadScene(1);
    }

    public void option()
    {
        option_canvas.enabled = true;
    }

    public void optionclose()
    {
        option_canvas.enabled = false;
    }

    public void control()
    {
        control_canvas.enabled = true;
    }

    public void controlclose()
    {
        control_canvas.enabled = false;
    }
}

