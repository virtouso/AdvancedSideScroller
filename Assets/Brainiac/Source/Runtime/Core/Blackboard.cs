using UnityEngine;
using System.Collections.Generic;

namespace Brainiac
{
	public class Blackboard : MonoBehaviour 
	{
		[SerializeField]
		private Memory[] m_startMemory;

		private Dictionary<string, object> m_values;

		private void Awake()
		{
			m_values = new Dictionary<string, object>();
			for(int i = 0; i < m_startMemory.Length; i++)
			{
				SetItem(m_startMemory[i].Name, m_startMemory[i].GetValue());
			}
		}

		public void SetItem(string name, object item)
		{
			if(!string.IsNullOrEmpty(name))
			{
				if(m_values.ContainsKey(name))
				{
					m_values[name] = item;
				}
				else
				{
					m_values.Add(name, item);
				}
			}
		}

		public object GetItem(string name, object defValue = null)
		{
			if(!string.IsNullOrEmpty(name))
			{
				object value = null;
				if(m_values.TryGetValue(name, out value))
				{
					return value;
				}
			}
			
			return defValue;
		}

		public T GetItem<T>(string name, T defaultValue)
		{
			object value = GetItem(name);
			return (value != null && value is T) ? (T)value : defaultValue;
		}

		public bool HasItem<T>(string name)
		{
			object value = GetItem(name);
			return (value != null && value is T);
		}
	}
}
