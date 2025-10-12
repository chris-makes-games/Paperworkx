using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public struct QuestionData
{
    public string question;
    public string answer;
}

public class QuizManager : MonoBehaviour
{
    public static int finalScore;

    [Header("UI")]
    public TextMeshProUGUI questionText;
    public TMP_InputField answerInput;
    public TextMeshProUGUI feedbackText;
    public Button saveButton;
    public Button submitButton;
    public Button nextQuestionButton;
    public Button finalExitButton;
    public Button[] tabButtons;

    [Header("QandASettings")]
    public int questionsPerTheme = 5;

    private List<List<QuestionData>> allThemePools = new List<List<QuestionData>>();
    private List<QuestionData> currentSessionQuestions = new List<QuestionData>();
    private int currentThemeIndex = 0;
    private int currentQuestionIndex = 0;
    private bool isAnswerSaved = false;
    private bool[] themesCompleted = new bool[3];
    private int correctAnswersCount = 0;

    void Start()
    {
        PopulateAllThemes();
        SwitchToTheme(0);
        UpdateTabStates();
    }

    void PopulateAllThemes()
    {
        for (int i = 0; i < 3; i++) { allThemePools.Add(new List<QuestionData>()); }

        // Theme 1 15 questions
        allThemePools[0].Add(new QuestionData { question = "Is your current intergalactic credit score above 9999?\n\nA. True\nB. False", answer = "A" });
        allThemePools[0].Add(new QuestionData { question = "Which country do you have a citizenship of?\n\nA. Polar Republic\nB. Terrarian Union", answer = "B" });
        allThemePools[0].Add(new QuestionData { question = "Is your current net worth below 10,000 in credits per solar rotation?\n\nA. Yes \nB. No", answer = "B" });
        allThemePools[0].Add(new QuestionData { question = "Have you committed any felonies or crimes against the current government?\n\nA. Yes \nB. no", answer = "B" });
        allThemePools[0].Add(new QuestionData { question = "Did you loose a place of residence in a climate change related disaster?\n\nA.Yes\nB. No", answer = "B" });
        allThemePools[0].Add(new QuestionData { question = "Will you join the martian army to defend your nation, as required by a G5 visa?\n\nA.Yes\nB. No", answer = "A" });

        // Theme 2 15 questions
        allThemePools[1].Add(new QuestionData { question = "Is Pluto considered a Planet?\n\nA. Yes\nB. No\n", answer = "B" });
        allThemePools[1].Add(new QuestionData { question = "What year did World War III occur? \n\nA. 2067 \nB. 2107", answer = "A" });
        allThemePools[1].Add(new QuestionData { question = "Who is the current president of Mars?\n\nA. Eli Moss \nB. Ronald Grump\nC. GrokX VII", answer = "A" });
        allThemePools[1].Add(new QuestionData { question = "Complete the first line to our planetary anthem: Glory to ____\n\nA. Astortskan\nB. Our Orange Skies\nC. Ares", answer = "C" });
        allThemePools[1].Add(new QuestionData { question = "What is the name of Mars' largest Moon?\n\nA.Phobos\nB.Deimos\nC.Thethes", answer = "A" });
        allThemePools[1].Add(new QuestionData { question = "Did the current President vote in support of the immigration in Crisis act of 2070?\n\nA.Yes?\nB. No", answer = "A" });
        

        // Theme 3 15 questions
        allThemePools[2].Add(new QuestionData { question = "Do you consent to a background check, which is mandatory to recieve a visa for Mars?\n\nA.Yes\n B. No", answer = "A" });
        allThemePools[2].Add(new QuestionData { question = "Do you consent to the monitoring of your digital footprint and habits?\n A.Yes \n B.No", answer = "A" });
        allThemePools[2].Add(new QuestionData { question = "Do you consent to your answers and likeness being used to train artificial intelligences? \n A.Yes \n B.No", answer = "A" });
        allThemePools[2].Add(new QuestionData { question = "Do you recognize that through recieving a visa, you forfeit your right to private medical records? \n A.Yes \n B.No", answer = "A" });
    }

    public void SwitchToTheme(int themeIndex)
    {
        currentThemeIndex = themeIndex;
        currentSessionQuestions = allThemePools[themeIndex]
            .OrderBy(q => System.Guid.NewGuid())
            .Take(questionsPerTheme)
            .ToList();
        currentQuestionIndex = 0;
        DisplayQuestion(currentQuestionIndex);
    }

    void DisplayQuestion(int index)
    {
        questionText.text = $"Question {index + 1}/{questionsPerTheme}: {currentSessionQuestions[index].question}";
        answerInput.text = "";
        feedbackText.text = "";
        nextQuestionButton.interactable = false;
        submitButton.interactable = true;
        saveButton.interactable = true;
    }

    public void CheckAnswer()
    {
        if (!isAnswerSaved)
        {
            feedbackText.text = "No answer detected!";
            feedbackText.color = Color.red;
            return;
        }

        if (answerInput.text == currentSessionQuestions[currentQuestionIndex].answer)
        {
            correctAnswersCount++;
        }

        nextQuestionButton.interactable = true;
        submitButton.interactable = false;
        saveButton.interactable = false;
        isAnswerSaved = false;
    }

    public void GoToNextQuestion()
    {
        currentQuestionIndex++;
        if (currentQuestionIndex >= currentSessionQuestions.Count)
        {
            themesCompleted[currentThemeIndex] = true;
            UpdateTabStates();
            feedbackText.text = $"Theme {currentThemeIndex + 1} is completed.";

            if (themesCompleted[0] && themesCompleted[1] && themesCompleted[2])
            {
                finalScore = correctAnswersCount;
                feedbackText.text = "Questions Complete. Your results are printing...";
            }
        }
        else
        {
            DisplayQuestion(currentQuestionIndex);
        }
    }

    void UpdateTabStates()
    {
        tabButtons[0].interactable = true;
        tabButtons[1].interactable = themesCompleted[0];
        tabButtons[2].interactable = themesCompleted[1];
    }

    public void OnSaveButtonPressed()
    {
        isAnswerSaved = true;
    }

    public void GoToMainScene()
    {
        SceneManager.LoadScene("main");
    }
}