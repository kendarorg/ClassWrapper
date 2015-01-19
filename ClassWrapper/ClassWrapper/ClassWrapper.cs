// ===========================================================
// Copyright (c) 2014-2015, Enrico Da Ros/kendar.org
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
// 
// * Redistributions of source code must retain the above copyright notice, this
//   list of conditions and the following disclaimer.
// 
// * Redistributions in binary form must reproduce the above copyright notice,
//   this list of conditions and the following disclaimer in the documentation
//   and/or other materials provided with the distribution.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// ===========================================================


using System.Collections.ObjectModel;

namespace ClassWrapper
{
	public class ClassWrapper
	{
		public object Instance { get; private set; }
		private readonly ClassWrapperDescriptor _descriptor;

		internal ClassWrapper(ClassWrapperDescriptor descriptor, object instance)
		{
			Instance = instance;
			_descriptor = descriptor;
		}

		public ClassWrapper(ClassWrapperDescriptor descriptor)
		{
			_descriptor = descriptor;
		}

		public ReadOnlyCollection<string> Properties
		{
			get
			{
				return _descriptor.Properties;
			}
		}

		public ReadOnlyCollection<string> Methods
		{
			get
			{
				return _descriptor.Methods;
			}
		}

		public bool ContainsMethod(string methodName)
		{
			return _descriptor.ContainsMethod(methodName);
		}

		public ReadOnlyCollection<MethodWrapperDescriptor> GetMethodGroup(string methodName)
		{
			return _descriptor.GetMethodGroup(methodName);
		}

		public bool ContainsProperty(string propertyName)
		{
			return _descriptor.ContainsProperty(propertyName);
		}

		public T InvokeReturn<T>(string methodName, params object[] pars)
		{
			return _descriptor.InvokeReturn<T>(Instance, methodName, pars);
		}

		public object InvokeObject(string methodName, params object[] pars)
		{
			return _descriptor.InvokeReturnObject(Instance, methodName, pars);
		}

		public void Invoke(string methodName, params object[] pars)
		{
			_descriptor.Invoke(Instance, methodName, pars);
		}

		public T Get<T>(string methodName)
		{
			return _descriptor.Get<T>(Instance, methodName);
		}

		public bool TryInvoke(MethodWrapperDescriptor meth, out object result, params object[] valuesParams)
		{
			return _descriptor.TryInvoke(Instance, meth, out result, valuesParams);
		}

		public object GetObject(string methodName)
		{
			return _descriptor.GetObject(Instance, methodName);
		}

		public void Set(string methodName, object value)
		{
			_descriptor.Set(Instance, methodName, value);
		}
	}
}
