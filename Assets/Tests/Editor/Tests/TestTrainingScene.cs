using NUnit.Framework;
using Altom.AltUnityDriver;

public class TestTrainingScene
{
    public AltUnityDriver altUnityDriver;
    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        altUnityDriver =new AltUnityDriver();
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        altUnityDriver.Stop();
    }

    [Test]
    public void TestStartGame()
    {
	//Here you can write the test
    }
    [Test]
    public void TestFireBombs()
    {

    }
    [Test]
    public void TestFightEnemy()
    {
        
    }

}