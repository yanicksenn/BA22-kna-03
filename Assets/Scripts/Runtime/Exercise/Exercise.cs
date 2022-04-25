using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "Exercise",menuName = "BA22/Create exercise")]
public class Exercise : ScriptableObject
{
    [SerializeField] private int exerciseNumber;
    public int ExerciseNumber => exerciseNumber;
    
    [SerializeField] private string exerciseName;
    public string ExerciseName => exerciseName;
    
    [SerializeField,TextArea] private string exerciseDescription;
    public string ExerciseDescription => exerciseDescription;

    [SerializeField, Space] private TextAsset truthTableFile;

    private int[,] truthTable = new int[16, 8];
    public int[,] TruthTable => truthTable;

    private void OnEnable()
    {
        ParseTruthTable();
    }

    private void ParseTruthTable()
    {
        var text = truthTableFile.text;
        using (var sr = new StringReader(text)) {
            string line;
            var row = 0;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.StartsWith("#")) continue;
                
                var column = 0;
                foreach (var cell in line.Split(';'))
                {
                    truthTable[row, column] = int.Parse(cell.Trim());
                    column++;
                }

                row++;
            }
        }
        
    }
}
