using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

namespace section
{
    [Serializable]

    public class QuestionData
    {
        public string question;
        public string ansA;
        public string ansB;
        public string ansC;
        public string ansD;
        public string correctAns;
    }
    public enum GameState
    {
        Home,
        Gameplay,
        Gameover
    }

    public class gameManager: MonoBehaviour
    {
    // Start is called before the
        [SerializeField] private TextMeshProUGUI txtQuestion;
        [SerializeField] private TextMeshProUGUI txtAnswerA;
        [SerializeField] private TextMeshProUGUI txtAnswerB;
        [SerializeField] private TextMeshProUGUI txtAnswerC;
        [SerializeField] private TextMeshProUGUI txtAnswerD;
        [SerializeField] private Image  ImgAnsA;
        [SerializeField] private Image  ImgAnsB;
        [SerializeField] private Image  ImgAnsC;
        [SerializeField] private Image  ImgAnsD;


        //[SerializeField] private GameObject vt_HomePanel, vt_GamePanel, vt_GameoverPanel;
        
        [SerializeField] private GameObject vt_HomePanel, vt_GamePanel, vt_GamoverPanel;


        //[SerializeField] private QuestionData[] questionData;
        [SerializeField] private QuestionScriptableData[] questionData;
        


        private int QuestionIndex;
        private GameState vt_GameState;
        private int vt_Live = 3;
        
        void Start()
        {
            SetGameState(GameState.Home);
            QuestionIndex = 0;
            InitQuestion(0);    

        }

    // Update is called once per frame
        void Update()
        {
            
        }
        public void Ans_pressed(string SelectAns)
        {
            bool flag = false;

            if (questionData[QuestionIndex].correctAns == SelectAns)
            {
                flag = true;
                Debug.Log("10d gioi gioi");
            }
            else
            {
                vt_Live--;
                if (vt_Live == 0) 
                {
                    SetGameState(GameState.Gameover);
                }
                flag = false;
                Debug.Log("Ngouuuu");
            }

            switch(SelectAns)
            {
                case "a":
                    ImgAnsA.color = flag ? Color.green : Color.red;
                    break;
                case "b":
                    ImgAnsB.color = flag ? Color.green : Color.red;
                    break;
                case "c":
                    ImgAnsC.color = flag ? Color.green : Color.red;
                    break;
                case "d":
                    ImgAnsD.color = flag ? Color.green : Color.red;
                    break;
            }
            if (flag)
            {
                if (QuestionIndex >= questionData.Length)
                {
                    Debug.Log("Xin chuc mung! Ban da chien thang");
                    return;
                    
                }
                QuestionIndex++;
                InitQuestion(QuestionIndex);
            }
        }

        private void InitQuestion(int vt)
        {
            if (vt < 0 || vt >= questionData.Length) 
                return;

            ImgAnsA.color = Color.white;
            ImgAnsB.color = Color.white;
            ImgAnsC.color = Color.white;
            ImgAnsD.color = Color.white;
            txtQuestion.text = questionData[vt].question;
            txtAnswerA.text ="A: " + questionData[vt].ansA;
            txtAnswerB.text ="B: " + questionData[vt].ansB;
            txtAnswerC.text ="C: " + questionData[vt].ansC;
            txtAnswerD.text ="D: " + questionData[vt].ansD;
        }

        public void SetGameState(GameState state)
        {
            vt_GameState = state;
            vt_Live = 3;
            vt_HomePanel.SetActive(vt_GameState == GameState.Home);
            vt_GamePanel.SetActive(vt_GameState == GameState.Gameplay);
            vt_GamoverPanel.SetActive(vt_GameState == GameState.Gameover);
            //vt_GameoverPanel.SetActive(vt_GameState == GameState.Gameover);
        }

        public void BTnPlay_Pressed()
        {
            vt_Live = 3;
            SetGameState(GameState.Gameplay);
            InitQuestion(0);
            
        }

        public void BtnHome_Pressed()
        {
            SetGameState(GameState.Home);
        }
    }
}
