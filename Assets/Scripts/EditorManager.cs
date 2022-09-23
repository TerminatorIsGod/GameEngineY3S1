using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditorManager : MonoBehaviour
{
    PlayerAction inputAction;

    public Camera cameraMain;
    public Camera cameraEditor;

    public GameObject prefab1;
    public GameObject prefab2;

    GameObject item;

    public bool editorMode = false;

    bool instantiated = false;

    // Start is called before the first frame update
    void Awake()
    {
        //inputAction = PlayerController.instance.inputAction;

        inputAction = new PlayerAction();

        inputAction.Editor.EnableEditor.performed += cntxt => SwitchCamera();
        inputAction.Editor.AddItem1.performed += cntxt => AddItem(1);
        inputAction.Editor.AddItem2.performed += cntxt => AddItem(2);
        inputAction.Editor.DropItem.performed += cntxt => DropItem();

        cameraMain.enabled = true;
        cameraEditor.enabled = false;
    }

    private void OnEnable()
    {
        inputAction.Player.Enable();
    }

    private void OnDisable()
    {
        inputAction.Player.Disable();
    }

    private void AddItem(int num)
    {
        if (editorMode && !instantiated)
        {
            switch (num)
            {
                case 1:
                    item = Instantiate(prefab1);
                    break;
                case 2:
                    item = Instantiate(prefab2);
                    break;
            }

            instantiated = true;
        }
    }

    private void DropItem()
    {

    }

    private void SwitchCamera()
    {
        cameraMain.enabled = !cameraMain.enabled;
        cameraEditor.enabled = !cameraEditor.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraMain.enabled == false && cameraEditor.enabled == false)
        {
            Time.timeScale = 0;
            editorMode = true;
            Cursor.lockState = CursorLockMode.None;
        } else
        {
            editorMode = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
