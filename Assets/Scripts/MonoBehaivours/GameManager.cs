using UnityEngine;
using UnityEngine.UI;


namespace MonoBehaivours
{
    public class GameManager : MonoBehaviour
    {
        
        public Slider Complication;

        public int GetCurrentComplication()
        {
            return (int)Complication.value;
        }
    }
}
