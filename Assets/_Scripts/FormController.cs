using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FormController : MonoBehaviour
{
    public TMP_InputField answerInput;
    public Button submitButton;
    public TMP_Text feedbackText;

    private string correctAnswer = "6";

    void Start()
    {
        submitButton.onClick.AddListener(CheckAnswer);
    }

    void CheckAnswer()
    {
        string playerAnswer = answerInput.text;

        if (playerAnswer == correctAnswer)
        {
          
            feedbackText.text = "Verification PASSED! \nHuman identity confirmed";
            feedbackText.color = new Color32(20, 150, 50, 255);
        }
        else
        {
            
            feedbackText.text = "WRONG answer! \nNon-human detected.";
            feedbackText.color = Color.red;
        }
    }
}