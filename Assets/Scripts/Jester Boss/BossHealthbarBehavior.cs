using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthbarBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject boss;

    Vector2 position;
    Vector2 backgroundPosition;
    Vector2 backgroundSize = new Vector2(Screen.width/2.2f + 20, Screen.height/11);

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        backgroundPosition = new Vector2(position.x - 10, position.y - 10);
    }

    // Update is called once per frame
    void Update()
    {
        //No healthbar if the boss is dead
        if (boss.GetComponent<JesterBossBehavior>().GetHealth() <= 0 || boss == null)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnGUI()
    {
        if (boss != null)
        {
            Rect background = new Rect(backgroundPosition, backgroundSize);
            DrawQuad(background, Color.black);

            Vector2 remainingHP = new Vector2(boss.GetComponent<JesterBossBehavior>().GetHealth() * (Screen.width / 200), Screen.height / 14);
            Rect r = new Rect(position, remainingHP);
            DrawQuad(r, Color.red);
        }
    }

    private void DrawQuad(Rect position, Color color)
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, color);
        texture.Apply();
        GUI.skin.box.normal.background = texture;
        GUI.Box(position, GUIContent.none);
    }

}
