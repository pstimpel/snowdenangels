Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports SnowdenAngelsSupport

<TestClass()> Public Class UnitTest_Registry

    <TestMethod()> Public Sub Test_Registry()

        Dim testkey As String = "unittest_dosaddudiosa"
        Dim testvalue As String = "unittest_usmemisxjms"

        Dim b_result As Boolean
        Dim s_result As String


        'First, try producing some fails, just pass empty keys
        b_result = Registry.KeyExists("")
        Assert.IsFalse(b_result)

        b_result = Registry.DeleteKey("")
        Assert.IsFalse(b_result)

        b_result = Registry.CreateKey("")
        Assert.IsFalse(b_result)

        b_result = Registry.SetValue("", "")
        Assert.IsFalse(b_result)


        'now simulate true action
        '1st, the key should not exist
        b_result = Registry.KeyExists(testkey)
        Assert.IsFalse(b_result)

        'now, create the key. Since SetValue checks itself for not created key, it will create the key and set the value
        b_result = Registry.SetValue(testkey, testvalue)
        Assert.IsTrue(b_result)

        'the key should exist now
        b_result = Registry.KeyExists(testkey)
        Assert.IsTrue(b_result)

        'the key exists, and should contain the value, check both positive and negative
        s_result = Registry.GetValue(testkey)
        Assert.AreEqual(testvalue, s_result)
        Assert.AreNotEqual(testvalue & "wrong", s_result)

        'can we delete the key
        b_result = Registry.DeleteKey(testkey)
        Assert.IsTrue(b_result)

        'if the key was deleted, it shouldnt be there anymore
        b_result = Registry.KeyExists(testkey)
        Assert.IsFalse(b_result)

    End Sub

End Class