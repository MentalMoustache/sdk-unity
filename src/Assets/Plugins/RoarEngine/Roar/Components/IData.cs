using System.Collections;

namespace Roar.Components
{

  /**
	* Methods for loading and storing data to the netdrive.
   **/
  public interface IData
  {
		/**
		 * Loads data for the specified "ikey" from the netdrive.
		 *
		 * @param ikey the data key
		 */
		void load( string key, Roar.Callback<string> callback );

		/**
		 * saves data for the specified "ikey" to the netdrive.
		 *
		 * @param ikey the data key
		 */
		void save( string ikey, string data, Roar.Callback<WebObjects.User.NetdriveSaveResponse> cb );
  }

}
