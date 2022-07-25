using UnityEngine;
using UnityEngine.Events;

public class PlayerInputs : MonoBehaviour
{
    public event UnityAction<Vector2> TargetAdded;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var worldPosition =  Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            AddTargetPosition(worldPosition);
        }
    }

    private void AddTargetPosition(Vector2 target)
    {
        TargetAdded?.Invoke(target);
    }
}
