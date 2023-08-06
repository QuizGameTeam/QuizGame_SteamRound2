using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

using section;

namespace quiz
{
    [Serializable]

    
    public class QuestionData
    {
        public string question;
        public string answerA;
        public string answerB;
        public string answerC;
        public string answerD;
        public string correctAnswer;
    }

    
    public class QuizGame : MonoBehaviour
    {
        public gameManager gamemanager;

        [SerializeField] private TextMeshProUGUI m_TxtQuestion;
        [SerializeField] private TextMeshProUGUI m_TxtAnswerA;
        [SerializeField] private TextMeshProUGUI m_TxtAnswerB;
        [SerializeField] private TextMeshProUGUI m_TxtAnswerC;
        [SerializeField] private TextMeshProUGUI m_TxtAnswerD;

        [SerializeField] private Image m_ImgAnswerA;
        [SerializeField] private Image m_ImgAnswerB;
        [SerializeField] private Image m_ImgAnswerC;
        [SerializeField] private Image m_ImgAnswerD;

        [SerializeField] private AudioSource m_AudioSource;
        [SerializeField] private AudioClip m_SfxWrongAnswer;
        [SerializeField] private AudioClip m_SfxCorrectAnswer;

        //[SerializeField] private QuestionData[] m_QuestionData;
        [SerializeField] private QuestionContent[] m_QuestionData;

        private int m_QuestionIndex;
        private GameState m_GameState;
        private int m_Live = 1;

        // Start is called before the first frame update
        void Start()
        {
            m_QuestionIndex = 0;
            InitQuestion(0);
        }

        // Update is called once per frame
        void Update()
        {

        }
        bool click = false;
        bool traLoiDung = false;
        public void BtnAnswer_Pressed(string pSelectedAnswer)
        {
            traLoiDung = false;
            if (!click)
            {
                
                click = true;
                if (m_QuestionData[m_QuestionIndex].correctAnswer == pSelectedAnswer)
                {
                    traLoiDung = true;
                    m_AudioSource.PlayOneShot(m_SfxCorrectAnswer);
                    Debug.Log("Cau tra loi chinh xac");
                }
                else
                {
                    m_Live--;
                    // if (m_Live == 0)
                    // {
                    //     gamemanager.SetGameState(GameState.OverQuiz);
                    //     m_AudioSource.Stop();
                    // }
                    m_AudioSource.PlayOneShot(m_SfxWrongAnswer);
                    traLoiDung = false;
                    Debug.Log("Ban da tra loi sai");
                }

                switch (m_QuestionData[m_QuestionIndex].correctAnswer)
                {
                    case "a":
                        m_ImgAnswerA.color = !traLoiDung ? Color.green : Color.red;
                        break;
                    case "b":
                        m_ImgAnswerB.color = !traLoiDung ? Color.green : Color.red;
                        break;
                    case "c":
                        m_ImgAnswerC.color = !traLoiDung ? Color.green : Color.red;
                        break;
                    case "d":
                        m_ImgAnswerD.color = !traLoiDung ? Color.green : Color.red;
                        break;
                }

                switch (pSelectedAnswer)
                {
                    case "a":
                        m_ImgAnswerA.color = traLoiDung ? Color.green : Color.red;
                        break;
                    case "b":
                        m_ImgAnswerB.color = traLoiDung ? Color.green : Color.red;
                        break;
                    case "c":
                        m_ImgAnswerC.color = traLoiDung ? Color.green : Color.red;
                        break;
                    case "d":
                        m_ImgAnswerD.color = traLoiDung ? Color.green : Color.red;
                        break;
                }
                // if (m_QuestionIndex >= m_QuestionData.Length - 1)
                // {
                //     if (traLoiDung || m_Live > 0 )
                //     {
                //         gamemanager.SetGameState(GameState.WinQuiz);
                //         return;
                //     }
                //     // else 
                //     // {
                //     //     gamemanager.SetGameState(GameState.OverQuiz);
                //     //     return;
                //     // }
                // } 
                // else Invoke("NextQuestion", 3f);
                if (m_Live > 0)
                {
                    if (traLoiDung)
                    {
                        if (m_QuestionIndex >= m_QuestionData.Length - 1)
                        {
                            gamemanager.SetGameState(GameState.WinQuiz);
                        }
                        else Invoke("NextQuestion", 3f);
                    }
                    else Invoke("NextQuestion", 3f);
                }
                else 
                {
                    gamemanager.SetGameState(GameState.OverQuiz);
                    m_AudioSource.Stop();
                }
            }

            
        }

        private void NextQuestion()
        {
            m_QuestionIndex++;
            InitQuestion(m_QuestionIndex);
            traLoiDung = false;
            click = false;
        }

        private void InitQuestion(int pIndex)
        {
            if (pIndex < 0 || pIndex >= m_QuestionData.Length)
                return;

            m_ImgAnswerA.color = Color.white;
            m_ImgAnswerB.color = Color.white;
            m_ImgAnswerC.color = Color.white;
            m_ImgAnswerD.color = Color.white;
        
            m_TxtQuestion.text = m_QuestionData[pIndex].question;
            m_TxtAnswerA.text = "A: " + m_QuestionData[pIndex].answerA;
            m_TxtAnswerB.text = "B: " + m_QuestionData[pIndex].answerB;
            m_TxtAnswerC.text = "C: " + m_QuestionData[pIndex].answerC;
            m_TxtAnswerD.text = "D: " + m_QuestionData[pIndex].answerD;
        }

        public void BtnQues_Pressed()
        {
            m_Live = 1;
            gamemanager.SetGameState(GameState.Quiz);
            InitQuestion(0);
            m_QuestionIndex = 0;
            m_AudioSource.Stop();
            click = false;
            // m_AudioSource.clip = m_MusicMainTheme;
            // m_AudioSource.Play();
        }

    }
}
