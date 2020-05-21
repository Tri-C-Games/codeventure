using UnityEngine;

public class CodeEditor : MonoBehaviour
{
    public static bool gamePaused = false;

    public GameObject codeEditor;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        codeEditor.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    private void Resume()
    {
        codeEditor.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }
}