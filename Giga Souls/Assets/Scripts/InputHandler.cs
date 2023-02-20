using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

namespace Ken
{

    public class InputHandler : MonoBehaviour
    {
        public float horizontal;
        public float vertical;
        public float moveAmount;
        public float mouseX;
        public float mouseY;

        public bool b_Input;
        public bool a_Input;
        public bool rb_Input;
        public bool rt_Input;
        public bool jumpInput;
        public bool inventoryInput;
        public bool lockOnInput;
        public bool rightStickRightInput;
        public bool rightStickLeftInput;

        public bool dPadUp;
        public bool dPadDown;
        public bool dPadLeft;
        public bool dPadRight;

        public bool rollFlag;
        public bool sprintFlag;
        public bool comboFlag;
        public bool lockOnFlag;
        public bool inventoryFlag;
        public float rollInputTimer;
        public bool isInteracting;

        PlayerControls inputActions;
        PlayerAttacker playerAttacker;
        PlayerInventory playerInventory;
        PlayerManager playerManager;
        UIManager uIManager;
        CameraHandler cameraHandler;

        Vector2 movementInput;
        Vector2 cameraInput;

        private void Awake()
        {
            playerAttacker= GetComponent<PlayerAttacker>();
            playerInventory= GetComponent<PlayerInventory>();
            playerManager = GetComponent<PlayerManager>();
            uIManager = FindObjectOfType<UIManager>();
            cameraHandler = FindObjectOfType<CameraHandler>();
        }


        public void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new PlayerControls();
                inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
                inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
                inputActions.PlayerActions.RB.performed += i => rb_Input = true;
                inputActions.PlayerActions.RT.performed += i => rt_Input = true;
                inputActions.Inventory.DPadRight.performed += i => dPadRight = true;
                inputActions.Inventory.DPadLeft.performed += i => dPadLeft = true;
                inputActions.PlayerActions.Interact.performed += i => a_Input = true;
                inputActions.PlayerMovement.Jump.performed += i => jumpInput = true;
                inputActions.PlayerActions.Inventory.performed += i => inventoryInput = true;
                inputActions.PlayerActions.LockOn.performed += i => lockOnInput = true;
                inputActions.PlayerMovement.LockOnTargetRight.performed += i => rightStickRightInput = true;
                inputActions.PlayerMovement.LockOnTargetLeft.performed += i => rightStickLeftInput = true;

            }
            inputActions.Enable();
        }
        private void OnDisable()
        {
            inputActions.Disable();
        }
        public void TickInput(float delta)
        {
            HandleMoveInput(delta);
            HandleRollingInput(delta);
            HandleAttackInput(delta);
            HandleQuickSlotsInput();
            HandleInventoryInput();
            HandleLockOnInput();
        }
        private void HandleMoveInput(float delta)
        {
            horizontal = movementInput.x;
            vertical = movementInput.y;
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
            mouseX = cameraInput.x;
            mouseY = cameraInput.y;
        }

        private void HandleRollingInput(float delta)
        {
            b_Input = inputActions.PlayerActions.Roll.phase == UnityEngine.InputSystem.InputActionPhase.Performed;
            sprintFlag = b_Input;

            if (b_Input)
            {
                rollInputTimer += delta;
            }
            else
            {
                if(rollInputTimer > 0 && rollInputTimer < 0.5f)
                {
                    sprintFlag = false;
                    rollFlag= true;
                }

                rollInputTimer = 0;
            }
        }

        private void HandleAttackInput(float delta)
        {
            

            // rb robi praworeczne bronie lekki attak
            if (rb_Input)
            {
                if (playerManager.canDoCombo)
                {
                    comboFlag= true;
                    playerAttacker.HandleWeaponCombo(playerInventory.rightWeapon);
                    comboFlag = false;
                }
                else
                {
                    if (playerManager.isInteracting)
                        return;
                    if (playerManager.canDoCombo)
                        return;
                    playerAttacker.HandleLightAttack(playerInventory.rightWeapon);

                }
            }
            //rt ciezki atak
            // todo: zrobic tutaj jak w lekkim ataku
            if (rt_Input)
            {
                if (playerManager.canDoCombo)
                {
                    comboFlag = true;
                    playerAttacker.HandleWeaponCombo(playerInventory.rightWeapon);
                    comboFlag = false;
                }
                else
                {
                    if (playerManager.isInteracting)
                        return;
                    if (playerManager.canDoCombo)
                        return;
                    playerAttacker.HandleHeavyAttack(playerInventory.rightWeapon);

                }
                //playerAttacker.HandleHeavyAttack(playerInventory.rightWeapon);
            }
       
        }

        private void HandleQuickSlotsInput()
        {
            

            if (dPadRight)
            {
                playerInventory.ChangeRightWeapon();
            }
            else if (dPadLeft)
            {
                playerInventory.ChangeLeftWeapon();
            }
        }

 

        private void HandleInventoryInput()
        {
            if (inventoryInput)
            {
                inventoryFlag = !inventoryFlag;

                if (inventoryFlag)
                {
                    uIManager.OpenSelectWindow();
                    uIManager.UpdateUI();
                    uIManager.hudWindow.SetActive(false);
                }
                else
                {
                    uIManager.CloseSelectWindow();
                    uIManager.CloseAllInventoryWindows();
                    uIManager.hudWindow.SetActive(true);
                }
            }
        }

        private void HandleLockOnInput()
        {
            if (lockOnInput && lockOnFlag == false)
            {
                //cameraHandler.ClearLockOnTargets();
                lockOnInput = false;
                //lockOnFlag = true;
                cameraHandler.HandleLockOn();
                if(cameraHandler.nearestLockOnTarget != null)
                {
                    cameraHandler.currentLockOnTarget = cameraHandler.nearestLockOnTarget;
                    lockOnFlag = true;
                }
            }
            else if (lockOnInput && lockOnFlag) 
            {
                lockOnInput= false;
                lockOnFlag = false;
                cameraHandler.ClearLockOnTargets();
            }

            if(lockOnFlag && rightStickLeftInput)
            {
                rightStickLeftInput = false;
                cameraHandler.HandleLockOn();
                if (cameraHandler.leftLockTarget != null)
                {
                    cameraHandler.currentLockOnTarget = cameraHandler.leftLockTarget;
                }
            }

            if (lockOnFlag && rightStickRightInput)
            {
                rightStickRightInput = false;
                cameraHandler.HandleLockOn();
                if (cameraHandler.rightLockTarget != null)
                {
                    cameraHandler.currentLockOnTarget= cameraHandler.rightLockTarget;
                }
            }

            cameraHandler.SetCameraHeight();
        }
    }

}

