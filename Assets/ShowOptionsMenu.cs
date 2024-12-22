using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowOptionsMenu : MonoBehaviour
{
    public Canvas optionsMenu;
    public bool showMenu = false;
    // Start is called before the first frame update
    void Start()
    {
        optionsMenu.enabled = showMenu;
    }
	private void OnMouseUpAsButton()
	{
        showMenu = !showMenu;
        optionsMenu.enabled = showMenu;
	}


}
