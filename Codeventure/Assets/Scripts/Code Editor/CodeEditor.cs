using UnityEngine;

public class CodeEditor : MonoBehaviour
{
    public static bool gamePaused = false;

    public GameObject codeEditor;

    public float minPlayerDistToEditableObject = 1.5f;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (gamePaused)
            {
                Resume();
            }
            else if (IsPlayerNearEditableObject())
            {
                Pause();
            }
            else
            {
                // TODO: Notify player that they aren't near an editable object.
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

    private bool IsPlayerNearEditableObject()
    {
        GameObject player = GameObject.Find("Player");
        GameObject[] editableObjects = GameObject.FindGameObjectsWithTag("Editable");
        foreach (GameObject editableObject in editableObjects)
        {
            float dist = Vector3.Distance(editableObject.transform.position, player.transform.position);
            if (dist <= minPlayerDistToEditableObject)
            {
                return true;
            }
        }
        return false;
    }
}