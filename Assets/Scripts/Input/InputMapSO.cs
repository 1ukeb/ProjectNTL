using UnityEngine;

namespace NTL.Input
{
    [CreateAssetMenu(menuName = "NTL/Input/Input Map")]
    public class InputMapSO : ScriptableObject
    {
        public string valids;

        /// <summary>
        /// Returns true if the char is a valid input
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public bool IsValidInput(char character)
        {
            foreach (char c in valids)
                if (c == character)
                    return true;

            return false;
        }
    }
}
