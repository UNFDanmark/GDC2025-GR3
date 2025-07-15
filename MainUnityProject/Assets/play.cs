using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class play : MonoBehaviour
{

    public UnityEngine.UI.Button startButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button btn = startButton.GetComponent<Button>();
        //btn.clicked(PlayNow());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayNow()
    {
        
        SceneManager.LoadScene("Programmering");
    }
    
}
