using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [Header("彈弓上的兩個點")]
    public Transform LinePoint1, LinePoint2;
    public bool IsLine = true;
    [Range(0, 1.5f)]
    public float DragRadius;
    public float ForcePower;

    public GameMain m_GameMain;
    Vector2 DragCenterPos;
    Vector2 OffsetFromCenter;

    bool isCanDrag;
    Transform m_Transform;
    LineRenderer LineRenderer1, LineRenderer2;
    Rigidbody2D m_Rigidbody2D;
    // Use this for initialization
    void Start()
    {

        LineRenderer1 = LinePoint1.GetComponent<LineRenderer>();
        LineRenderer2 = LinePoint2.GetComponent<LineRenderer>();
        LineRenderer1.sortingLayerName = "Line";
        LineRenderer2.sortingLayerName = "Line";
        DragCenterPos = (LinePoint1.position + LinePoint2.position) / 2;
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Transform = GetComponent<Transform>();
        Init();
    }

    // Update is called once per frame
    void Update()
    {

        if (IsLine)
        {
            DrawLine();
        }
    }
    public void Init()
    {
        isCanDrag = true;
        m_Rigidbody2D.isKinematic = true;
        IsLine = true;

    }
    void DrawLine()
    {
        LineRenderer1.SetPosition(0, LinePoint1.position);
        LineRenderer1.SetPosition(1, m_Transform.position);
        LineRenderer2.SetPosition(0, LinePoint2.position);
        LineRenderer2.SetPosition(1, m_Transform.position);



    }
    public void Shoot(Vector2 force)
    {
        isCanDrag = false;
        IsLine = false;
        LineRenderer1.SetPosition(1, LinePoint1.position);
        LineRenderer2.SetPosition(1, LinePoint2.position);
        m_Rigidbody2D.isKinematic = false;
        float power = ForcePower / DragRadius * force.magnitude;
        print(force + "" + power);
        m_Rigidbody2D.AddForce(force.normalized * power, ForceMode2D.Force);
    }


    private void OnMouseDrag()
    {
        if (isCanDrag)
        {
            Vector2 mouse = Input.mousePosition;
            Vector2 newpos = Camera.main.ScreenToWorldPoint(mouse);
            OffsetFromCenter = DragCenterPos - newpos;

            if (OffsetFromCenter.magnitude > DragRadius)
            {
                Vector2 offsetz = DragCenterPos - new Vector2(m_Transform.position.x, m_Transform.position.y);
                Shoot(offsetz);
            }
            else
            {
                transform.position = newpos;
            }
        }

    }
    private void OnMouseUp()
    {
        if (isCanDrag)
        {
            Vector2 offset = DragCenterPos - new Vector2(m_Transform.position.x, m_Transform.position.y);
            Shoot(offset);
        }
    }
    void DestroySelf()
    {
        if (m_GameMain.GetStoneNum() > 0)
        {
            m_GameMain.InsNewStone();
        }
        Destroy(this.gameObject);
    }
}
