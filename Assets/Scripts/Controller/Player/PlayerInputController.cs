using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private Camera _mainCam;

    private void Start()
    {
        _mainCam = Camera.main;
    }

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            transform.position = (Vector2)_mainCam.ScreenToWorldPoint(touch.position);
        }
    }
}
