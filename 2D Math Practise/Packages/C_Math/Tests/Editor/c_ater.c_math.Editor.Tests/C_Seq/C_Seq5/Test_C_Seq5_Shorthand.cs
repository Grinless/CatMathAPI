using NUnit.Framework;

public class Test_C_Seq5_Shorthand
{
    [Test]
    public void Test_C_Seq5Shorthand_Zero()
    {
        //Test that shorthand references are as expected. 
        Assert.AreEqual(new C_Seq5(0, 0, 0, 0, 0), C_Seq5.Zero);
    }

    [Test]
    public void Test_C_Seq5Shorthand_SeqX()
    {
        //Test that shorthand references are as expected. 
        Assert.AreEqual(new C_Seq5(1, 0, 0, 0, 0), C_Seq5.SeqX);
    }

    [Test]
    public void Test_C_Seq5Shorthand_SeqY()
    {
        //Test that shorthand references are as expected. 
        Assert.AreEqual(new C_Seq5(0, 1, 0, 0, 0), C_Seq5.SeqY);
    }

    [Test]
    public void Test_C_Seq5Shorthand_SeqZ()
    {
        //Test that shorthand references are as expected. 
        Assert.AreEqual(new C_Seq5(0, 0, 1, 0, 0), C_Seq5.SeqZ);
    }

    [Test]
    public void Test_C_Seq5Shorthand_SeqW()
    {
        //Test that shorthand references are as expected. 
        Assert.AreEqual(new C_Seq5(0, 0, 0, 1, 0), C_Seq5.SeqW);
    }

    [Test]
    public void Test_C_Seq5Shorthand_SeqK()
    {
        //Test that shorthand references are as expected. 
        Assert.AreEqual(new C_Seq5(0, 0, 0, 0, 1), C_Seq5.SeqK);
    }
}
