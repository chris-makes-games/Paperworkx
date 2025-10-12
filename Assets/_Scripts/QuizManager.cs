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
        finalExitButton.gameObject.SetActive(false);
    }

    void PopulateAllThemes()
    {
        for (int i = 0; i < 3; i++) { allThemePools.Add(new List<QuestionData>()); }

        // Theme 1 15 questions
        allThemePools[0].Add(new QuestionData { question = "Glory to ____?\n\nA. Arstotzka\nB. Kunstler\nC. King Bob", answer = "C" });
        allThemePools[0].Add(new QuestionData { question = "Is your current social credit score above 9999?\n\nA. True\nB. False", answer = "A" });
        allThemePools[0].Add(new QuestionData { question = "Who is the current president of Mars?\n\nA. Eli\nB. The AI overlords", answer = "B" });
        allThemePools[0].Add(new QuestionData { question = "Do you believe in equality and voting rights of Earth robots and Titan aliens?\n\nA. Yes\nB. No", answer = "A" });
        allThemePools[0].Add(new QuestionData { question = "Which country do you have a citizenship of?\n\nA. Arztotzka\nB. Terrarian Union", answer = "B" });
        allThemePools[0].Add(new QuestionData { question = "Are you enjoying this game?\n\nA.Yes\nB. No", answer = "A" });
        allThemePools[0].Add(new QuestionData { question = "Have you never thought about death?\n\nA. Yes\nB. No", answer = "B" });
        allThemePools[0].Add(new QuestionData { question = "Are you not a Wall-B model?\n\nA. Yes\nB. No", answer = "B" });
        allThemePools[0].Add(new QuestionData { question = "Is your current net worth in robux below 10,000?\n\nA. Hell yea\nB. No", answer = "B" });
        allThemePools[0].Add(new QuestionData { question = "Have you committed war crimes or acts of treason?\n\nA. Only war crimes\nB. neither\nC. Only acts of treason", answer = "B" });
        allThemePools[0].Add(new QuestionData { question = "When did world war 3 occur?\n\nA. 2067\nB. 2107\n", answer = "A" });
        allThemePools[0].Add(new QuestionData { question = "Do you support the immigration in crisis act of 2070?\n\nA.Yes\nB. No", answer = "A" });
        allThemePools[0].Add(new QuestionData { question = "Can long-term immigration caused by climate change and resource shortages ¡ª mixed with new diets, pollution exposure, and constant stress in a new country ¡ª actually change people¡¯s genes or biology faster than scientists usually think evolution works?\n\nA.True\nC. False", answer = "B" });
        allThemePools[0].Add(new QuestionData { question = "Did you ever experience attachment with a person or an object?\n\nA.Yes\nB. No", answer = "A" });
        allThemePools[0].Add(new QuestionData { question = "Will you join the martian army to defend your nation?\n\nA.Yes\nB. No", answer = "A" });

        // Theme 2 15 questions
        allThemePools[1].Add(new QuestionData { question = "Is Mars a chocolate or a Planet?\n\nA. Chocolate\nB. Planet\n", answer = "B" });
        allThemePools[1].Add(new QuestionData { question = "Q1: What is 10+10?", answer = "20" });
        allThemePools[1].Add(new QuestionData { question = "Q1: What is 10+10?", answer = "20" });
        allThemePools[1].Add(new QuestionData { question = "Q1: What is 10+10?", answer = "20" });
        allThemePools[1].Add(new QuestionData { question = "Q1: What is 10+10?", answer = "20" });
        allThemePools[1].Add(new QuestionData { question = "Q1: What is 10+10?", answer = "20" });
        allThemePools[1].Add(new QuestionData { question = "Q1: What is 10+10?", answer = "20" });
        allThemePools[1].Add(new QuestionData { question = "Q1: What is 10+10?", answer = "20" });
        allThemePools[1].Add(new QuestionData { question = "Q1: What is 10+10?", answer = "20" });
        allThemePools[1].Add(new QuestionData { question = "Q1: What is 10+10?", answer = "20" });
        allThemePools[1].Add(new QuestionData { question = "Q1: What is 10+10?", answer = "20" });
        allThemePools[1].Add(new QuestionData { question = "Q1: What is 10+10?", answer = "20" });
        allThemePools[1].Add(new QuestionData { question = "Q1: What is 10+10?", answer = "20" });
        allThemePools[1].Add(new QuestionData { question = "Q1: What is 10+10?", answer = "20" });
        allThemePools[1].Add(new QuestionData { question = "Q1: What is 10+10?", answer = "20" });

        // Theme 3 15 questions
        allThemePools[2].Add(new QuestionData { question = "Q1: What color is the sky?", answer = "blue" });
        allThemePools[2].Add(new QuestionData { question = "Q1: What color is the sky?", answer = "blue" });
        allThemePools[2].Add(new QuestionData { question = "Q1: What color is the sky?", answer = "blue" });
        allThemePools[2].Add(new QuestionData { question = "Q1: What color is the sky?", answer = "blue" });
        allThemePools[2].Add(new QuestionData { question = "Q1: What color is the sky?", answer = "blue" });
        allThemePools[2].Add(new QuestionData { question = "Q1: What color is the sky?", answer = "blue" });
        allThemePools[2].Add(new QuestionData { question = "Q1: What color is the sky?", answer = "blue" });
        allThemePools[2].Add(new QuestionData { question = "Q1: What color is the sky?", answer = "blue" });
        allThemePools[2].Add(new QuestionData { question = "Q1: What color is the sky?", answer = "blue" });
        allThemePools[2].Add(new QuestionData { question = "Q1: What color is the sky?", answer = "blue" });
        allThemePools[2].Add(new QuestionData { question = "Q1: What color is the sky?", answer = "blue" });
        allThemePools[2].Add(new QuestionData { question = "Q1: What color is the sky?", answer = "blue" });
        allThemePools[2].Add(new QuestionData { question = "Q1: What color is the sky?", answer = "blue" });
        allThemePools[2].Add(new QuestionData { question = "Q1: What color is the sky?", answer = "blue" });
        allThemePools[2].Add(new QuestionData { question = "Q1: What color is the sky?", answer = "blue" });
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
                feedbackText.text = "You have completed all the questions.";
                finalExitButton.gameObject.SetActive(true);
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