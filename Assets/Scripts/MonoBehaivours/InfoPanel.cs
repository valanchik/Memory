using System;
using UnityEngine;
using TMPro;
namespace MonoBehaivours
{
    public class InfoPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI TimeText;
        [SerializeField] private TextMeshProUGUI StepsText;
        private string TimePrefix = "Время\n";
        private string StepsPrefix = "Ходы\n";
        public void SetTime(TimeSpan time)
        {
            TimeText.text = TimePrefix + time.ToString(@"mm\:ss");
        }

        public void SetSteps(int steps)
        {
            StepsText.text = StepsPrefix + steps.ToString();
        }
        
    }
}

