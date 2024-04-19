using System.Collections;

    // Animation speed
    public float animationSpeed = 0.5f;

    //whether the buttons are expanded or collapsed
    private bool isExpanded = false;
    private Vector3[] originalPositions;


    void Start()
        //original positions of buttons
        originalPositions = new Vector3[buttonsToAnimate.Length];

        //collapse the buttons
        CollapseButtons();
            CollapseButtons();
            ExpandButtons();


    private void ExpandButtons()
    {
        for (int i = 0; i < buttonsToAnimate.Length; i++)
        {
            Vector3 targetPosition = originalPositions[i];
            buttonsToAnimate[i].SetActive(true);
            StartCoroutine(MoveButton(buttonsToAnimate[i].transform, targetPosition));
        }
        isExpanded = true;
    }

    private void CollapseButtons()
    {
        for (int i = 0; i < buttonsToAnimate.Length; i++)
        {
            //Move Up
            Vector3 targetPosition = new Vector3(0f, 0f, 0f);
            StartCoroutine(MoveButton(buttonsToAnimate[i].transform, targetPosition, true));
        }
        isExpanded = false;
    }


    private System.Collections.IEnumerator MoveButton(Transform buttonTransform, Vector3 targetPosition, bool disableAfterMove = false)
    {
        Vector3 startPosition = buttonTransform.localPosition;
        float elapsedTime = 0f;

        while (elapsedTime < animationSpeed)
        {
            buttonTransform.localPosition = Vector3.Lerp(startPosition, targetPosition, elapsedTime / animationSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        buttonTransform.localPosition = targetPosition;

        if (disableAfterMove)
        {
            buttonTransform.gameObject.SetActive(false);
        }
    }
}