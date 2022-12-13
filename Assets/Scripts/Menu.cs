using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Menu : MonoBehaviour
{
  
    public GameObject MenuUi;
    public Camera camera;
    public Text text;
    public weapon _weapon;


    private void Awake()
    {
        Resume();
    }


    public  void Pause()
    {
        //меню игры
        MenuUi.SetActive(true);
        Time.timeScale = 0f;
        var objs = GameObject.FindGameObjectsWithTag("Target");
        for (int i = 0; i < objs.Length; i++)
            Destroy(objs[i]);
        var t =camera.transform.GetComponent<FirstPersonLook>();
        t.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        text.text = $"{_weapon.scoreVal}";
    }


    public void Resume()
    {
        //запуск уровня
        MenuUi.SetActive(false);
        Time.timeScale = 1f;
        var t = camera.transform.GetComponent<FirstPersonLook>();
        t.enabled = true;
        Cursor.visible = false;
       
    }

}
