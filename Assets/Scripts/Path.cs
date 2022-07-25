using UnityEngine;

public class Path : MonoBehaviour
{
    private LineRenderer _line;

    public void DrawLine(Vector2 startPos, Vector2 endPos)
    {
        _line = GetComponent<LineRenderer>();
        _line.positionCount = 2;
        _line.SetPosition(0, startPos);
        _line.SetPosition(1, endPos);
    }
}
