using UnityEngine;

public class DynThornController : MonoBehaviour
{

    [SerializeField] private Transform posA, posB;
    [SerializeField] private float speed;

    private Vector3 targetPos;
    void Start()
    {
        targetPos = posB.position;
    }

    void Update()
    {
        //  khoang cach tu vat the den vi tri A < 0.05 => doi vi tri can den la B
        if (Vector2.Distance(transform.position, posA.position) < 0.05f)
        {
            targetPos = posB.position;
        }

        //  khoang cach tu vat the den vi tri B < 0.05 => doi vi tri can den la A
        if (Vector2.Distance(transform.position, posB.position) < 0.05f)
        {
            targetPos = posA.position;
        }

        // ham di chuyen tu vi tri hien tai toi vi tri can den
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}
