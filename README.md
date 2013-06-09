# Roar Unity SDK

A C# interface to the [Roar API](http://roarengine.github.io/webapi/), with skinnable prefab UI widgets.


#### Prerequisites
The SDK requires that you have access to a Roar API host. See [www.roarengine.com](http://roarengine.com/) to set one up.

## Summary

To get the Roar SDK set up in your Unity application:

1. Import the Roar SDK package `Roar.unityPackage` into your project
2. Create a **Roar System Object** Game Object
3. Set the Roar **game key** and **API host**
4. Configure Roar SDK event handlers and callbacks
5. Update your app to make calls to the server via the SDK interface `IRoar`

#### Examples
Full **implementation examples** are in the imported **`/Dev/test.unity`** scene. Or, for a simple example, you can try our [augmented version of AngryBots](https://github.com/roarengine/angrybots).

#### SDK docs
Doxygen generated [Class documentation](http://roarengine.github.io/unityapi/).

---

## Installation
Download **[Roar.unityPackage](https://github.com/roarengine/sdk-unity/raw/master/Roar.unityPackage)** for Unity 4.x. Or clone this repository:

    git clone https://github.com/roarengine/sdk-unity.git

Import the Roar Unity SDK package file **Roar.unityPackage** via the menu item at `Assets->Import Package->Custom Package`. This will add a *Plugins/Roar* folder to your project.




## Using the SDK

Once imported:


1. Always start by adding a Roar **System Object** to setup your config. Menu item:
`Game Object->Create Other->Roar->System Object`

2. To begin using the SDK, set the **API host** and **game key**.
    - **API host**: the root hostname of your API (eg. `http://api.your.host/`)
    - **game key**: the lowercase unique *key* identifying your game (eg. `my_game`)


### Making calls
SDK calls use the `IRoar` interface to interact with the Roar server API.

There are two ways to **handle the results** of an SDK call:

- **1. Events**: setup *listeners* for events that have been fired as a result of an SDK call.

Event handler example:

    // Your handler function
    function onLogin() { /* Your handler code here */ }

    // Setup the event listener to run your `onLogin` handler
    RoarManager.loggedInEvent += onLogin;

    // Trigger a call to login and watch the fireworks
    // Notice the 'null' third parameter. No callback.
    roar.login(username, password, null);

- **2. Callback methods**: explicitly make SDK calls passing a callback handler

Callback handler example:

    // Your handler function
    function onLogin() { /* Your handler code here */ }

    // Call the SDK method, passing your `onLogin` callback handler
    roar.login(username, password, onLogin);

#### Gotchas to note
Both of these approaches are fine, but **not all SDK methods support both**. Check the class documentation for details.

### Class documentation
Doxygen class documention available at **[http://roarengine.github.io/unityapi](http://roarengine.github.io/unityapi/)**


### Footnote: Raw API access
There is a low level API bridge available via `IRoar.WebAPI`.

This allows you to make (almost) raw calls to the Roar API. Please note that mixing and matching SDK calls with this lower level interface may not keep your application in sync. *Use with caution*.

For more details, [check the documentation](http://roarengine.github.io/unityapi/#unity_sdk_vs_web_api).


---

## Contributing
This is an open source project. Go nuts.

## Build process

### Requirements
Requires **npm** which is bundled with [NodeJS](http://nodejs.org/download/). Once installed you will need to ensure you have `jsonlint` available in your path (ie. global) and a local copy of `underscore`.

Also requires **[doxygen](http://www.stack.nl/~dimitri/doxygen/download.html)** to generate the API documentation.

### Build Instructions
Build the package by running

    (Mac) make -f package.Makefile
    (Win) package.bat

This will produce a `./dist/Roar.unityPackage`.

You can also generate updated class docs *(Requires [doxygen](http://www.stack.nl/~dimitri/doxygen/download.html))*

    (Mac): make -f docs.Makefile
    (Win): doxygen api_docs.doxygen

#### Notes on system PATH
You will need to ensure that `Unity` is available in your system `$PATH`, along with access to `jsonlint` and `doxygen`. For Windows users, your Unity Editor executable is likely to be at either:

    (a) ;C:\Program Files (x86)\Unity\Editor
    (b) ;C:\Program Files\Unity\Editor


## Testing
Open the `Testing.sln` project in the root of the repository (using something like **MonoDevelop**. You **must** refresh the reference to the `/Testing/NMock2.dll` file pacakged with the repository.

- In the project file browser on the left:
    - expand the 'Testing' folder
    - *right-click* on **References**
    - Select **Edit References**
- In the Edit References popup:
    - Click the **.NET Assemblies** tab
    - Navigate to the `/Testing` folder in the repository
    - Double click (or 'Add') the `NMock2.dll` file
    - Click "Okay"

To run the tests, click on the **Unit Tests** tab on the left and double-click the **Testing** menu item - this will *build and run* the tests. Alternatively, select "Run Item" on the Testing project folder.

Note that several tests are only stubs, and thus ignored.

---

:P
