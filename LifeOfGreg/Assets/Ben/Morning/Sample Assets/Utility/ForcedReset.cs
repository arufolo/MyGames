using UnityEngine;


[RequireComponent(typeof(GUITexture))]
public class ForcedReset : MonoBehaviour {

    void Update () {
        
        // if we have forced a reset ...
        if (CrossPlatformInput.GetButtonDown ("ResetObject")) {
            
			// load next level
			LoadingScene loadingSceneScript = GameObject.Find("EntireGameController").GetComponent("LoadingScene") as LoadingScene;
			
			loadingSceneScript.SameLevel();
			
			Application.LoadLevel(1);
        }
    }

}
