using UnityEngine;
using UnityEngine.UIElements;

namespace AppBar.UI
{
    public class AppBarController : MonoBehaviour
    {
        private VisualElement _appBarContainer;

        private void Start()
        {
            _appBarContainer = GetComponent<UIDocument>().rootVisualElement;
        }
    }
}