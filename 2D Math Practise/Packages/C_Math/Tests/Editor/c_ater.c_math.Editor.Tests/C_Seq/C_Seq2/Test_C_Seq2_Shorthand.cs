using NUnit.Framework;

public class Test_C_Seq2_Shorthand
{

    [Test]
    public void Test_C_Seq2Shorthand_Zero()
    {
        //Test that shorthand references are as expected. 
        Assert.AreEqual(new C_Seq2(0, 0), C_Seq2.Zero);
    }

    [Test]
    public void Test_C_Seq2Shorthand_SeqX()
    {
        //Test that shorthand references are as expected.
        Assert.AreEqual(new C_Seq2(1, 0), C_Seq2.SeqX);
    }

    [Test]
    public void Test_C_Seq2Shorthand_SeqY()
    {
        //Test that shorthand references are as expected. 
        Assert.AreEqual(new C_Seq2(0, 1), C_Seq2.SeqY);
    }

}