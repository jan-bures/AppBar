# AppBar API for KSP2

## General description

The following is a description of a toolbar API mod for the Unity game Kerbal Space Program 2.

The goal is to add support for toolbars (in this game called "app bars") that mods can place their buttons on. The system should work this way: in every different game state (main menu, flight view, map view, etc.), there will be a completely separate set of app bars. By default, all the game states will have one empty app bar.

An app bar consists of any number of mod-registered buttons, a label with its name ("app.bar" by default) and a menu triggered by clicking on a special tripple-dot button on the side of the bar. The menu contains options to unlock/lock the position of the app bar (when it is unlocked, it can be dragged and dropped anywhere within the screen bounds, and the mod buttons will be disabled until it is locked again), to rename the app bar, to create a new empty app bar, to delete the app bar (unless it's the only one in the current game state - then the delete option will be disabled), to export or import settings to/from a JSON file, to choose which mod-registered buttons will be displayed on the current app bar, to change the scale of the app bar, and to change the number of rows that the buttons display in (the default being 1).

Mods should be able to register their buttons with the set of possible game states where the button can be used, and the app bar library needs to allow users to add any button to any app bar in any allowed game state.

The buttons will be added to an app bar by opening the specific app bar's menu, and selecting the option to manage buttons, which will bring up a window with toggles for each of the allowed registered buttons. The button management window should show the buttons in two separate lists - enabled and disabled buttons. By flipping the toggle for a button, it will be moved from one list to the other. The user can also use drag-and-drop to reorder the buttons within the enabled list or move a button from one list to the other. There should be an indicator in the button manager to show whether the button has already been added to a different app bar in the current game state, to help users avoid duplication, while not outright forbidding it.

All buttons have an indicator above, with gray generally meaning the mod is off or its window is not displayed, and green meaning the mod is on or its window is displayed.
Each button can have one or more states. Each state can have a different label, icon, indicator color, click action and right-click action. There should be an overload for button creation where no states are provided, and instead a single label, icon, click action and right click action are provided. Then two states will be created, an off state with a gray indicator and an on state with a green indicator, and the same actions will be used by both states, serving as toggles.

## Dependencies

### Game state
This is an enum with all the possible game states. It will be used to determine which app bars are available in the current game state, and which buttons can be added to the current app bar. It is not part of the library, but is provided by the game.

## Main parts of the library

### Root namespace

#### App bar plugin

The main BepInEx plugin class of the library that is used by mods to access the API. It is a singleton that contains an internal reference to the app bar manager, an internal reference to the settings file, and a public reference to the mod button registry. It will be responsible for loading the settings file at startup.

### API models

#### Button state
A button state contains a label, an icon, an indicator color, a click action and a right-click action. The click and right click actions are delegates that provide the associated button as a parameter. The right click action is optional.

#### Mod button
A mod button contains a list of button states, the current button state and a list of game states where it can be used. The game states are used to determine which app bars can contain the button.

#### Mod button registry
The mod button registry contains a list of mod buttons. It is used to register new mod buttons, and to look up mod buttons by ID. Mod developers will be able to call the registry to register their buttons, and the app bar library will call the registry to look up the buttons when loading data from the settings file.

### Core models

#### App bar
An app bar contains a list of mod buttons, a name, a flag with locked/unlocked status, a position, a scale, a number of rows, and a game state. The game state is used to determine which app bars are available in the current game state, and which buttons can be added to the current app bar.

#### App bar manager
The app bar manager will contain a list of

### Settings

#### App bar serializer
Used to serialize and deserialize app bars to and from JSON. Will be used by the settings file service to save and load the list of app bars from a JSON file.

#### Settings file service
Used to load and save the list of app bars to a JSON file. Will be used to load the list of app bars at startup, and to save the list of app bars whenever it changes.

### Presenters

#### App bar presenter
The app bar presenter will be responsible for handling user input on the app bar view, and for updating the app bar view when the app bar model changes.

#### Button presenter
The button presenter will be responsible for handling user input on the button view, and for updating the button view when the button model changes.

#### Button management window presenter
The button management window presenter will be responsible for handling user input on the button management window, and for updating the button management window when the button registry or app bar changes.

### Views
The view layer is responsible for displaying the app bars and their buttons, and for handling user input. It will be implemented using Unity's UI Toolkit framework with UXML and USS files.

#### App bar view
The app bar view will contain a label with the app bar name, a menu button, a list of mod buttons, and a menu. The menu will contain options to unlock/lock the position of the app bar, to rename the app bar, to create a new empty app bar, to delete the app bar (unless it's the only one in the current game state - then the delete option will be disabled), to export or import settings, to choose which mod buttons will be displayed on the current app bar, to change the scale of the app bar, and to change the number of rows that the buttons display in (the default being 1).

#### Button view
The button view will contain a label, an icon, and an indicator. The indicator will be a colored line above the button.

#### Button management window view
The button management window will contain two lists of mod buttons - enabled and disabled. The user will be able to use drag-and-drop to reorder the buttons within the enabled list or move a button from one list to the other. There should be indicators in the button manager to show whether a button has already been added to a different app bar in the current game state, to help users avoid duplication, while not outright forbidding it.

## Lifecycle

The app bars will be loaded at startup from a JSON settings file, and will be saved into the same file with every change. The file will contain a list of app bars, each with its game state, name, position, scale, number of rows, and a list of button IDs. The button IDs will be used to look up the buttons in the button registry, where mod authors register them.

Mods are able to register their buttons at any time, which means that if a mod registers a button after the app bars have been loaded, the button has to be added to the appropriate app bars that have its ID in their list of button IDs. The same goes for removing buttons - if a mod removes a button, it has to be removed from all app bars that have its ID in their list of button IDs. This should be handled through events that the button registry will fire when a button is registered or removed.