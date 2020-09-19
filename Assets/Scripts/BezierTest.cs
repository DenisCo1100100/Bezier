using UnityEngine;

[ExecuteAlways]
public class BezierTest : MonoBehaviour
{
    public Transform p0;
    public Transform p1;
    public Transform p2;
    public Transform p3;

    [Range(0, 1)]
    public float t;

    void Update()
    {
        transform.position = BezierLerp.GetPoint(p0.position, p1.position, p2.position, p3.position, t);
        transform.rotation = Quaternion.LookRotation(BezierMath.GetFirstDerivative(p0.position, p1.position, p2.position, p3.position, t));
    }

    //Отрисовка кривой
    private void OnDrawGizmos()
    {
        int sigmentsNumber = 20;
        Vector3 preveousePoint = p0.position;

        for (int i = 0; i < sigmentsNumber + 1; i++)
        {
            float parement = (float)i / sigmentsNumber;
            Vector3 point = BezierLerp.GetPoint(p0.position, p1.position, p2.position, p3.position, parement);
            Gizmos.DrawLine(preveousePoint, point);
            preveousePoint = point;
        }
    }
}
