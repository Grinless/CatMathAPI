using NUnit.Framework;

public class Test_C_Seq4_Shorthand
{
    [Test]
    public void Test_C_Seq2Shorthand_Zero()
    {
        //Test that shorthand references are as expected. 
        Assert.AreEqual(new C_Seq4(0, 0, 0, 0), C_Seq4.Zero);
    }

    [Test]
    public void Test_C_Seq2Shorthand_SeqX()
    {
        //Test that shorthand references are as expected. 
        Assert.AreEqual(new C_Seq4(1, 0, 0, 0), C_Seq4.SeqX);
    }

    [Test]
    public void Test_C_Seq2Shorthand_SeqY()
    {
        //Test that shorthand references are as expected. 
        Assert.AreEqual(new C_Seq4(0, 1, 0, 0), C_Seq4.SeqY);
    }

    [Test]
    public void Test_C_Seq2Shorthand_SeqZ()
    {
        //Test that shorthand references are as expected. 
        Assert.AreEqual(new C_Seq4(0, 0, 1, 0), C_Seq4.SeqZ);
    }

    [Test]
    public void Test_C_Seq2Shorthand_SeqW()
    {
        //Test that shorthand references are as expected. 
        Assert.AreEqual(new C_Seq4(0, 0, 0, 1), C_Seq4.SeqW);
    }
}