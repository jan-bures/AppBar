/*
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using BepInEx;
using JetBrains.Annotations;
using SpaceWarp;
using SpaceWarp.API.Assets;
using SpaceWarp.API.Mods;
using UitkForKsp2.API;
using UnityEngine;
using UnityEngine.UIElements;

namespace AppBar;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInDependency(SpaceWarpPlugin.ModGuid, SpaceWarpPlugin.ModVer)]
public class AppBarPlugin : BaseSpaceWarpPlugin
{
    /// <summary>
    /// The GUID of the mod.
    /// </summary>
    [PublicAPI] public const string ModGuid = MyPluginInfo.PLUGIN_GUID;

    /// <summary>
    /// The name of the mod.
    /// </summary>
    [PublicAPI] public const string ModName = MyPluginInfo.PLUGIN_NAME;

    /// <summary>
    /// The version of the mod.
    /// </summary>
    [PublicAPI] public const string ModVer = MyPluginInfo.PLUGIN_VERSION;

    /// <summary>
    /// Singleton instance of the plugin class
    /// </summary>
    public static AppBarPlugin Instance { get; set; }

    /// <summary>
    /// Runs when the mod is first initialized.
    /// </summary>
    public override void OnInitialized()
    {
        base.OnInitialized();

        Instance = this;

        TestAppBar();
    }

    private void TestAppBar()
    {
        var icon1 = AssetManager.GetAsset<Texture2D>($"{ModGuid}/images/cloud.png");
        var icon2 = AssetManager.GetAsset<Texture2D>($"{ModGuid}/images/house.png");
        var icon3 = AssetManager.GetAsset<Texture2D>($"{ModGuid}/images/location.png");
        var icon4 = AssetManager.GetAsset<Texture2D>($"{ModGuid}/images/star.png");
        var icon5 = AssetManager.GetAsset<Texture2D>($"{ModGuid}/images/user.png");

        var appBarTemplate = AssetManager.GetAsset<VisualTreeAsset>($"{ModGuid}/appbar/AppBar.uxml");
        var appBarItemTemplate = AssetManager.GetAsset<VisualTreeAsset>($"{ModGuid}/appbar/AppBarItem.uxml");

        var appBarContainer = new VisualElement
        {
            style =
            {
                alignItems = Align.FlexStart
            }
        };
        Window.CreateFromElement(appBarContainer, "AppBar Container");
        appBarContainer.style.width = ReferenceResolution.Width;
        appBarContainer.style.height = ReferenceResolution.Height;

        var appBar1 = appBarTemplate.Instantiate();
        appBar1.Q<Label>(classes: "app-bar-label").text = "My First App Bar";
        appBar1.MakeDraggable();
        appBar1.CenterByDefault();
        var appBar2 = appBarTemplate.Instantiate();
        appBar1.Q<Label>(classes: "app-bar-label").text = "Other App Bar";
        appBar2.MakeDraggable();
        appBar2.CenterByDefault();

        appBarContainer.Add(appBar1);
        appBarContainer.Add(appBar2);

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

        appBar1.Q<VisualElement>(classes: "app-bar-container").Add(appBarItem1);
        appBar1.Q<VisualElement>(classes: "app-bar-container").Add(appBarItem2);
        appBar1.Q<VisualElement>(classes: "app-bar-container").Add(appBarItem3);

        appBar2.Q<VisualElement>(classes: "app-bar-container").Add(appBarItem4);
        appBar2.Q<VisualElement>(classes: "app-bar-container").Add(appBarItem5);
    }
}