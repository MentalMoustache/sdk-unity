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
using System.Xml;

public class SystemXMLNodeFactory : IXMLNodeFactory
{

	public override IXMLNode Create()
	{
		return new XMLNode();
	}

	public override IXMLNode Create(string xml)
	{
		XmlDocument doc = new XmlDocument();
		doc.LoadXml(xml);
		return new SystemXMLNode(doc);
	}

	public override IXMLNode Create(string name, string text)
	{
		XmlDocument doc = new XmlDocument();
		XmlElement element = doc.CreateElement(name);
		doc.AppendChild(element);
		element.AppendChild(doc.CreateTextNode(text));
		return new SystemXMLNode(doc);
	}
}