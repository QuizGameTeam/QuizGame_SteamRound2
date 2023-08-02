using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace section
{
    [CreateAssetMenu(fileName = "QuestionScriptableData", menuName = "test_game_quizz/QuestionScriptableData", order = 0)]
    public class QuestionScriptableData : ScriptableObject
    {
        public string question;
        public string ansA;
        public string ansB;
        public string ansC;
        public string ansD;
        public string correctAns;
    }
}
