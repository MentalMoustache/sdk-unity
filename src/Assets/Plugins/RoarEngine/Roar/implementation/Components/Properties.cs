using System.Collections;
using System.Collections.Generic;
using Roar.Components;

namespace Roar.implementation.Components
{
	public class Properties : IProperties
	{
		protected IDataStore dataStore;

		public Properties (IDataStore dataStore)
		{
			this.dataStore = dataStore;
			RoarManager.roarServerUpdateEvent += this.OnUpdate;
		}

		public void Fetch (Roar.Callback< IDictionary<string,DomainObjects.PlayerAttribute> > callback)
		{
			dataStore.properties.Fetch (callback);
		}

		public bool HasDataFromServer { get { return dataStore.properties.HasDataFromServer; } }

		public IList<DomainObjects.PlayerAttribute> List ()
		{
			return dataStore.properties.List ();
		}

		// Returns the *object* associated with attribute `key`
		public DomainObjects.PlayerAttribute GetProperty (string key)
		{
			return dataStore.properties.Get (key);
		}

		// Returns the *value* of attribute `key`
		public string GetValue (string ikey)
		{
			var x = dataStore.properties.Get(ikey);
			return (x!=null)?x.value:null;
		}

		protected void OnUpdate (IXMLNode update)
		{
			//Since you can get change events from login calls, when the Properties object is not yet setup we need to be careful here:
			if (! HasDataFromServer)
				return;

			//var d = event['data'] as Hashtable;

			DomainObjects.PlayerAttribute v = GetProperty (update.GetAttribute ("ikey"));
			if (v != null) {
				v.value = update.GetAttribute ("value");
			}
		}

	}
}
