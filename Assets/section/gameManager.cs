
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
        Credit,
        Learn,
        GameWin,
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
        [SerializeField] private AudioSource Audio;
        [SerializeField] private AudioClip CorectAns;
        [SerializeField] private AudioClip WrongAns;

        [SerializeField] private GameObject vt_HomePanel, vt_GamePanel, vt_GamoverPanel, vt_CreditPanel, vt_Learn, vt_Win;


        //[SerializeField] private QuestionData[] questionData;
        [SerializeField] private QuestionScriptableData[] questionData;
        
        private int QuestionIndex;
        private GameState vt_GameState;
        void Start()
        {
            SetGameState(GameState.Home);
            //SetGameState(GameState.Credit);
            QuestionIndex = 0;
            InitQuestion(0);    
        }

        bool flag = false;

        public void Ans_pressed(string SelectAns)
        {
            string ans = questionData[QuestionIndex].correctAns; 
            if (ans == SelectAns)
            {
                flag = true;
                Audio.PlayOneShot(CorectAns);
                Debug.Log("10d gioi gioi");
            }
            else
            {
                flag = false;
                Debug.Log("Ngouuuu");
                Audio.PlayOneShot(WrongAns);
            }
            
            switch(ans)
            {
                case "a":
                    ImgAnsA.color = !flag ? Color.green : Color.red;
                    break;
                case "b":
                    ImgAnsB.color = !flag ? Color.green : Color.red;
                    break;
                case "c":
                    ImgAnsC.color = !flag ? Color.green : Color.red;
                    break;
                case "d":
                    ImgAnsD.color = !flag ? Color.green : Color.red;
                    break;
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

            if (flag) Invoke("GameWin" , 4);
            else Invoke("GameOver" , 4);
                // if (QuestionIndex == questionData.Length - 1)
                // {
                //     Debug.Log("Xin chuc mung! Ban da chien thang");
                //     SetGameState(GameState.GameWin);
                //     //return;
                    
                // }
            // Invoke("ChangeQuiz" , 5);
        }
        private void GameWin()
        {
            SetGameState(GameState.GameWin);
        }

        private void GameOver()
        {
            SetGameState(GameState.Gameover);
        }



        // private void ChangeQuiz()
        // {
        //     QuestionIndex++;
        //     InitQuestion(QuestionIndex);
        //     flag = false;
        // }

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
            vt_HomePanel.SetActive(vt_GameState == GameState.Home);
            vt_GamePanel.SetActive(vt_GameState == GameState.Gameplay);
            vt_GamoverPanel.SetActive(vt_GameState == GameState.Gameover);
            vt_CreditPanel.SetActive(vt_GameState == GameState.Credit);
            vt_Learn.SetActive(vt_GameState == GameState.Learn);
            vt_Win.SetActive(vt_GameState == GameState.GameWin);
            //vt_GameoverPanel.SetActive(vt_GameState == GameState.Gameover);
        }

        public void BTnPlay_Pressed()
        {
            SetGameState(GameState.Gameplay);
            InitQuestion(0);
            
        }

        public void BtnHome_Pressed()
        {
            QuestionIndex = 0;
            SetGameState(GameState.Home);
        }
        public void BtnCredit_pressed()
        {
            SetGameState(GameState.Credit);
        }

        public void BtnLearn_pressed()
        {
            SetGameState(GameState.Learn);
        }

        public void OpenNet1()
        {
            Application.OpenURL("https://miro.com/app/board/uXjVO2n0xkg=/");
        }
        public void OpenNet2()
        {
            Application.OpenURL("https://miro.com/app/board/uXjVO2QL4po=/");
        }
        
        public void Phishing()
        {
            Application.OpenURL("https://funix.edu.vn/chia-se-kien-thuc/8-kieu-tan-cong-lua-dao-phishing-attack-ban-nen-biet/");
        }
        public void privacy()
        {
            Application.OpenURL("https://www.auditboard.com/blog/privacy-vs-security/");
        }
    }
}
