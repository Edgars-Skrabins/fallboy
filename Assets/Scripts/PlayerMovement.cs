using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed;
    [SerializeField] private float m_mouseSensitivity;
    [SerializeField] private float m_fallSpeed;
    [SerializeField] private CharacterController m_playerCharacterController;
    [SerializeField] private Transform m_playerTF;
    [SerializeField] private Transform m_cameraTF;

    private void Start()
    {
        InitializeSettings();
    }

    private void InitializeSettings()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        m_playerTF.rotation = Quaternion.Euler(90f,0,0);
    }

    private void Update()
    {
        if (GameController.Instance.gameStarted == false) return;

        MouseControl();
        MovementControl();
    }

    private float m_xRotation;

    private void MouseControl()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * m_mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * m_mouseSensitivity;

        m_xRotation -= mouseY;
        m_xRotation = Mathf.Clamp(m_xRotation, -90f, 90f);

        m_cameraTF.localRotation = Quaternion.Euler(m_xRotation, 0f, 0f);
        m_playerTF.Rotate(Vector3.up * mouseX);
    }

    private void MovementControl()
    {
        float movementX = Input.GetAxisRaw("Horizontal");
        float movementY = Input.GetAxisRaw("Vertical");

        Vector3 movementInput = new Vector3(movementX, movementY, 0);
        Vector3 movementDirection = m_playerTF.TransformDirection(movementInput).normalized;

        Vector3 m_Velocity = movementDirection * m_moveSpeed;
        m_Velocity.y = m_fallSpeed * -1;

        m_playerCharacterController.Move(m_Velocity * Time.deltaTime);
    }
}