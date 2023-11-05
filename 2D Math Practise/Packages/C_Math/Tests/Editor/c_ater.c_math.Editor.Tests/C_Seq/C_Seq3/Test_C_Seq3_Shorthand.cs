using NUnit.Framework;

public class Test_C_Seq3_Shorthand
{
    [Test]
    public void Test_C_Seq3Shorthand_Zero()
    {
        //Test that shorthand references are as expected. 
        Assert.AreEqual(new C_Seq3(0, 0, 0), C_Seq3.Zero);
    }

    [Test]
    public void Test_C_Seq3Shorthand_SeqX()
    {
        //Test that shorthand references are as expected. 
        Assert.AreEqual(new C_Seq3(1, 0, 0), C_Seq3.SeqX);
    }

    [Test]
    public void Test_C_Seq3Shorthand_SeqY()
    {
        //Test that shorthand references are as expected. 
        Assert.AreEqual(new C_Seq3(0, 1, 0), C_Seq3.SeqY);
    }

    [Test]
    public void Test_C_Seq3Shorthand_SeqZ()
    {
        //Test that shorthand references are as expected. 
        Assert.AreEqual(new C_Seq3(0, 0, 1), C_Seq3.SeqZ);
    }
}