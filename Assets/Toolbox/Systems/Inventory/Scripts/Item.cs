using System.IO;
using UnityEditor;
using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
    public class Item : ScriptableObject
    {
        [SerializeField] new string name;
        [SerializeField] string description;
        [SerializeField] Sprite icon;
        [SerializeField] Category category;

        public string Name => name;
        public string Description => description;
        public Sprite Icon => icon;
        public Category Category => category;

        private void Reset()
        {
#if UNITY_EDITOR
            name = Path.GetFileNameWithoutExtension(AssetDatabase.GetAssetPath(this));
#endif
        }
    }
}