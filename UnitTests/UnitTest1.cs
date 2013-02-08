using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trimmer;

namespace UnitTests
{
    [TestClass]
    public class Trimming
    {
        [TestMethod]
        public void TrimSpaceAndChars()
        {
            Assert.AreEqual("abcd".TrimSpacesAndChars(), "abcd");
            Assert.AreEqual("  /.".TrimSpacesAndChars('/', '.'), string.Empty);

            Assert.AreEqual(string.Empty.TrimSpacesAndChars(), string.Empty);
            Assert.AreEqual(" ".TrimSpacesAndChars(), string.Empty);
            Assert.AreEqual("  ".TrimSpacesAndChars(), string.Empty);

            Assert.AreEqual("  / ".TrimSpacesAndChars('/'), string.Empty);
            Assert.AreEqual("  \t ".TrimSpacesAndChars('/'), string.Empty);
            Assert.AreEqual("   ".TrimSpacesAndChars('/'), string.Empty);
            Assert.AreEqual("  ".TrimSpacesAndChars('/'), string.Empty);
            Assert.AreEqual("/".TrimSpacesAndChars('/'), string.Empty);
            Assert.AreEqual("//".TrimSpacesAndChars('/'), string.Empty);
            Assert.AreEqual("//  ".TrimSpacesAndChars('/'), string.Empty);
            Assert.AreEqual("/ ".TrimSpacesAndChars('/'), string.Empty);

            Assert.AreEqual(" a ".TrimSpacesAndChars(), "a");
            Assert.AreEqual(" a".TrimSpacesAndChars(), "a");
            Assert.AreEqual("a ".TrimSpacesAndChars(), "a");
            Assert.AreEqual("  a  ".TrimSpacesAndChars(), "a");
            Assert.AreEqual(" a \n\r".TrimSpacesAndChars(), "a");
            Assert.AreEqual("\t\r a ".TrimSpacesAndChars(), "a");
            Assert.AreEqual("\ta ".TrimSpacesAndChars(), "a");
            Assert.AreEqual(" a a ".TrimSpacesAndChars(), "a a");

            Assert.AreEqual(" a ".TrimSpacesAndChars('/'), "a");
            Assert.AreEqual(" a".TrimSpacesAndChars('/'), "a");
            Assert.AreEqual("a ".TrimSpacesAndChars('/'), "a");
            Assert.AreEqual("  a  ".TrimSpacesAndChars('/'), "a");
            Assert.AreEqual(" a \n\r".TrimSpacesAndChars('/'), "a");
            Assert.AreEqual("\t\r a ".TrimSpacesAndChars('/'), "a");
            Assert.AreEqual("\ta ".TrimSpacesAndChars('/'), "a");
            Assert.AreEqual(" a a ".TrimSpacesAndChars('/'), "a a");

            Assert.AreEqual(" a ".TrimSpacesAndChars('/', ' '), "a");
            Assert.AreEqual(" a".TrimSpacesAndChars('/', ' '), "a");
            Assert.AreEqual("a ".TrimSpacesAndChars('/', ' '), "a");
            Assert.AreEqual("  a  ".TrimSpacesAndChars('/', ' '), "a");
            Assert.AreEqual(" a \n\r".TrimSpacesAndChars('/', ' '), "a");
            Assert.AreEqual("\t\r a ".TrimSpacesAndChars('/', ' '), "a");
            Assert.AreEqual("\ta ".TrimSpacesAndChars('/', ' '), "a");
            Assert.AreEqual(" a a ".TrimSpacesAndChars('/', ' '), "a a");

            Assert.AreEqual("/ a ".TrimSpacesAndChars('/'), "a");
            Assert.AreEqual(" / a".TrimSpacesAndChars('/'), "a");
            Assert.AreEqual("a / /".TrimSpacesAndChars('/'), "a");
            Assert.AreEqual("  a  // //".TrimSpacesAndChars('/'), "a");
            Assert.AreEqual(" a \n\r//".TrimSpacesAndChars('/'), "a");
            Assert.AreEqual("////\t\r a ".TrimSpacesAndChars('/'), "a");
            Assert.AreEqual("\ta /".TrimSpacesAndChars('/'), "a");
            Assert.AreEqual(" a/ a ".TrimSpacesAndChars('/'), "a/ a");

            Assert.AreEqual("/ a ".TrimSpacesAndChars('/', ' '), "a");
            Assert.AreEqual(" / a".TrimSpacesAndChars('/', ' '), "a");
            Assert.AreEqual("a / /".TrimSpacesAndChars('/', ' '), "a");
            Assert.AreEqual("  a  // //".TrimSpacesAndChars('/', ' '), "a");
            Assert.AreEqual(" a \n\r//".TrimSpacesAndChars('/', ' '), "a");
            Assert.AreEqual("////\t\r a ".TrimSpacesAndChars('/', ' '), "a");
            Assert.AreEqual("\ta /".TrimSpacesAndChars('/', ' '), "a");
            Assert.AreEqual(" a/ a ".TrimSpacesAndChars('/', ' '), "a/ a");

            Assert.AreEqual(" a /.".TrimSpacesAndChars('/', '.'), "a");
            Assert.AreEqual(" a".TrimSpacesAndChars('/', '.'), "a");
            Assert.AreEqual("/. ./a ".TrimSpacesAndChars('/', '.'), "a");
            Assert.AreEqual("  a  ".TrimSpacesAndChars('/', '.'), "a");
            Assert.AreEqual(" a \n\r".TrimSpacesAndChars('/', '.'), "a");
            Assert.AreEqual("\t\r a ".TrimSpacesAndChars('/', '.'), "a");
            Assert.AreEqual("\ta ".TrimSpacesAndChars('/', '.'), "a");
            Assert.AreEqual("///..a/./a /. ./....".TrimSpacesAndChars('/', '.'), "a/./a");
        }
    }
}
