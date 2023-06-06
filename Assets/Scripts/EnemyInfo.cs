using UnityEngine;

namespace root
{
    [CreateAssetMenu(menuName = "Tools/EnemyInfo", fileName = "EnemyInfo")]
    public class EnemyInfo : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public GameObject Prefab { get; private set; }
        

    }
}
