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
            bool checkBool = false;
            
            var resultText = GNC.GetNotePadContent_Contains(checkString);

            if (resultText.ToUpper().Contains(checkString.ToUpper()))
            {
                checkBool = true;
            }

            Assert.AreEqual(true, checkBool);
        }
    }
}
