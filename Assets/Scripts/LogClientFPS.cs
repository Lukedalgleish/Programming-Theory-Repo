using System.IO;
using UnityEngine;

public class LogClientFPS : MonoBehaviour
{
    public float logInterval = 1f; // Log every second
    private float timer = 0f;
    private string filePath;
    public bool startLogging = false;

    // Start is called before the first frame update
    void Start()
    {
        // Path.Combine is used to safely combine directory and file path strings into one complete path.
        // 
        filePath = Path.Combine(Application.persistentDataPath, "fps_log.csv");

        // Write header if the file doesn't exist
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "Timestamp,FPS\n");
        }
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
                string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string csvLine = $"{timestamp},{currentFPS:F2}\n";
                File.AppendAllText(filePath, csvLine);
                Debug.Log("Inserting data to:" + filePath);
                timer = 0f;
            }
        }
    }
}
