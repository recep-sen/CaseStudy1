//UI script that calls to changes of Color and Textures also handles some UI events

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMaterialChanger : MonoBehaviour
{
    public GameObject colorPicker;
    public GameObject texturePicker;
    public GameObject crosshair;
    public List<Color> colors = new List<Color>()
{
    Color.red,
    Color.green,
    Color.blue,
    Color.white,
    Color.black,
    Color.gray,
    Color.cyan,
    Color.magenta,
    Color.yellow,
};
    public List<Texture> textures = new List<Texture>();

    void Update()
    {
        //Activate appropriate UI to change color or texture
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (MaterialFinder.targetObject != null)
            {
                colorPicker.SetActive(true);
                crosshair.SetActive(false);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                Controller.movementUnlocked = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (MaterialFinder.targetObject != null)
            {
                texturePicker.SetActive(true);
                crosshair.SetActive(false);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                Controller.movementUnlocked = false;
            }
        }
    }
    //UI triggers that calls global methods and also disables UI after using 
    public void ChangeColor()
    {
        MaterialFinder.ChangeColor(colors[colorPicker.GetComponent<Dropdown>().value]);
        colorPicker.SetActive(false);
        crosshair.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Controller.movementUnlocked = true;
    }
    public void ChangeTexture()
    {
        MaterialFinder.ChangeTexture(textures[Int32.Parse(texturePicker.GetComponent<InputField>().text)-1]);
        texturePicker.SetActive(false);
        crosshair.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Controller.movementUnlocked = true;
    }
}