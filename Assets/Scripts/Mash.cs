using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mash : MonoBehaviour
{
    #region Variables
    [SerializeField]
    int mashAmmount = 0;
    [SerializeField]
    float repeatRate = 1f;
    bool start = false;
    bool winBool = false;
    int count;

    [SerializeField]
    GameObject win;

    [SerializeField]
    Text countText;

    [SerializeField]
    Sprite one;

    [SerializeField]
    Sprite two;

    [SerializeField]
    Sprite three;

    [SerializeField]
    Sprite four;

    [SerializeField]
    Sprite five;

    #endregion

    void Update ()
    {
        ChangeSprite();
        if (!start)
        {
            InvokeRepeating("Fall", 0f, repeatRate);
            start = true;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (!winBool)
            {
                mashAmmount++;
                count++;
            }
        }
        //Debug.Log(mashAmmount);
	}

    void Fall()
    {
        if (mashAmmount >= 0)
        {
            mashAmmount--;
        }
        //Debug.Log(mashAmmount);
    }

    void ChangeSprite()
    {
        if (mashAmmount <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = one;
        }
        else if (mashAmmount >= 10 && mashAmmount < 20)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = two;
        }
        else if (mashAmmount >= 20 && mashAmmount < 30)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = three;
        }
        else if (mashAmmount >= 30 && mashAmmount < 40)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = four;
        }
        else if (mashAmmount >= 50)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = five;
            winBool = true;
            countText.text = "You hit space " + count + " times to wake her up!";
            win.SetActive(true);
            CancelInvoke();
            //repeatRate = 0.6f;
            //start = false;
            //Win();
        }
    }
}
