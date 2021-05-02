using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private float shootingPeriod = 0.5f;

    private float timer;

    private void Start()
    {
        timer = shootingPeriod;
    }

    private void Update()
    {
        timer += Time.deltaTime;    
    }

    private void OnMouseDown()
    {
        if (timer > shootingPeriod)
        {
            Shoot();
            timer = 0f;
        }
    }

    private void Shoot()
    {
        GameObject color = Instantiate(bullet, shootingPoint.position, Quaternion.identity);
        color.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;
        color.GetComponent<Bullet>().StartMoving(transform.forward);

        GameManager.instance.StartCoroutine(GameManager.instance.Check());
    }
}
