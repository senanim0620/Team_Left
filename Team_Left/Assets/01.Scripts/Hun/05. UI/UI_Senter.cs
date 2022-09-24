using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class UI_Senter : MonoBehaviour
{
    public Text SenterText;

    private void Start()
    {
        SenterText.gameObject.SetActive(false);
    }

    public void _SetSenterText(string String, float Value)
    {
        SenterText.text = String;
        SenterText.gameObject.SetActive(true);
        
        StopAllCoroutines();
        StartCoroutine(TextFade(Value));
    }

    private IEnumerator TextFade(float Value)
    {
        for (float i = 1; i >= 0; i -= Value * Time.deltaTime)
        {
            Color col = SenterText.color;
            col.a = i;
            SenterText.color = col;
            
            yield return null;
        }
        
        SenterText.gameObject.SetActive(false);
    }

}
