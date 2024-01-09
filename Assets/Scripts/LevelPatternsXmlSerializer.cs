using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace DefaultNamespace
{
    public class LevelPatternsXmlSerializer
    {
        private LevelPatterns _levelPatterns;
        private TextAsset _levelTextAsset;
        //public Levels Levels => _levels;

        public void ParseXml()
        {
            _levelTextAsset = Resources.Load<TextAsset>("XML/LevelPatterns");
            XmlSerializer serializer = new XmlSerializer(typeof(LevelPatterns));
            StringReader reader = new StringReader(_levelTextAsset.text);
            _levelPatterns = serializer.Deserialize(reader) as LevelPatterns;
        }

        public int[,] ParseToIntMap(int mapPatternIndex) => 
            _levelPatterns.LevelPatternses[mapPatternIndex].GetParsedToIntMapPattern();

        public LevelPattern GetCurrentLevelPattern(int mapPatternIndex) =>
            _levelPatterns.LevelPatternses[mapPatternIndex];
    }
    
    [XmlRoot(nameof(LevelPatterns))]
    public class LevelPatterns
    {
        [XmlElement(nameof(LevelPattern))] 
        public LevelPattern[] LevelPatternses;
    }

    public class LevelPattern
    {
        [XmlElement(nameof(RowData))] 
        public RowData[] RowDatas;

        [XmlAttribute("minAvailableSlots")] 
        public int MinAvailableSlots;
        [XmlAttribute("maxAvailableSlots")] 
        public int MaxAvailableSlots;

        public int[,] GetParsedToIntMapPattern()
        {
            int rowCount = RowDatas.Length;
            int columnCount = RowDatas[0].GetParsedToIntRow().Length;
            int[,] mapPattern = new int[rowCount,columnCount];

            for (int i = 0; i < rowCount; i++)
            {
                int[] currentRow = RowDatas[i].GetParsedToIntRow();
                for (int j = 0; j < columnCount; j++)
                {
                    mapPattern[i, j] = currentRow[j];
                }
            }

            return mapPattern;
        }
    }

    public class RowData
    {
        [XmlAttribute("row")] 
        public string Row;

        public int[] GetParsedToIntRow()
        {
            string[] splitted = Row.Split(" ");
            int[] row = new int[splitted.Length];

            for (int i = 0; i < row.Length; i++)
            {
                row[i] = int.Parse(splitted[i]);
            }

            return row;
        }
    }
}