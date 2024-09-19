using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Size
{
    public float width;
    public float height;

    public Size(float width, float height)
    {
        this.width = width;
        this.height = height;
    }

}

public class FollowCamera : MonoBehaviour
{
    Transform target;
    [SerializeField] BoxCollider2D background;
    [SerializeField] GameObject wall;

    public float xlength;
    public float ylength;

    public bool onShake;

    Size camSize;
    Size backSize;

    void Start()
    {
        Camera cam = GetComponent<Camera>();
        float ratio = Screen.width / (float)Screen.height;
        camSize = new Size(cam.orthographicSize * ratio, cam.orthographicSize);
        float sizeX = background.size.x;
        float sizeY = background.size.y;
        backSize = new Size(sizeX, sizeY);

        wall.transform.position = new Vector3(camSize.width * (xlength + 1), wall.transform.position.y, 0f);
    }

    void Update()
    {
        if(target == null)
        {
            target = PlayerMove.Instance.transform ?? null;
            return;
        }

        if (onShake) 
        {
            return;
        }
             
        Movement();
    }

    void Movement()
    {
        //float limitX = backSize.width - 2 * camSize.width;
        //float limitY = backSize.height - 2 * camSize.height;

        float limitX = camSize.width * xlength;
        float limitY = camSize.height * ylength;

        float pivotX = background.transform.position.x;
        float pivotY = background.transform.position.y;

        Vector3 pos = target.position + new Vector3(0, 0, -10);
        pos.x = Mathf.Clamp(pos.x, 0f, pivotX + limitX);
        pos.y = Mathf.Clamp(pos.y, pivotY - limitY, 0f);

        transform.position = pos;
    }
}
