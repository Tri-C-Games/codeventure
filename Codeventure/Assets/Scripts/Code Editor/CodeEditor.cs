using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class CodeEditor : MonoBehaviour
{
    public static bool gamePaused = false;

    public GameObject codeEditor;
    public GameObject inputField;
    public GameObject lineNumbers;

    private TMP_InputField inputFieldTMP;
    private TMP_InputField lineNumbersTMP;
    //private TMP_Text lineNumbersTMP;

    public float minPlayerDistToEditableObject = 1.5f;

    // Start is called before the first frame update
    private void Start()
    {
        inputFieldTMP = inputField.GetComponent<TMP_InputField>();
        lineNumbersTMP = lineNumbers.GetComponent<TMP_InputField>();//lineNumbers.GetComponent<TMP_Text>();
    }

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

    public void OnValueChanged()
    {
        int numberOfLines = Regex.Split(inputFieldTMP.text, "\n").Count();
        lineNumbersTMP.text = "";
        for (int i = 1; i <= numberOfLines; i++)
        {
            lineNumbersTMP.text += i + "\n";
        }
    }
}