using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    
    /// <summary>
    /// sorry for poor doc i'm just tring to gewt this done as fast as posible i hope this is the standerd
    /// way of doing a timer in unity and c# if not i'm sorry -- willow
    /// </summary>
    
        [Tooltip("put how long in seconds")]
        public float TimerDuration;
    
       [SerializeField] private TextMeshProUGUI timerText;
        
        private float timer;

        private static Timer Instance { get; set; }

        private void Awake()
        {
            if (Instance != null && Instance != this) {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }
        
        
        void Start()
        {
            timer = TimerDuration;
        }

        void Update()
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                UpdateTimerDisplay(timer);
            }
            else
                Flash();
        }

        private void ResetTimer()
        {
            timer = TimerDuration;
            UpdateTimerDisplay(timer);
        }

        private void UpdateTimerDisplay(float time)
        {
            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);
            string secondsString;
            if (seconds < 10)
            {
                secondsString = "0" + seconds.ToString();
            }
            else
            {
                secondsString = seconds.ToString();
            }
            
            string currentTimer = string.Format("{0:D2}:{1:D2}", minutes.ToString(), secondsString);
            timerText.text = currentTimer;

        }

        private void Flash()
        {
            if(timer > 0)
            {
                timer = 0;
                UpdateTimerDisplay(timer);
                
            }
        }
        
        
        
}
