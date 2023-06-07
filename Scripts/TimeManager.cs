using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private static TimeManager instance;
    private bool isPaused = false;
    private float previousTimeScale;

    public static TimeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TimeManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("TimeManager");
                    instance = obj.AddComponent<TimeManager>();
                }
            }
            return instance;
        }
    }

    public void TogglePause()
    {
        if (isPaused)
            ResumeTime();
        else
            PauseTime();
    }

    private void PauseTime()
    {
        isPaused = true;
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0f;
    }

    private void ResumeTime()
    {
        isPaused = false;
        Time.timeScale = previousTimeScale;
    }
}
