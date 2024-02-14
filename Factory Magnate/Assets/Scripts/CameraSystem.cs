using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] float dragPanSpeed;

    const float minX = -18, maxX = 18, minY = -10, maxY = 10;
    bool dragPanMoveActive = false;
    Vector2 lastMousePosition;
    void Update()
    {
        Sliding();
    }

    void Sliding()
    {
        Vector3 inputDir = new Vector3(0, 0, 0);
        StartSliding();
        EndSliding();
        if (IsSlide())
        {
            inputDir.x = MouseMoveDelta().x * dragPanSpeed;
            inputDir.y = MouseMoveDelta().y * dragPanSpeed;
            lastMousePosition = Input.mousePosition;
        }
        Slide(inputDir);
    }

    void StartSliding()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragPanMoveActive = true;
            lastMousePosition = Input.mousePosition;
        }
    }

    void EndSliding()
    {
        if (Input.GetMouseButtonUp(0))
        {
            dragPanMoveActive = false;
        }
    }

    bool IsSlide()
    {
        return dragPanMoveActive;
    }

    Vector2 MouseMoveDelta()
    {
        return (Vector2)Input.mousePosition - lastMousePosition;
    }

    void Slide(Vector3 inputDir)
    {
        Vector3 moveDir = -transform.up * inputDir.y + -transform.right * inputDir.x;
        transform.position = ClampCamera(transform.position + moveDir * Time.deltaTime);
    }
    Vector3 ClampCamera(Vector3 targetPosition)
    {
        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
    }
}
