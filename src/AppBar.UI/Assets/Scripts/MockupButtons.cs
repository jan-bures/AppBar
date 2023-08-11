using System;
using AppBar.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class MockupButtons : MonoBehaviour
{
    public VisualTreeAsset appBarTemplate;
    public VisualTreeAsset appBarItemTemplate;

    private const float ReferenceWidth = 1920;
    private const float ReferenceHeight = 1080;

    internal DragManipulator Manipulator;

    private void Awake()
    {
        var appBarContainer = GetComponent<UIDocument>().rootVisualElement;

        var icon1 = Resources.Load<Texture2D>("cloud");
        var icon2 = Resources.Load<Texture2D>("house");
        var icon3 = Resources.Load<Texture2D>("location");
        var icon4 = Resources.Load<Texture2D>("star");
        var icon5 = Resources.Load<Texture2D>("user");

        appBarContainer.style.alignItems = Align.FlexStart;

        appBarContainer.style.width = ReferenceWidth;
        appBarContainer.style.height = ReferenceHeight;

        var appBar1 = appBarTemplate.Instantiate();
        Manipulator = new DragManipulator();
        appBar1.AddManipulator(Manipulator);
        CenterByDefault(appBar1);
        var appBar2 = appBarTemplate.Instantiate();
        appBar2.Q<Label>(classes: "app-bar-label").text = "Other App Bar";
        appBar2.AddManipulator(new DragManipulator());
        CenterByDefault(appBar2);

        appBarContainer.Add(appBar1);
        // appBarContainer.Add(appBar2);

        var appBarItem1 = appBarItemTemplate.Instantiate();
        appBarItem1.Q<VisualElement>(classes: "icon").style.backgroundImage = icon1;
        var appBarItem2 = appBarItemTemplate.Instantiate();
        appBarItem2.Q<VisualElement>(classes: "icon").style.backgroundImage = icon2;
        var appBarItem3 = appBarItemTemplate.Instantiate();
        appBarItem3.Q<VisualElement>(classes: "icon").style.backgroundImage = icon3;
        var appBarItem4 = appBarItemTemplate.Instantiate();
        appBarItem4.Q<VisualElement>(classes: "icon").style.backgroundImage = icon4;
        var appBarItem5 = appBarItemTemplate.Instantiate();
        appBarItem5.Q<VisualElement>(classes: "icon").style.backgroundImage = icon5;

        appBar1.Q<VisualElement>(classes: "app-bar-container-items").Add(appBarItem1);
        appBar1.Q<VisualElement>(classes: "app-bar-container-items").Add(appBarItem2);
        appBar1.Q<VisualElement>(classes: "app-bar-container-items").Add(appBarItem3);

        appBar2.Q<VisualElement>(classes: "app-bar-container-items").Add(appBarItem4);
        appBar2.Q<VisualElement>(classes: "app-bar-container-items").Add(appBarItem5);
    }

    /* #region Helpers */

    private static void SetDefaultPosition(VisualElement element, Func<Vector2, Vector2> calculatePosition)
    {
        EventCallback<GeometryChangedEvent> geometryChanged = null;
        geometryChanged = evt => { GeometryChangedHandler(evt, element, calculatePosition, geometryChanged); };

        element.RegisterCallback(geometryChanged);
    }

    private static void GeometryChangedHandler(
        GeometryChangedEvent evt,
        VisualElement element,
        Func<Vector2, Vector2> calculatePosition,
        EventCallback<GeometryChangedEvent> geometryChanged
    )
    {
        if (evt.newRect.width == 0 || evt.newRect.height == 0)
        {
            return;
        }

        element.transform.position = calculatePosition(new Vector2(evt.newRect.width, evt.newRect.height));
        element.UnregisterCallback(geometryChanged);
    }

    private static void CenterByDefault(VisualElement element)
    {
        SetDefaultPosition(element, windowSize => new Vector2(
            (ReferenceWidth - windowSize.x) / 2,
            (ReferenceHeight - windowSize.y) / 2
        ));
    }

    /* #endregion */
}