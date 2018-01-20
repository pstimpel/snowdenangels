Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports SnowdenAngelsSupport

<TestClass()> Public Class UnitTest_Crypto

    <TestMethod()> Public Sub Test_CryptoGenerateHash()



        Dim hash As String = Crypto.GenerateSHA256String("something")
        Dim hash_equal As String = Crypto.GenerateSHA256String("something")
        Dim hash_different As String = Crypto.GenerateSHA256String("something else")
        Dim hash_fromEmpty As String = Crypto.GenerateSHA256String("")

        Assert.IsNotNull(hash)
        Assert.IsNotNull(hash_equal)
        Assert.IsNotNull(hash_different)
        Assert.AreEqual(64, hash.Length)
        Assert.AreEqual(64, hash_equal.Length)
        Assert.AreEqual(64, hash_different.Length)
        Assert.AreEqual(hash, hash_equal)
        Assert.AreNotEqual(hash, hash_different)
        Assert.AreEqual("e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855", hash_fromEmpty.ToLower)

    End Sub

End Class