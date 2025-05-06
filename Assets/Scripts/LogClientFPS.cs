using System;
using System.IO;
using UnityEngine;

public class LogClientFPS : MonoBehaviour
{
    public float logInterval = 1f; // Log every second
    private float timer = 0f;
    private string filePath;
    public bool startLogging = false;
    string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");


    void Start()
    {
        // Path.Combine is used to safely combine directory and file path strings into one complete path.
        filePath = Path.Combine(Application.persistentDataPath, $"fps_log_{timestamp}.csv");
        File.WriteAllText(filePath, "Timestamp,FPS\n");
        Debug.Log(filePath);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (startLogging) 
        {
            timer += Time.deltaTime;

            if (timer >= logInterval)
            {
                float currentFPS = 1f / Time.deltaTime;
                string currentTimestamp = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string csvLine = $"{currentTimestamp},{currentFPS:F2}\n";
                File.AppendAllText(filePath, csvLine);
                Debug.Log("Inserting data to:" + filePath);
                timer = 0f;
            }
        }
    }
}
