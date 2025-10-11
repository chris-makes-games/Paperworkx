using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FormController : MonoBehaviour
{
    public Button finalExitButton;
    public TMP_InputField[] answerInputs;
    public TMP_Text feedbackText;
    public GameObject[] pages;
    public Button[] tabButtons;

    private bool[] puzzlesSolved = new bool[3];
    private bool isAnswerSaved = false;
    private string[] correctAnswers = new string[3];
    private int currentPageIndex = 0;

    void Start()
    {
        correctAnswers[0] = "6";
        correctAnswers[1] = "2";
        correctAnswers[2] = "200";

        finalExitButton.gameObject.SetActive(false);

        SwitchToPage(0);
        UpdateTabStates();
    }

    public void SwitchToPage(int pageIndex)
    {
        feedbackText.text = "";
        currentPageIndex = pageIndex;
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == pageIndex);
        }
    }

    void UpdateTabStates()
    {
        tabButtons[0].interactable = true;
        tabButtons[1].interactable = puzzlesSolved[0];
        tabButtons[2].interactable = puzzlesSolved[1];
    }

    public void CheckAnswer()
    {
        if (!isAnswerSaved)
        {
            feedbackText.text = "NO ANSWER DETECTED!";
            feedbackText.color = Color.red;
            return;
        }

        string playerAnswer = answerInputs[currentPageIndex].text;

        if (playerAnswer == correctAnswers[currentPageIndex])
        {
            feedbackText.text = "Verification PASSED! \nHuman identity confirmed";
            feedbackText.color = new Color32(15, 80, 40, 255);
            puzzlesSolved[currentPageIndex] = true;
            UpdateTabStates();

            if (currentPageIndex == 2)
            {
                finalExitButton.gameObject.SetActive(true);
            }
        }
        else
        {
            feedbackText.text = "WRONG answer! \nNon-human detected.";
            feedbackText.color = Color.red;
        }

        isAnswerSaved = false;
    }

    public void GoToMainScene()
    {
        SceneManager.LoadScene("main");
    }

    public void OnSaveButtonPressed()
    {
        isAnswerSaved = true;
    }
}