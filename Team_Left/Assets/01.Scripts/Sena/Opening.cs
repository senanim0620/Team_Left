using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Opening : MonoBehaviour
{
    public static Opening instance;

    public GameObject option_canvas;
    public GameObject control_canvas;
    public DontDestory dontDestory;

    public GameObject ison;

    public bool isonbool;// 여기에 노래 onof가 들어감

    private void Awake()
    {
        if (instance == null)
           instance = this ;
        else
        {
            Debug.Log("싱글톤 두개!");
            Destroy(gameObject);
        }
    }


    void Start()
    {
        option_canvas.SetActive(false);
        control_canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        isonbool = ison.GetComponent<Toggle>().isOn;
        dontDestory.ison = ison.GetComponent<Toggle>().isOn;

    }

    public void changeScene()
    {
        SceneManager.LoadScene(1);
    }

    public void option()
    {
        option_canvas.SetActive(true);
    }

    public void optionclose()
    {
        option_canvas.SetActive(false);
    }

    public void control()
    {
        control_canvas.SetActive(true);
       
    }

    public void controlclose()
    {
        control_canvas.SetActive(false);
     
    }

    public void Quit()
    {
        Application.Quit();
    }
}

