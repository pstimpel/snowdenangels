Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports SnowdenAngelsSupport

<TestClass()> Public Class UnitTest_Updates

    <TestMethod()> Public Sub Test_Updates_QueryUpdate()

        'make sure both main project and Unittest carry sane verison information in assembly settings

        Dim DevVersion As String = Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString

        Dim result_false As Boolean = Updates.QueryUpdate(DevVersion)
        Dim result_true As Boolean = Updates.QueryUpdate("something totally wrong")

        Assert.IsTrue(result_true)
        Assert.IsFalse(result_false)

    End Sub

End Class