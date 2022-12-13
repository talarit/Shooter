using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weapon : MonoBehaviour
{
    public float firerate = 1f;
    public AudioClip shooter;
    public AudioSource audioSource;
    public Camera camera;
    public float range = 15f;
    public Text score;
    public int scoreVal=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Awake()
    {
        score.text = $"{scoreVal}";
    }
    void Update()
    {
        score.text = $"{scoreVal}";
        if (Input.GetButtonDown("Fire1"))
        {
            Shooting();
        }
    }

    void Shooting()
    {
        //סענוכüבא
        RaycastHit hit;
        audioSource.PlayOneShot(shooter);
        if (Physics.Raycast(camera.transform.position,camera.transform.forward,out hit,range))
        {
            if (hit.transform.gameObject.CompareTag("Target"))
            {
                Destroy(hit.transform.gameObject);
                scoreVal++;
            }
        }
    }
}
