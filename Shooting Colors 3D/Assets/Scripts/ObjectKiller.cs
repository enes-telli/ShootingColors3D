using UnityEngine;

public class ObjectKiller : MonoBehaviour
{
    private void OnEnable()
    {
        Destroy(gameObject, 1f);
    }
}
