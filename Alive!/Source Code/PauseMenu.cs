using System;
using UnityEngine;
using System.Collections;
 
public class PauseMenu : MonoBehaviour
{
    bool paused = false;
	Texture2D logoTexture;
	GUISkin newSkin;
 
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
         paused = togglePause();
    }
 
    void OnGUI()
    {
		//load GUI skin
		GUI.skin = newSkin;
		//show the mouse cursor
		Screen.showCursor = true;
		//run the pause menu script		
       if(paused)
       {
		//layout start
		GUI.BeginGroup(new Rect(Screen.width / 2 - 150, 50, 300, 250));
		//the menu background box
		GUI.Box(new Rect(0, 0, 300, 250), "");
		//logo picture
		GUI.Label(new Rect(15, 10, 300, 68), logoTexture);
		///////pause menu buttons
		//game resume button
		if(GUI.Button(new Rect(55, 100, 180, 40), "Resume"))
		{
		//resume the game
		paused = togglePause();
		}
		//main menu return button (level 0)
		if(GUI.Button(new Rect(55, 150, 180, 40), "Main Menu"))
		{
		paused = togglePause();
		Application.LoadLevel(0);
		}
		//quit button
		if(GUI.Button(new Rect(55, 200, 180, 40), "Quit"))
			{
			Application.Quit();
			}	
		//layout end

		GUI.EndGroup();
		}
}

 
    bool togglePause()
    {
       if(Time.timeScale == 0f)
       {
         Time.timeScale = 1f;
         return(false);
       }
       else
       {
         Time.timeScale = 0f;
         return(true);    
       }
    }
}