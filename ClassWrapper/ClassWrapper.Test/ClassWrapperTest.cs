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


using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassWrapper.Test
{
	public class SampleClass
	{
		public string StringProperty { get; set; }

		public void VoidMethod()
		{
			
		}

		public void ParamMethod(string val)
		{
			StringProperty = val;
		}

		public void ParamMethod(object val)
		{
			StringProperty = val.ToString();
		}
	}

	

	[TestClass]
	public class ClassWrapperTest
	{
		[TestMethod]
		[Ignore]
		public void WeShouldInvokeReturn()
		{


		}

		[TestMethod]
		[Ignore]
		public void WeShouldInvokeObject()
		{


		}

		[TestMethod]
		[Ignore]
		public void WeShouldTryInvoke()
		{


		}

		[TestMethod]
		public void ShouldBePossibleToCreateAWrapper()
		{
			var instance = new SampleClass();
			var classWrapperDescriptor = new ClassWrapperDescriptor(typeof(SampleClass));
			classWrapperDescriptor.Load();
			Assert.AreEqual(8, classWrapperDescriptor.Methods.Count);
			Assert.AreEqual(1, classWrapperDescriptor.Properties.Count);
			var classWrapper = classWrapperDescriptor.CreateWrapper(instance);
			classWrapper.Set("StringProperty","test");
			Assert.AreEqual("test",instance.StringProperty);
			var result = classWrapper.Get<string>("StringProperty");
			Assert.AreEqual("test", result);
		}


		[TestMethod]
		public void ShouldBePossibleToInvokeFunctionsOnWrapper()
		{
			var instance = new SampleClass();
			var classWrapperDescriptor = new ClassWrapperDescriptor(typeof(SampleClass));
			classWrapperDescriptor.Load();
			Assert.AreEqual(8, classWrapperDescriptor.Methods.Count);
			Assert.AreEqual(1, classWrapperDescriptor.Properties.Count);
			var classWrapper = classWrapperDescriptor.CreateWrapper(instance);
			var guid = Guid.NewGuid();
			classWrapper.Invoke("ParamMethod", guid);
			Assert.AreEqual(guid.ToString(), instance.StringProperty);
		}
	}
}
