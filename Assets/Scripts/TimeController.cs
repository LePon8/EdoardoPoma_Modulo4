using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    float timer;
    [SerializeField] TextMeshProUGUI timeUI;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        UpdateTimer(timer);
        ResetTimer();
    }

    public void UpdateTimer(float time)
    {
        timeUI.text = Mathf.FloorToInt(time).ToString();
    }

    public void ResetTimer()
    {
        if(timer == 24)
        {
            timer = 0;
            timeUI.text = "0";
        }
    }

}
