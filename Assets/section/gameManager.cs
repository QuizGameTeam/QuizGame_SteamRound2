
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEngine.Random;

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
        Ques,
        Credit,
        Learn,
        GameWin,
        Quiz,
        OverQuiz,
        WinQuiz,
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
        [SerializeField] private AudioClip ThemeAudio;
        [SerializeField] private AudioClip PlayerAudio;


        [SerializeField] private GameObject vt_HomePanel, vt_GamePanel,vt_GamoverPanel, vt_CreditPanel, vt_Learn, vt_Win, vt_QuesPanel, vt_Quiz, vt_GameOverQuiz,vt_GameWinQuiz;


        //[SerializeField] private QuestionData[] questionData;
        [SerializeField] public QuestionScriptableData[] questionData;
        
        private int QuestionIndex;
        private GameState vt_GameState;
        private HeartCount HeartCount;
        private Respawn Respawn;
        public GameObject Player;
        private Collectible Collectible;
        private ScoreCount ScoreCount;
        public GameObject[] coins;

        public int MyScore;

        public int randomIndex;
            
        void Start()
        {
            Audio.clip = ThemeAudio;
            Audio.Play();

            randomques();
            
            coins = GameObject.FindGameObjectsWithTag("Coin");
            Debug.Log(coins.Length);
            HeartCount = FindObjectOfType<HeartCount>();
            Collectible = FindObjectOfType<Collectible>();
            Respawn = FindObjectOfType<Respawn>();
            ScoreCount = FindObjectOfType<ScoreCount>();
            Player = GameObject.FindWithTag("Player");
            SetGameState(GameState.Home);
            

            QuestionIndex = randomIndex;
            InitQuestion(randomIndex);
            
            //quescontent.GetQuesQuizz(0).ansA;
        }

        public void randomques()
        {
            randomIndex = Range(0, questionData.Length);
            QuestionIndex = randomIndex;
            InitQuestion(randomIndex);


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
            vt_HomePanel.SetActive(vt_GameState == GameState.Home);
            vt_GamePanel.SetActive(vt_GameState == GameState.Gameplay);
            vt_QuesPanel.SetActive(vt_GameState == GameState.Ques);
            vt_Quiz.SetActive(vt_GameState == GameState.Quiz);
            vt_GamoverPanel.SetActive(vt_GameState == GameState.Gameover);
            vt_CreditPanel.SetActive(vt_GameState == GameState.Credit);
            vt_Learn.SetActive(vt_GameState == GameState.Learn);
            vt_Win.SetActive(vt_GameState == GameState.GameWin);
            vt_GameOverQuiz.SetActive(vt_GameState == GameState.OverQuiz);
            vt_GameWinQuiz.SetActive(vt_GameState == GameState.WinQuiz);

            //vt_GameoverPanel.SetActive(vt_GameState == GameState.Gameover);

        }

        bool flag = false;
        bool click = false;

        void Update()
        {
            if (HeartCount.currentHealth <= 0)
            { 
                GameOver_fi();
                HeartCount.ResetHealth();
            } 
        }
        public void Ans_pressed(string SelectAns)
        {
            if (!click)
            {
                click = true;
                flag = false;
                string ans = questionData[QuestionIndex].correctAns; 
                if (ans == SelectAns)
                {
                    flag = true;
                    Audio.PlayOneShot(CorectAns);
                }
                else
                {
                    Audio.PlayOneShot(WrongAns);
                    HeartCount.TakeDamage(1);
                    
                }
                if (HeartCount.currentHealth > 0)
                {
                    // ContinuePlay();
                    Invoke("ContinuePlay" , 3);
                } 
                
                // Show answer
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
            }
        }
        public void GameWin_fi()
        {
            MyScore = ScoreCount.Score;
            SetGameState(GameState.GameWin);
            ScoreCount.Score = 0;
        }

        public void GameOver_fi()
        {
            MyScore = ScoreCount.Score;
            SetGameState(GameState.Gameover);
            ScoreCount.Score = 0;
        }

        // private void ChangeQuiz()
        // {
        //     QuestionIndex++;
        //     InitQuestion(QuestionIndex);
        //     flag = false;
        // }

        public void BTnPlay_Pressed()
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            foreach (GameObject coin in coins)
            {
                coin.SetActive(true);
            }
            SetGameState(GameState.Gameplay);
            InitQuestion(randomIndex);
            Audio.clip = PlayerAudio;
            Audio.Play();
            // Collectible.ShowCollectible();
            MyScore = 0;
            Respawn.respawnPoint = Respawn.resetPoint;
            
        }

        public void ContinuePlay()
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Audio.clip = PlayerAudio;
            Audio.Play();
            SetGameState(GameState.Gameplay);
            InitQuestion(randomIndex);
        }


        public void Ques_Pressed()
        {
            Player.transform.SetParent(null);
            // Player.GetComponent<Respawn>().RespawnNow();
            Ques_Pressed_2();
        }

        
        public void Ques_Pressed_2()
        {
            SetGameState(GameState.Ques);
            InitQuestion(randomIndex);
            flag = false;
            click = false;
        }
        
        public void BtnHome_Pressed()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // QuestionIndex = randomIndex;
            // SetGameState(GameState.Home);
            // MyScore = 0;
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