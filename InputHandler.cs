using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;
//https://www.corykoseck.com/2020/05/02/using-unity-2019-input-system/



    public class InputHandler : MonoBehaviour
    {
        // Обработчик ввода данных
        // Частично берёт на себя функции управления
        // Не знаю как разграничить логику

        private InputMaster inputMaster;
        private bool isAllowMoveCamera = true;

        public Vector2 MousePositionVector;
        public Vector2 MouseScrollVector;
        public Vector2 MouseDeltaVector;

        public bool isMouseRightButtonPressed;
        public bool isMouseMiddleButtonPressed;
        public bool isMouseLeftButtonPressed;
        public bool isMousePress;
        public bool isMouseUp;
        public bool isMouseDown;
        public bool isPressW;
        public bool isPressA;
        public bool isPressS;
        public bool isPressD;
        public bool isMouseScrolling;
        public bool isWithLog = true;

        private PlayerEmptyController PlayerController;
        public CinemachineCamera CamRTS;
        //private CinemachineFollow CamFollowRTS;
        private CinemachineOrbitalFollow CamFollowRTS;

        private void OnEnable()
        {

        }

        private void OnDisable()
        {
            inputMaster.Disable();
        }

        private void Awake()
        {
            AwakeCamera();
            AwakeInputs();
        }
        private void AwakeInputs()
        {
            inputMaster = new InputMaster();
            inputMaster.Enable();

            //Обратные вызовы
            //PERFORMED

            inputMaster.RTSCamera.MouseRightButton.performed += mouse_right_button_performed;
            inputMaster.RTSCamera.MouseMiddleButton.performed += mouse_middle_button_performed;
            inputMaster.RTSCamera.MouseLeftButton.performed += mouse_left_button_performed;

            inputMaster.RTSCamera.MouseDelta.performed += mouse_delta_performed;
            inputMaster.RTSCamera.MousePosition.performed += mouse_position_performed;
            inputMaster.RTSCamera.MouseScroll.performed += mouse_scroll_performed;

            inputMaster.RTSCamera.MousePress.performed += mouse_press_performed;
            inputMaster.RTSCamera.MouseUp.performed += mouse_up_performed;
            inputMaster.RTSCamera.MouseDown.performed += mouse_down_performed;

            inputMaster.RTSCamera.W.performed += key_w_performed;
            inputMaster.RTSCamera.A.performed += key_a_performed;
            inputMaster.RTSCamera.S.performed += key_s_performed;
            inputMaster.RTSCamera.D.performed += key_d_performed;

            //CANCELED

            inputMaster.RTSCamera.MouseRightButton.canceled += mouse_right_button_canceled;
            inputMaster.RTSCamera.MouseMiddleButton.canceled += mouse_middle_button_canceled;
            inputMaster.RTSCamera.MouseLeftButton.canceled += mouse_left_button_canceled;

            inputMaster.RTSCamera.MouseDelta.canceled += mouse_delta_canceled;
            inputMaster.RTSCamera.MousePosition.canceled += mouse_position_canceled;
            inputMaster.RTSCamera.MouseScroll.canceled += mouse_scroll_canceled;

            inputMaster.RTSCamera.MousePress.canceled += mouse_press_canceled;
            inputMaster.RTSCamera.MouseUp.canceled += mouse_up_canceled;
            inputMaster.RTSCamera.MouseDown.canceled += mouse_down_canceled;

            inputMaster.RTSCamera.W.canceled += key_w_canceled;
            inputMaster.RTSCamera.A.canceled += key_a_canceled;
            inputMaster.RTSCamera.S.canceled += key_s_canceled;
            inputMaster.RTSCamera.D.canceled += key_d_canceled;
        }
        private void mouse_delta_performed(InputAction.CallbackContext obj)
        {
            MouseDeltaVector = obj.ReadValue<Vector2>();
            if (isWithLog) { Debug.Log("Вектор дельты курсора" + MouseDeltaVector); }
        }

        private void mouse_delta_canceled(InputAction.CallbackContext obj)
        {
            MouseDeltaVector = Vector2.zero;
            if (isWithLog) { Debug.Log("Вектор дельты курсора" + MouseDeltaVector); }
        }

        private void mouse_position_performed(InputAction.CallbackContext obj)
        {
            MousePositionVector = obj.ReadValue<Vector2>();
            if (isWithLog) { Debug.Log("Вектор позиции курсора" + MousePositionVector); }
        }

        private void mouse_position_canceled(InputAction.CallbackContext obj)
        {
            MousePositionVector = Vector2.zero;
            if (isWithLog) { Debug.Log("Вектор позиции курсора" + MousePositionVector); }
        }

        private void mouse_scroll_performed(InputAction.CallbackContext obj)
        {
            MouseScrollVector = obj.ReadValue<Vector2>();
            isMouseScrolling = true;
            if (isWithLog) { Debug.Log("Вектор скрола мыши" + MouseScrollVector); }
        }
        private void mouse_scroll_canceled(InputAction.CallbackContext obj)
        {
            MouseScrollVector = Vector2.zero;
            isMouseScrolling = false;
            if (isWithLog) { Debug.Log("Вектор скрола мыши" + MouseScrollVector); }
        }

        private void mouse_press_performed(InputAction.CallbackContext obj)
        {
            isMousePress = obj.ReadValue<float>() == 1;
            if (isWithLog) { Debug.Log("Кнопка мыши нажата" + isMousePress); }
        }
        private void mouse_press_canceled(InputAction.CallbackContext obj)
        {
            isMousePress = obj.ReadValue<float>() == 1;
            if (isWithLog) { Debug.Log("Кнопка мыши" + isMousePress); }
        }

        private void mouse_up_performed(InputAction.CallbackContext obj)
        {
            if (isWithLog) { Debug.Log("Мышь вверх" + obj.ReadValue<float>()); }
        }
        private void mouse_up_canceled(InputAction.CallbackContext obj)
        {
            isMouseUp = obj.ReadValue<float>() == 1;
            if (isWithLog) { Debug.Log("Мышь вверх" + isMouseUp); }
        }

        private void mouse_down_performed(InputAction.CallbackContext obj)
        {
            isMouseDown = obj.ReadValue<float>() == 1;
            if (isWithLog) { Debug.Log("Мышь вниз" + isMouseDown); }
        }

        private void mouse_down_canceled(InputAction.CallbackContext obj)
        {
            isMouseDown = obj.ReadValue<float>() == 1;
            if (isWithLog) { Debug.Log("Мышь вниз" + isMouseDown); }
        }

        private void mouse_right_button_performed(InputAction.CallbackContext obj)
        {
            isMouseRightButtonPressed = obj.ReadValue<float>() == 1;
            if (isWithLog) { Debug.Log(obj.ReadValue<float>()); }
        }

        private void mouse_right_button_canceled(InputAction.CallbackContext obj)
        {
            isMouseRightButtonPressed = obj.ReadValue<float>() == 1;
            if (isWithLog) { Debug.Log(obj.ReadValue<float>()); }
        }

        private void mouse_middle_button_performed(InputAction.CallbackContext obj)
        {
            isMouseMiddleButtonPressed = obj.ReadValue<float>() == 1;
            if (isWithLog) { Debug.Log(obj.ReadValue<float>()); }
        }

        private void mouse_middle_button_canceled(InputAction.CallbackContext obj)
        {
            isMouseMiddleButtonPressed = obj.ReadValue<float>() == 1;
            if (isWithLog) { Debug.Log(obj.ReadValue<float>()); }
        }

        private void mouse_left_button_performed(InputAction.CallbackContext obj)
        {
            isMouseLeftButtonPressed = obj.ReadValue<float>() == 1;
            if (isWithLog) { Debug.Log(obj.ReadValue<float>()); }
        }

        private void mouse_left_button_canceled(InputAction.CallbackContext obj)
        {
            isMouseLeftButtonPressed = obj.ReadValue<float>() == 1;
            if (isWithLog) { Debug.Log(obj.ReadValue<float>()); }
        }

        private void key_w_performed(InputAction.CallbackContext obj)
        {
            isPressW = obj.ReadValue<float>() == 1;
            if (isWithLog) { Debug.Log("Key W is: " + isPressW); }
        }

        private void key_w_canceled(InputAction.CallbackContext obj)
        {
            isPressW = obj.ReadValue<float>() == 1;
            if (isWithLog) { Debug.Log("Key W is: " + isPressW); }
        }

        private void key_a_performed(InputAction.CallbackContext obj)
        {
            isPressA = obj.ReadValue<float>() == 1;
            if (isWithLog) { Debug.Log("Key A is: " + isPressA); }
        }

        private void key_a_canceled(InputAction.CallbackContext obj)
        {
            isPressA = obj.ReadValue<float>() == 1;
            if (isWithLog) { Debug.Log("Key A is: " + isPressA); }
        }

        private void key_s_performed(InputAction.CallbackContext obj)
        {
            isPressS = obj.ReadValue<float>() == 1;
        }

        private void key_s_canceled(InputAction.CallbackContext obj)
        {
            isPressS = obj.ReadValue<float>() == 1;
        }

        private void key_d_performed(InputAction.CallbackContext obj)
        {
            isPressD = obj.ReadValue<float>() == 1;
        }

        private void key_d_canceled(InputAction.CallbackContext obj)
        {
            isPressD = obj.ReadValue<float>() == 1;
        }

        private void AwakeCamera()
        {
            PlayerController = gameObject.GetComponent<PlayerEmptyController>();
            CamFollowRTS = CamRTS.GetComponentInChildren<CinemachineOrbitalFollow>();
        }
        private void UpdateCamera()
        {
            if (isAllowMoveCamera)
            {
                // перемещение влево-вправо вперёд-назад wasd-ами
                Vector3 moveVector = new();
                if (isPressW) moveVector.y += 1;
                if (isPressS) moveVector.y -= 1;
                if (isPressD) moveVector.x += 1;
                if (isPressA) moveVector.x -= 1;

                // движение относительно камеры
                PlayerController.RTSMoveForward(CamRTS, moveVector);
                PlayerController.RTSMoveRight(CamRTS, moveVector);



                // вращение RTS камеры по направлению мыши при зажатой центральной кнопки мыши
                if (isMouseMiddleButtonPressed)
                {
                    PlayerController.RTSMoveRotation(CamFollowRTS, MouseDeltaVector);
                }

                if (isMouseRightButtonPressed && (MouseDeltaVector.x != 0 || MouseDeltaVector.y != 0))
                {

                }
            }
        }

        private void UpdateCameraZoom()
        {
            // скрол мышью - зум к пустому игроку RTS камеры
            if (isMouseScrolling)
            {
                PlayerController.RTSMoveZoom(CamFollowRTS, MouseScrollVector);
            }
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isWithLog)
            {
                if (isMouseLeftButtonPressed)
                {
                    Debug.Log("ЛКМ нажата");
                }
                else if (isMouseMiddleButtonPressed)
                {
                    Debug.Log("ЦКМ нажата");
                }
                else if (isMouseRightButtonPressed)
                {
                    Debug.Log("ПКМ нажата");
                }
            }
            UpdateCameraZoom();
        }
        void FixedUpdate()
        {
            UpdateCamera();
        }
    }
