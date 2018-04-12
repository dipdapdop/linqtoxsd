﻿namespace Xml.Schema.Linq.Xunit
{
    using X = global::Xunit;
    using S = global::System.Xml.Schema;
    using XML = global::System.Xml;
    using A = global::System.Reflection.Assembly;
    using G = XObjectsGenerator.XObjectsGenerator;
    using R = Properties.Resources;


    public class Attribute
    {
        [X.Fact]
        public void Empty()
        {
            var set = new S.XmlSchemaSet();
            G.ThisAssembly = A.GetExecutingAssembly();
            G.GenerateXObjects(set, null, null, null, true, false);
        }

        public void UnionTest(params string[] s)
        {
            var set = new S.XmlSchemaSet();
            var settings = new XML.XmlReaderSettings()
            {
                DtdProcessing = XML.DtdProcessing.Parse,
            };
            foreach (var i in s)
            {
                var reader = new System.IO.StringReader(i);
                var r = XML.XmlReader.Create(reader, settings);
                set.Add(null, r);
            }
            G.ThisAssembly = A.GetExecutingAssembly();
            G.GenerateXObjects(set, "temp.cs", null, null, true, false);
        }

        [X.Fact]
        public void Union()
        {
            this.UnionTest(R.Union);
        }

        [X.Fact]
        public void UnionBasic()
        {
            this.UnionTest(R.Basic);
        }

        [X.Fact]
        public void UnionType()
        {
            this.UnionTest(R.Type);
        }

        [X.Fact]
        public void UnionElement()
        {
            this.UnionTest(R.Element);
        }

        [X.Fact]
        public void Issue5600()
        {
            this.UnionTest(R.Element2);
        }

        [X.Fact]
        public void AttributeSimple()
        {
            this.UnionTest(R.Simple);
        }

        [X.Fact]
        public void Import()
        {
            this.UnionTest(R.AttributeUse, R.Attribute);
        }

    }
}
