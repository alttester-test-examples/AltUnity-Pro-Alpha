using NUnit.Framework;
using Altom.AltUnityDriver;

public class TestCreateGameScene
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
    public void TestCreateGameWithValidName()
    {
        altUnityDriver.LoadScene("LobbyScene");
        var createButton=altUnityDriver.FindObject(By.PATH,"//Buttons/CreateGame");
        createButton.Tap();
        altUnityDriver.WaitForObject(By.NAME,"CreateGame");
        var startButton=altUnityDriver.FindObject(By.PATH,"//CreateGame//CounterRotation/Text").SetText("WAR");
        Assert.AreEqual(startButton.GetText(),"WAR");
    }
    [Test]
    public void TestCreateGameWithoutName()
    {
        altUnityDriver.LoadScene("LobbyScene");
        var createButton=altUnityDriver.FindObject(By.PATH,"//Buttons/CreateGame");
        createButton.Tap();
        altUnityDriver.WaitForObject(By.NAME,"CreateGame");
        var startButton=altUnityDriver.FindObject(By.PATH,"//CreateGame//CreateButton");
        startButton.Tap();
        altUnityDriver.WaitForObject(By.NAME,"InfoPanel");
        var warningText=altUnityDriver.FindObject(By.PATH,"//InfoPanel//BodyText").GetText();
        Assert.AreEqual(warningText,"Server name cannot be empty!");
    }

}