using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void StartMoving(Vector3 direction)
    {
        StartCoroutine(MoveOn(direction));
    }

    private IEnumerator MoveOn(Vector3 direction)
    {
        while (true)
        {
            transform.Translate(direction * 20 * Time.deltaTime);
            yield return null;
        }
    }
}
