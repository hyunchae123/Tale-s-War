using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffBullet : MonoBehaviour
{
    [SerializeField] GameObject DebuffPadPrefab;

    Vector2 dir;
    Vector3 destination;

    private void Start()
    {
        destination = transform.position + (Vector3)dir.normalized * 10f;
    }
    void Update()
    {
        if (PlayerMove.Instance.OnPause)
            return;

        Movement();

        if (transform.position == destination)
        {
            Instantiate(DebuffPadPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void Movement()
    {
        float angle = Mathf.Atan2(this.dir.y, this.dir.x) * Mathf.Rad2Deg;
        Quaternion angleToQua = Quaternion.AngleAxis((angle + 90), Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, angleToQua, 0.5f);
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * 20.0f);
    }

    public void Directing(Vector2 dir)
    {
        this.dir = dir;
    }
}
