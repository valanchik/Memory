using System;
using UnityEngine;
using TMPro;
namespace MonoBehaivours
{
    public class InfoPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI TimeText;
        [SerializeField] private TextMeshProUGUI StepsText;
        [SerializeField] private TextMeshProUGUI PointsText;
        private string TimePrefix = "Время\n";
        private string StepsPrefix = "Ходы\n";
        private string PointsPrefix = "Очки\n";
        public void SetTime(TimeSpan time)
        {
            TimeText.text = TimePrefix + time.ToString(@"mm\:ss");
        }

        public void SetSteps(int steps)
        {
            StepsText.text = StepsPrefix + steps.ToString();
        }

        public void SetPoints(int points)
        {
            PointsText.text = PointsPrefix + points.ToString();
        }
        public void Start()
        {
                

        }
    }
}

