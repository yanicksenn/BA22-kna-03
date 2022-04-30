using System.IO;
using UnityEngine;

namespace Runtime.Presentation
{
    [CreateAssetMenu(fileName = "ExerciseSlide", menuName = "BA22/Slide/Create new exercise slide")]
    public class ExerciseSlide : TextSlide
    {
        [SerializeField, Space] 
        private TextAsset truthTableFile;
        public TextAsset TruthTableFile
        {
            get => truthTableFile;
            set => truthTableFile = value;
        }

        private int[,] truthTable = new int[16, 8];
        public int[,] TruthTable => truthTable;

        private void OnEnable()
        {
            if (TruthTableFile != null)
                ParseTruthTable();
        }

        private void ParseTruthTable()
        {
            var text = truthTableFile.text;
            using var sr = new StringReader(text);
            
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