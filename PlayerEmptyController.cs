using UnityEngine;
using Unity.Cinemachine;

public class PlayerEmptyController : MonoBehaviour
{

    // должен быть у префаба пустого игрока
    private CharacterController Controller;
    [Header("Настройки скорости перемещения wasd-ами")]
    public float moveSpeed = 20f;

    [Header("Настройки zoom")]
    public float zoomSpeed = 12f;
    public float zoomSpeedNear = 6f;
    public float minRadialAxis = 0.5f;
    public float maxRadialAxis = 6f;
    public float RadialAxisNearFrom = 0.5f;
    public float RadialAxisNearTo = 1.5f;

    [Header("Настройки ротации")]
    public float rotationSpeed = 3.5f;
    public float maxRotationUp = 33f;
    public float minRotationUp = 10f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {

    }

    public void RTSMoveForward(CinemachineCamera CamRTS, Vector3 InputVector)
    {
        Vector3 forward = CamRTS.transform.forward;
        forward.y = 0; // Движение только по горизонтали
        forward.Normalize();
        Vector3 move = forward * InputVector.y * moveSpeed * Time.deltaTime;
        Move(move);
    }

    public void RTSMoveRight(CinemachineCamera CamRTS, Vector3 InputVector)
    {
        Vector3 right = CamRTS.transform.right;
        right.y = 0; // Движение только по вертикали
        right.Normalize();
        Vector3 move = right * InputVector.x * moveSpeed * Time.deltaTime;
        Move(move);
    }

    public void RTSMoveZoom(CinemachineOrbitalFollow CamOrbitalRTS, Vector3 InputVector)
    {
        var vZoomSpeed = zoomSpeed;
        if (CamOrbitalRTS.RadialAxis.Value > RadialAxisNearFrom && CamOrbitalRTS.RadialAxis.Value < RadialAxisNearTo)
        {
            vZoomSpeed = zoomSpeed;
        }

        var radialValue = CamOrbitalRTS.RadialAxis.Value - (InputVector.y * Time.deltaTime * vZoomSpeed);
        if (radialValue < minRadialAxis)
        {
            CamOrbitalRTS.RadialAxis.Value = minRadialAxis + 0.01f;
        }
        else if (radialValue > maxRadialAxis)
        {
            CamOrbitalRTS.RadialAxis.Value = maxRadialAxis - 0.01f;
        }
        else
        {
            CamOrbitalRTS.RadialAxis.Value = radialValue;
        }
    }
    public void RTSMoveRotation(CinemachineOrbitalFollow CamOrbitalRTS, Vector3 InputVector)
    {
        CamOrbitalRTS.HorizontalAxis.Value += InputVector.x * rotationSpeed * Time.deltaTime;

        var verticalValue = CamOrbitalRTS.VerticalAxis.Value + InputVector.y * rotationSpeed * Time.deltaTime;
        if (verticalValue > maxRotationUp)
        {
            CamOrbitalRTS.VerticalAxis.Value = maxRotationUp - 0.01f;
        }
        else if (verticalValue < minRotationUp)
        {
            CamOrbitalRTS.VerticalAxis.Value = minRotationUp - 0.01f;
        }
        else
        {
            CamOrbitalRTS.VerticalAxis.Value = verticalValue;
        }
    }


    public void Move(Vector3 vector)
    {
        Controller.Move(vector);
    }
}
