using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text timerText1; 
    public Text timerText2;
    public float startTime; 
    public float endTime; 
    private bool isRunning = false; 
    public Collider StartPanel;
    public Collider FinishPanel;
    private float currentTime; 

    void Start()
    {
       
        currentTime = startTime;
        timerText.text = currentTime.ToString("F2");
    }

    void Update()
    {
        if (isRunning)
        {
            currentTime += Time.deltaTime;
            timerText.text = currentTime.ToString("F2");
            timerText1.text = currentTime.ToString("F2");
            timerText2.text = currentTime.ToString("F2"); 
        }
    }

    void OnTriggerExit(Collider StartPanel)
    {
        if (StartPanel.gameObject.CompareTag("Start"))
        {
            isRunning = true;
            StartPanel.GetComponent<Collider>().isTrigger = false;
        }
        
    }
    void OnTriggerEnter(Collider FinishPanel)
    {
        if (FinishPanel.gameObject.CompareTag("Finish"))
        {
            isRunning = false;
            endTime = currentTime;
        }
    }
}
