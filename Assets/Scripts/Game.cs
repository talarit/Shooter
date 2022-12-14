using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField] private float _timeValue;
    [SerializeField] private Text _timerView;
    [SerializeField] private Text _timerView2;
    [SerializeField] private int _timeValue2;

    private float _timer = 0;
    private float _timer2 = 3f;
    public Vector3 center; 
    public Vector3 size; 
    public GameObject target;
    public GameObject Panel;
    public Menu _menu;
    public weapon _weapon;
    private bool st = false;
    private bool n = false;
  
    // Start is called before the first frame update
    private void Awake()
    {
        //время игры
        _timer = _timeValue;
        _timerView.text = $"{_timeValue:F1}";
        //время ожидания
        _timer2 = _timeValue2;
        _timerView2.text = $"{_timeValue2}";
        Panel.SetActive(true);

    }
    public void Spawn()
    {
        //появление мишени
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2)); 
        var a = Instantiate(target, pos, Quaternion.identity);
        StartCoroutine(WaitEnemyCoroutine(a));

    }
    IEnumerator WaitEnemyCoroutine(GameObject a)
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            if (a != null)
            {
                //уничтожение мишени через пять секунды
                Destroy(a, 5);
                if (_weapon.scoreVal > 0)
                {
                    _weapon.scoreVal--;
                }
            }
        }
    }
        IEnumerator WaitCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Spawn();
        }
    }




        // Update is called once per frame
    void Update()
    {
        Waiting();
        if (st) Timer();

    }
  

    void Timer()
    {
        //таймер
        _timer -= Time.deltaTime;
        _timerView.text = $"{_timer:F1}";
        if (_timer <= 0)
            _menu.Pause();
        else
            _menu.Resume();
   
    }


    public void Waiting()
    {
        //ожидание
        _timer2 -= Time.deltaTime;
        _timerView2.text = $"{_timer2}";
        if (_timer2 <= 0) { 
            st = true;
            Panel.SetActive(false);
            if(!n)
            {
                StartCoroutine(WaitCoroutine());
                n = true;
            }
        }

    }
}
