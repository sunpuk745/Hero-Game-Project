using UnityEngine;

public class Portal : Collidable
{
    public string[] sceneNames;

    protected override void OnCollide(Collider2D coll)
    {

        if(coll.name == "Player")
        {
            // Teleport the player
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.PlayerWarp);
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            

        }
    }
}
