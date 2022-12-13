using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{


public void StartButton()
    {
        //кнопка заново
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
}
