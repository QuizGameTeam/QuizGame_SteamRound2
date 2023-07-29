using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System.IO;

[CreateAssetMenu(fileName = "QuestionConfig", menuName = "Question Config Data", order = 1)]
public class QuestionConfig : ScriptableObject
{
    private const string FILE_PATH = "JsonData/QuestionData";
    private TextAsset jsonData;
    private QuestionDataContainer dataContainer;
    private void Start()
    {

    }
    public enum Dificulty
    {
        Easy,
        Medium,
        Hard
    }

    [System.Serializable]
    public class QuestionData
    {
        public string QuestionNum;
        public string DetailQuestion;
        public Dificulty Dif;
        public List<string> Answer;
        public int answerIndex;
    }

    [System.Serializable]
    public class LevelData
    {
        public string LevelStage;
        public string Theme;
        public List<QuestionData> Questions;
    }

    public List<LevelData> LevelDatas;


    [Button("JSON READOUT")]
    public void ReadJsonData()
    {
        jsonData = Resources.Load<TextAsset>(FILE_PATH);

        dataContainer = JsonUtility.FromJson<QuestionDataContainer>(jsonData.text);
        // Truy cập và in thông tin các đối tượng trong mảng stage1
        foreach (Question question in dataContainer.stage1)
        {
            Debug.Log("Level: " + question.level);
            foreach (QuestionDataJSON questionDataJson in question.questiondata)
            {
                Debug.Log("Detail Question: " + questionDataJson.detailquestion);
                Debug.Log("Difficulty: " + questionDataJson.dif);
                Debug.Log("Question: " + questionDataJson.Q1);
                Debug.Log("Question: " + questionDataJson.Q2);
                Debug.Log("Question: " + questionDataJson.Q3);
                Debug.Log("Question: " + questionDataJson.Q4);
                Debug.Log("Question: " + questionDataJson.answer);
            }
        }
    }

    [Button("Fill Data")]
    public void FillDataIn()
    {
        LevelDatas = new List<LevelData>();

        jsonData = Resources.Load<TextAsset>(FILE_PATH);
        dataContainer = JsonUtility.FromJson<QuestionDataContainer>(jsonData.text);
        List<List<Question>> _questions = new List<List<Question>>()
        {
            dataContainer.stage1,
            dataContainer.stage2,
            dataContainer.stage3
        };
        foreach (var QuestionDats in _questions)
        {
            foreach (var stage in QuestionDats)
            {
                LevelData newLevelData = new LevelData
                {
                    LevelStage = stage.level,
                    Theme = stage.theme,
                    Questions = new List<QuestionData>()
                };

                foreach (var questionDataJson in stage.questiondata)
                {
                    QuestionData newQuestionData = new QuestionData
                    {
                        QuestionNum = questionDataJson.questionnum,
                        DetailQuestion = questionDataJson.detailquestion,
                        Dif = (Dificulty)System.Enum.Parse(typeof(Dificulty), questionDataJson.dif),
                        Answer = new List<string> { questionDataJson.Q1, questionDataJson.Q2, questionDataJson.Q3, questionDataJson.Q4 },
                        answerIndex = int.Parse(questionDataJson.answer)
                    };

                    newLevelData.Questions.Add(newQuestionData);

                    string fullInfo = "Level: " + stage.level +
                                    ", Theme: " + stage.theme +
                                    ", Question Number: " + questionDataJson.questionnum +
                                    ", Detail Question: " + questionDataJson.detailquestion +
                                    ", Difficulty: " + questionDataJson.dif +
                                    ", Question 1: " + questionDataJson.Q1 +
                                    ", Question 2: " + questionDataJson.Q2 +
                                    ", Question 3: " + questionDataJson.Q3 +
                                    ", Question 4: " + questionDataJson.Q4 +
                                    ", Answer: " + questionDataJson.answer;

                    Debug.Log(fullInfo);
                }

                LevelDatas.Add(newLevelData);
            }
        }
    }




}
// _________________________________________________JSON CLASSES_________________________________________________//
[System.Serializable]
public class Employee
{
    public string firstName;
    public string lastName;
}

[System.Serializable]
public class Answer
{
    public string key;
    public string value;
}

[System.Serializable]
public class QuestionDataJSON
{
    public string questionnum;
    public string detailquestion;
    public string dif; // Sửa thành Dificulty để sử dụng enum
    public string Q1;
    public string Q2;
    public string Q3;
    public string Q4;
    public string answer; // Sửa thành List<string> thay vì List<Answer>
}

[System.Serializable]
public class Question
{
    public string level;
    public string theme;
    public List<QuestionDataJSON> questiondata;
}

[System.Serializable]
public class QuestionDataContainer
{
    public List<Question> stage1;
    public List<Question> stage2;
    public List<Question> stage3;
}
