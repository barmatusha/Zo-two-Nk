using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class question{
    public string m_Qtitle;
    public string m_Qanswer;
    public bool isCorrect;
    public question(string m_Qtitle, bool isCorrect, string m_Qanswer){
        this.m_Qtitle = m_Qtitle;
        this.isCorrect = isCorrect;
        this.m_Qanswer = m_Qanswer;
    }
}
public class quize{
    List<List<question>> LDifficulte;
    public quize(){
        LDifficulte= new List<List<question>>();
        string[] lines = File.ReadAllLines("QUIZ.pbquiz");
        for (int i = 0; i<lines.Length; i++){
            string[] line = lines[i].Split('|');
            if (line.Length > 2){
                int difftype = int.Parse(line[0]);
                string _question = line[1].Replace('$','\n');
                string _answer = line[2];
                bool _isCorrect = Convert.ToBoolean(int.Parse(line[3]));
                addQuest(new question(_question, _isCorrect, _answer), difftype);
            }
        }
    }
    public question randQuest(int difftype){
        if (LDifficulte[difftype-1].Count == 0){
            return null;
        }
        Random random = new Random();
        int ranVal = random.Next(0, LDifficulte[difftype-1].Count);
        question que = LDifficulte[difftype-1][ranVal];
        LDifficulte[difftype-1].RemoveAt(ranVal);
        return que;
    }
    public void addQuest(question newQuest, int difftype){
        if (LDifficulte.Count < difftype){
                for (int j = LDifficulte.Count; j<difftype; j++){
                    LDifficulte.Add(new List<question>());
                }
            }
        LDifficulte[difftype-1].Add(newQuest);
    }
    public int CountOfQue(int difftype){
        return LDifficulte[difftype-1].Count;
    }
}
