using System.Collections;
using System.Collections.Generic;
using System.IO;

public class TerminalString{
    public string TerminalLine; 
    public TerminalString(string TerminalLine){
        this.TerminalLine = TerminalLine;
    }
}
public class TerminalStringManager {
    List<List<TerminalString>> LTerminalStrings;
    public TerminalStringManager(){
        LTerminalStrings= new List<List<TerminalString>>();
        string[] lines = File.ReadAllLines("Terminal");
        for (int i = 0; i<lines.Length; i++){
            string[] line = lines[i].Split('|');
            if (line.Length > 1){
                int difftype = int.Parse(line[0]);
                string TerminalLine = line[1].Replace('$', '\n');
                addTerminalString(new TerminalString(TerminalLine), difftype);
            }
        }
    }
    public void addTerminalString(TerminalString TS, int difftype){
        if (LTerminalStrings.Count < difftype){
                for (int j = LTerminalStrings.Count; j<difftype; j++){
                    LTerminalStrings.Add(new List<TerminalString>());
                }
            }
        LTerminalStrings[difftype-1].Add(TS);
    }
    public TerminalString GetTerminalString(int difftype, int index){
        return LTerminalStrings[difftype-1][index];
    }
    public int GetCountOfLines(int difftype){
        return LTerminalStrings[difftype-1].Count;
    }
}
