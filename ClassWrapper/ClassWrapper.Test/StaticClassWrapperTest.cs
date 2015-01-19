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
	public class SampleClassStatic:SampleClass
	{
		public static string StaticStringProperty { get; set; }
		public static void StaticParamMethod(object val)
		{
			StaticStringProperty = val.ToString();
		}
	}
	[TestClass]
	public class StaticClassWrapperTest
	{
		[TestMethod]
		public void ShouldBePossibleToCreateStaticallyAWrapper()
		{
			var classWrapperDescriptor = new ClassWrapperDescriptor(typeof(SampleClassStatic));
			classWrapperDescriptor.Load();
			Assert.AreEqual(9, classWrapperDescriptor.Methods.Count);
			Assert.AreEqual(2, classWrapperDescriptor.Properties.Count);
			var classWrapper = classWrapperDescriptor.CreateWrapper();
			classWrapper.Set("StaticStringProperty", "test");
			Assert.AreEqual("test", SampleClassStatic.StaticStringProperty);
			var result = classWrapper.Get<string>("StaticStringProperty");
			Assert.AreEqual("test", result);
		}


		[TestMethod]
		public void ShouldBePossibleToInvokeStaticallyFunctionsOnWrapper()
		{
			var classWrapperDescriptor = new ClassWrapperDescriptor(typeof(SampleClassStatic));
			classWrapperDescriptor.Load();
			Assert.AreEqual(9, classWrapperDescriptor.Methods.Count);
			Assert.AreEqual(2, classWrapperDescriptor.Properties.Count);
			var classWrapper = classWrapperDescriptor.CreateWrapper();
			var guid = Guid.NewGuid();
			classWrapper.Invoke("StaticParamMethod", guid);
			Assert.AreEqual(guid.ToString(), SampleClassStatic.StaticStringProperty);
		}
	}
}
