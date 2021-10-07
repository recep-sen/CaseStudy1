using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIColorchanger : MonoBehaviour
{
    public GameObject dropdownmenu;
    public GameObject texturecode;
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
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (MaterialFinder.targetObject != null)
            {
                dropdownmenu.SetActive(true);
                crosshair.SetActive(false);
                Cursor.visible = true;
                Controller.Movementunlocked = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (MaterialFinder.targetObject != null)
            {
                texturecode.SetActive(true);
                crosshair.SetActive(false);
                Cursor.visible = true;
                Controller.Movementunlocked = false;
            }
        }
    }
    public void ChangeColor()
    {
        MaterialFinder.changecolor(colors[dropdownmenu.GetComponent<Dropdown>().value]);
        dropdownmenu.SetActive(false);
        crosshair.SetActive(true);
        Cursor.visible = false;
        Controller.Movementunlocked = true;
    }
    public void ChangeTexture()
    {
        MaterialFinder.changetexture(textures[Int32.Parse(texturecode.GetComponent<InputField>().text)-1]);
        texturecode.SetActive(false);
        crosshair.SetActive(true);
        Cursor.visible = false;
        Controller.Movementunlocked = true;
    }
}