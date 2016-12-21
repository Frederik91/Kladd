using RevitIFcExport;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IfcExportTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var GNC = new GetNotepadContent();
            var checkString = "Test";
            
            var resultText = GNC.GetNotePadContent_Contains(checkString);

            Assert.AreEqual(checkString, resultText);
        }
    }
}
