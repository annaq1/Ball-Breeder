using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreedNewBalls : MonoBehaviour {

    private ContactFilter2D filter;
    private Collider2D[] colliders;
    private Collider2D cd;
    private GameObject color1;
    private GameObject color2;
    private bool babyMade;

	// Use this for initialization
	void Start () {
        filter.NoFilter();
        cd = GetComponent<Collider2D>();
        colliders = new Collider2D[10];
        babyMade = false;
	}

    void SetColors()
    {
        if (!babyMade)
        {
            int count = cd.OverlapCollider(filter, colliders);
            if (count > 4 && (color1 == null || color2 == null))
            {
                for (int i = 0; i < count; ++i)
                {
                    if (color1 == null && colliders[i].gameObject.tag != "Wall")
                    {
                        color1 = colliders[i].gameObject;
                    }
                    else if (color2 == null && colliders[i].gameObject.tag != "Wall")
                    {
                        color2 = colliders[i].gameObject;
                    }
                }
                if (color1 == color2)
                {
                    color2 = null;
                }
            }
        }
    }
	
    void MakeBaby()
    {
        if (!babyMade && color1 != null && color2 != null && color1 != color2)
        {
            Color e = color1.GetComponent<SpriteRenderer>().color;
            Color d = color2.GetComponent<SpriteRenderer>().color;

            GameObject color3 = Instantiate(color1);
            color3.GetComponent<SpriteRenderer>().color = (e/2 + d/2);
            Debug.Log((e / 2 + d / 2));
            babyMade = true;

        }
    }

	// Update is called once per frame
	void Update () {
        SetColors();
        MakeBaby();
	}
}
