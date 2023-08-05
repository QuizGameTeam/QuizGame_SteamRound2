using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace section
{
    [CreateAssetMenu(fileName = "Question", menuName = "quizz/Question", order = 0)]
    public class QuestionContent : ScriptableObject
    {
        public List<QuesQuizz> listques = new List<QuesQuizz>();

        public QuesQuizz GetQuesQuizz(int id)
        {
            return listques.Find(x=>x.id == id);
        }
        
    }

    [Serializable]
    public class QuesQuizz
    {
        public string question;
        public string ansA;
        public string ansB;
        public string ansC;
        public string ansD;
        public string correctAns;
        public int id;
        
    }

}

