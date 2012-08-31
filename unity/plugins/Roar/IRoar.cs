/*
Copyright (c) 2012, Run With Robots
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:
    * Redistributions of source code must retain the above copyright
      notice, this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright
      notice, this list of conditions and the following disclaimer in the
      documentation and/or other materials provided with the distribution.
    * Neither the name of the roar.io library nor the
      names of its contributors may be used to endorse or promote products
      derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY RUN WITH ROBOTS ''AS IS'' AND ANY
EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL MICHAEL ANDERSON BE LIABLE FOR ANY
DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
using System;
using System.Collections;

/*! \mainpage %Roar Unity SDK Reference
 *
 * \section intro_sec Introduction
 *
 * \subsection what_is_roar What is Roar?
 *
 * %Roar is a configurable game mechanics platform.<br/>
 * You can access the creation tools from the Admin dashboard.<br/>
 *
 * \subsection what_is_roar_unity What is the Roar Unity SDK used for?
 *
 * The Unity SDK provides a wrapper around the %Roar Web API, making it easier to interact with a %Roar game server from your Unity game.
 * Should you desire to do so, you can roll your own code that uses the Web API directly.
 * However if your game is built with Unity, we recommend the use of the %Roar Unity SDK and welcome any open source contributions to it.
 *
 * \section sdk_basics Roar Unity SDK Basics
 *
 * The two key objects within the %Roar Unity SDK are the interface IRoar (found in IRoar.cs and implemented in DefaultRoar.cs) and the class that provides event management – RoarManager (found in RoarManager.cs).
 *
 * \subsection iroar_interface The IRoar Interface
 *
 * The IRoar interface is what game developers use to interact with their %Roar game on the server.
 * IRoar is composed of a number of component interfaces each representing a distinct area of game functionality.
 * The following table lists each component, clicking on a component name will show more detailed class level documentation.
 *
 *
 <table>
   <tr>
    <th>Component</th>
    <th>Provides Methods For</th>
   </tr>
   <tr>
    <td>Roar.Components.IUser</td>
    <td>Creating, authenticating and logging out a player.</td>
   </tr>
   <tr>
    <td>Roar.Components.IProperties</td>
    <td>Retrieving the properties of a player, properties can include user attributes, resources and currencies for a given user. Properties are setup in the Admin dashboard.</td>
   </tr>
   <tr>
    <td>Roar.Components.IInventory</td>
    <td>Viewing and manipulating a user's inventory. Inventory items are obtained through purchase, as gifts or completing Actions.</td>
   </tr>
   <tr>
    <td>Roar.Components.IShop</td>
    <td>Viewing and buying shop items.</td>
   </tr>
   <tr>
    <td>Roar.Components.IActions</td>
    <td>Listing and executing actions. An action can be 'completed' if requirements/costs can be met, often resulting in player rewards such as levelling up or receiving a bonus item.</td>
   </tr>
   <tr>
    <td>Roar.Components.IAchievements</td>
    <td>Viewing a player's achievements, achievements are attained by completing certain actions.</td>
   </tr>
   <tr>
    <td>Roar.Components.IGifts</td>
    <td>Viewing items a player can gift to other players</td>
   </tr>
   <tr>
    <td>Roar.Components.IInAppPurchase</td>
    <td>Viewing and buying appstore items - Unity iOS builds only</td>
   </tr>
 </table>
 *
 * \subsection roar_manager RoarManager
 *
 * The Unity %Roar SDK handles responses from the server by using a two pronged approach. Some %Roar functions take a callback function as the last argument, this callback function is executed when the %Roar server response has been received and processed by the Unity SDK. However, some events occur on the server and must be subscribed to via event handling functions. Where possible both approaches are made available to the developer e.g. if an authentication attempt fails, it could be handled by:
 *
 * subscribing a login failed function to the logInFailedEvent
 *
 * <code>
 * RoarManager.logInFailedEvent += onLoginFailed;
 * function onLoginFailed(msg) {
 *  ...
 * }
 * roar.login(username, password);
 * </code>
 *
 * or by passing a login failed callback function to the authenticate function
 *
 * <code>
 * roar.login(username, password, function(cb_info:Roar.CallbackInfo){
 *   // cb_info.code
 *   // cb_info.message
 * });
 * </code>
 *
 * Notice how the function is defined within the login function's argument list; this is an anonymous function. Callbacks can (but don't have to) be anonymous functions.
 *
 * The RoarManager class documentation contains a list of all the events that can be subscribed to.
 *
 *
 * \section troubleshooting Troubleshooting
 *
 *
 * Most %Roar API calls require an <strong>auth_token</strong> (authentication token). The auth token is automatically retrieved when a player is authenticated.
 *
 * If you are experiencing problems with %Roar, first check that an authentication token has been assigned as part of player authentication. You can do this by logging the IRoar interface's AuthToken string.
 *
 * If authentication isn't your problem, here's a suggested list of steps you can take to get your problem resolved:
 *
 * <ol>
 *   <li>Read the documentation. Available for you is the:<br/>
 *     <ul>
 *       <li>doxygen generated class documentation<br/>
 *         http://roarengine.github.com/unityapi/
 *       </li>
 *       <li>
 *         project readme on github<br/>
 *         https://github.com/roarengine/sdks/blob/master/unity/README.md
 *       </li>
 *       <li>
 *         %Roar knowledge base<br/>
 *         http://support.roarengine.com/kb
 *       </li>
         <br/>
 *     </ul>
 *   </li>
 *   <li>
 *     Search the support forums for your problem<br/>
 *     http://support.roarengine.com/discussions/support<br/>
 *     If you can't find an existing solution, create a ticket detailing what your problem is, providing whatever details you think will help the %Roar support team and the community solve your problem.
 *   </li>
 * </ol>
 */
namespace Roar
{
	
  public abstract class CallbackInfo
  {
	public abstract object d { get; }

	protected CallbackInfo(int in_code, string in_msg )
	{
		code = in_code;
		msg = in_msg;
	}

	public int code;
	public string msg;
  }

  public class CallbackInfo<T> : CallbackInfo
  {
    public override object d { get { return data; } }
    public T data;
  
    public CallbackInfo( T in_data, int in_code=IWebAPI.OK, string in_msg="" ) : base( in_code, in_msg )
    {
      data = in_data;
    }
  };

  /**
   * Many roar.io functions take a callback function.  Often this callback is
   * optional, but if you wish to use one it is always a #Roar.Callback type.
   * You might not need one if you choose to catch the results of the call using
   * the events in #RoarManager.
   *
   * The Hashtable returned will usually contain three parameters:
   *
   *   + code : an int corresponding to the values in #IWebAPI
   *   + msg : a string message, often empty on success, but containing more
   *     details in the case of an error
   *   + data : an object with the results of the call.
   *
   * The only place you might need to provide a function of a different signature
   * is when using the events specified in #RoarManager. These events accept a
   * function that corresponds to the data available to the event. See the
   * individual events for details.
   */
  //TODO: Can we unify this callback with the IRequestCallback class?
  public delegate void Callback( CallbackInfo h );
}

/**
 * The public facing container for Roar functionality.
 *
 * You get a real instance of this interface by binding the Roar script to an
 * object in your game.
 *
 * This class provides several utility functions for common tasks, and  several
 * lower-level components for more detailed operations.
 */
public interface IRoar
{
  /**
   * Get a configuration object that lets you configure how various
   * aspects of roar.io behave.
   */
  Roar.IConfig Config { get; }

  /**
   * Low level access to the entire roar api.
   *
   * @note The callbacks used by the #IWebAPI are slightly different from the Callbacks used by 
   * the other functions in #IRoar .
   */
   IWebAPI WebAPI { get; }

  /**
   * Get access to the players properties and stats.
   */
  Roar.Components.IProperties Properties { get; }

  /**
   * Get access to the players inventory functions.
   */
  Roar.Components.IInventory Inventory { get; }

  /**
   * Get access to the shop functions.
   */
  Roar.Components.IShop Shop { get; }

  /**
   * Get access to the tasks/actions functions.
   */
  Roar.Components.IActions Actions { get; }
  
  /**
   * Get access to the achievements functions.
   */
  Roar.Components.IAchievements Achievements { get; }
  
  /**
   * Get access to the gifts functions.
   */
  Roar.Components.IGifts Gifts { get; }
  
  Roar.Components.IInAppPurchase Appstore { get; }

  /**
   * Methods for notifications.
   */
  Roar.Adapters.IUrbanAirship UrbanAirship { get; }

  /**
   * The roar authentication token.
   *
   * You usually would not need this, unless you are making some direct
   * calls to the roar servers, but can be usefull for debugging.
   */
  string AuthToken { get; }

  /**
   * Returns a string representing the current version of the roar.io API
   * that you are using.
   *
   * The callback, if provided, is called with the arguments
   *
   *     {"data":"version string", "code":IWebAPI.OK, "msg":null}
   */
  string version( Roar.Callback callback = null );

  /**
   * Login a player.
   *
   * Requests an authentication token from the server for the player,
   * which is used to validate subsequent requests.
   *
   * On success:
   * - invokes callback with empty data parameter, success code and success message
   * - fires a RoarManager#loggedInEvent
   *
   * On failure:
   * - invokes callback with empty data parameter, error code and error message
   * - fires a RoarManager#logInFailedEvent containing a failure message
   *
   * @param name the players username
   * @param hash the players password
   * @param cb the callback function to be passed the result of doLogin.
   **/
  void login( string username, string password, Roar.Callback callback=null );

  /**
   * Login a player using Facebook OAuth.
   *
   * On success:
   * - invokes callback with empty data parameter, success code and success message
   * - fires a RoarManager#loggedInEvent
   *
   * On failure:
   * - invokes callback with empty data parameter, error code and error message
   * - fires a RoarManager#logInFailedEvent containing a failure message
   *
   * @param oauth_token the OAuth token.
   * @param cb the callback function to be passed the result of doLogin.
   **/
  void login_facebook_oauth( string oauth_token, Roar.Callback callback=null );

  /**
   * Logs out a user.
   * Clears the authentication token for a user. Must re-login to authenticate.
   *
   * On success:
   * - fires a RoarManager#loggedOutEvent
   *
   * On failure:
   * - invokes callback with empty data parameter, error code and error message
   *
   * @param the callback function to be passed the result of doLoginFacebookOAuth.
   **/
  void logout( Roar.Callback callback=null );

  /**
   * Creates a new user with the given username and password, and logs
   * that player in.
   *
   * On success:
   * - fires a RoarManager#createdUserEvent
   * - automatically calls doLogin()
   *
   * On failure:
   * - invokes callback with empty data parameter, error code and error message
   * - fires a RoarManager#createUserFailedEvent containing a failure message
   *
   * @param name the players username
   * @param hash the players password
   * @param cb the callback function to be passed the result of doCreate.
   **/
  void create( string username, string password, Roar.Callback callback=null );

  /**
   * @todo Document me!
   */
  string whoami( Roar.Callback callback=null );
}


