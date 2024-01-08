using UnityEngine;

namespace DefaultNamespace
{
    public class MapTile : MonoBehaviour
    {
        private Slot _slot;

        public void Initialize(Slot slot)
        {
            _slot = slot;
            _slot.Initialize();
        }
    }
}